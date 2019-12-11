using Microsoft.Win32.SafeHandles;
using OpenCV.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bonsai.Pco
{
    public class PcoCapture : Source<IplImage>
    {
        public int Index { get; set; }

        public AcquireMode AcquireMode { get; set; }

        public TriggerMode TriggerMode { get; set; }

        public TimestampMode TimestampMode { get; set; }

        public override IObservable<IplImage> Generate()
        {
            return Observable.Create<IplImage>((observer, cancellationToken) =>
            {
                return Task.Factory.StartNew(() =>
                {
                    short bufnr = -1;
                    var cameraHandle = IntPtr.Zero;
                    var error = PCO_SDK_LibWrapper.PCO_OpenCamera(ref cameraHandle, (ushort)Index);
                    ThrowExceptionForErrorCode(error);
                    try
                    {
                        ushort wRecState = 0;
                        PCO_SDK_LibWrapper.PCO_GetRecordingState(cameraHandle, ref wRecState);
                        if (wRecState != 0)
                        {
                            PCO_SDK_LibWrapper.PCO_SetRecordingState(cameraHandle, 0);
                        }

                        var dwWarn = 0u;
                        var dwError = 0u;
                        var dwStatus = 0u;
                        error = PCO_SDK_LibWrapper.PCO_GetCameraHealthStatus(cameraHandle, ref dwWarn, ref dwError, ref dwStatus);
                        ThrowExceptionForErrorCode(error);

                        error = PCO_SDK_LibWrapper.PCO_SetTimestampMode(cameraHandle, (ushort)TimestampMode);
                        ThrowExceptionForErrorCode(error);

                        error = PCO_SDK_LibWrapper.PCO_SetTriggerMode(cameraHandle, (ushort)TriggerMode);
                        ThrowExceptionForErrorCode(error);

                        error = PCO_SDK_LibWrapper.PCO_SetAcquireMode(cameraHandle, (ushort)AcquireMode);
                        ThrowExceptionForErrorCode(error);

                        error = PCO_SDK_LibWrapper.PCO_ArmCamera(cameraHandle);
                        ThrowExceptionForErrorCode(error);

                        var pcoDescr = new PCO_Description();
                        pcoDescr.wSize = (ushort)Marshal.SizeOf(pcoDescr);
                        error = PCO_SDK_LibWrapper.PCO_GetCameraDescription(cameraHandle, ref pcoDescr);
                        ThrowExceptionForErrorCode(error);

                        ushort width = 0;
                        ushort height = 0;
                        ushort maxWidth = 0;
                        ushort maxHeight = 0;
                        error = PCO_SDK_LibWrapper.PCO_GetSizes(cameraHandle, ref width, ref height, ref maxWidth, ref maxHeight);
                        ThrowExceptionForErrorCode(error);

                        PCO_SDK_LibWrapper.PCO_CamLinkSetImageParameters(cameraHandle, width, height);
                        error = PCO_SDK_LibWrapper.PCO_SetRecordingState(cameraHandle, 1);
                        ThrowExceptionForErrorCode(error);

                        int max;
                        int min;
                        int ishift = 16 - pcoDescr.wDynResDESC;
                        var size = width * height * 2;
                        var buf = UIntPtr.Zero;
                        var evhandle = IntPtr.Zero;

                        error = PCO_SDK_LibWrapper.PCO_AllocateBuffer(cameraHandle, ref bufnr, size, ref buf, ref evhandle);
                        if (error != 0) error = PCO_SDK_LibWrapper.PCO_GetBuffer(cameraHandle, bufnr, ref buf, ref evhandle);
                        ThrowExceptionForErrorCode(error);

                        var waitHandle = new BufferWaitHandle(evhandle);
                        while (!cancellationToken.IsCancellationRequested)
                        {
                            error = PCO_SDK_LibWrapper.PCO_AddBufferEx(cameraHandle, 0, 0, bufnr, width, height, pcoDescr.wDynResDESC);
                            ThrowExceptionForErrorCode(error);

                            var imageReceived = waitHandle.WaitOne(3000);
                            if (!imageReceived) continue;
                            unsafe
                            {
                                Int16* bufi = (Int16*)buf.ToPointer();
                                max = 0;
                                min = 65535;
                                for (int i = 20 * width; i < height * width; i++)
                                {
                                    bufi[i] >>= ishift;
                                    if (bufi[i] > max)
                                        max = bufi[i];
                                    if (bufi[i] < min)
                                        min = bufi[i];
                                }
                                if (max <= min)
                                    max = min + 1;

                                using (var image = new IplImage(new Size(width, height), IplDepth.U16, 1, (IntPtr)buf.ToPointer()))
                                {
                                    observer.OnNext(image.Clone());
                                }
                            }
                        }
                    }
                    finally
                    {
                        PCO_SDK_LibWrapper.PCO_SetRecordingState(cameraHandle, 0);
                        if (bufnr != -1) PCO_SDK_LibWrapper.PCO_FreeBuffer(cameraHandle, bufnr);
                        PCO_SDK_LibWrapper.PCO_CloseCamera(cameraHandle);
                    }
                },
                cancellationToken,
                TaskCreationOptions.LongRunning,
                TaskScheduler.Default);
            });
        }

        static void ThrowExceptionForErrorCode(int error)
        {
            if (error != 0)
            {
                var message = string.Empty;
                PCO_GetErrorTextClass.PCO_GetErrorText((uint)error, ref message);
                PCO_SDK_LibWrapper.PCO_ResetLib();
                throw new InvalidOperationException(message);
            }
        }

        class BufferWaitHandle : WaitHandle
        {
            public BufferWaitHandle(IntPtr handle)
                : base()
            {
                SafeWaitHandle = new SafeWaitHandle(handle, false);
            }
        }
    }
}
