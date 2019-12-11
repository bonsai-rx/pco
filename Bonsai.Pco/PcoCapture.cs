using Microsoft.Win32.SafeHandles;
using OpenCV.Net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reactive.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bonsai.Pco
{
    [Description("Acquires a sequence of images from a PCO camera.")]
    public class PcoCapture : Source<PcoDataFrame>
    {
        [Description("The index of the camera from which to acquire images.")]
        public int Index { get; set; }

        [Description("Specifies the acquisition control mode of the camera.")]
        public AcquireMode AcquireMode { get; set; }

        [Description("Specifies the trigger mode of the camera.")]
        public TriggerMode TriggerMode { get; set; }

        [Description("Specifies whether to include timestamp information in image metadata.")]
        public TimestampMode TimestampMode { get; set; }

        public override IObservable<PcoDataFrame> Generate()
        {
            return Observable.Create<PcoDataFrame>((observer, cancellationToken) =>
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

                        var timestampMode = TimestampMode;
                        error = PCO_SDK_LibWrapper.PCO_SetTimestampMode(cameraHandle, (ushort)timestampMode);
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
                                PcoDataFrame result;
                                Int16* bufi = (Int16*)buf.ToPointer();
                                if ((timestampMode & Pco.TimestampMode.Binary) != Pco.TimestampMode.None)
                                {
                                    result.Counter = FromPackedBcd(bufi[0], bufi[1], bufi[2], bufi[3]);
                                    result.Timestamp = new DateTimeOffset(
                                        FromPackedBcd(bufi[4], bufi[5]), // year
                                        FromPackedBcd(bufi[6]), // month
                                        FromPackedBcd(bufi[7]), // day
                                        FromPackedBcd(bufi[8]), // hour
                                        FromPackedBcd(bufi[9]), // minutes
                                        FromPackedBcd(bufi[10]), // seconds
                                        TimeSpan.Zero).AddTicks( // microseconds
                                        FromPackedBcd(bufi[11], bufi[12], bufi[13]) * 10);
                                }
                                else
                                {
                                    result.Counter = 0;
                                    result.Timestamp = new DateTimeOffset(0, TimeSpan.Zero);
                                }

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
                                    result.Image = image.Clone();
                                    observer.OnNext(result);
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

        static int FromPackedBcd(short b0)
        {
            var value = 0;
            value += (byte)(b0 & 0xF) * 1;
            value += (byte)(b0 >> 04) * 10;
            return value;
        }

        static int FromPackedBcd(short b0, short b1)
        {
            var value = 0;
            value += (byte)(b1 & 0xF) * 1;
            value += (byte)(b1 >> 04) * 10;
            value += (byte)(b0 & 0xF) * 100;
            value += (byte)(b0 >> 04) * 1000;
            return value;
        }

        static int FromPackedBcd(short b0, short b1, short b2)
        {
            var value = 0;
            value += (byte)(b2 & 0xF) * 1;
            value += (byte)(b2 >> 04) * 10;
            value += (byte)(b1 & 0xF) * 100;
            value += (byte)(b1 >> 04) * 1000;
            value += (byte)(b0 & 0xF) * 10000;
            value += (byte)(b0 >> 04) * 100000;
            return value;
        }

        static int FromPackedBcd(short b0, short b1, short b2, short b3)
        {
            var value = 0;
            value += (byte)(b3 & 0xF) * 1;
            value += (byte)(b3 >> 04) * 10;
            value += (byte)(b2 & 0xF) * 100;
            value += (byte)(b2 >> 04) * 1000;
            value += (byte)(b1 & 0xF) * 10000;
            value += (byte)(b1 >> 04) * 100000;
            value += (byte)(b0 & 0xF) * 1000000;
            value += (byte)(b0 >> 04) * 10000000;
            return value;
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
