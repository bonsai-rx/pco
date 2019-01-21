using OpenCV.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonsai.Pco
{
    public class PcoCapture : Source<IplImage>
    {
        public override IObservable<IplImage> Generate()
        {
            return Observable.Create<IplImage>((observer, cancellationToken) =>
            {
                return Task.Factory.StartNew(() =>
                {
                    ushort boardNum = 0;
                    var cameraHandle = IntPtr.Zero;
                    var error = PCO_SDK_LibWrapper.PCO_OpenCamera(ref cameraHandle, boardNum);
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

                        PCO_SDK_LibWrapper.PCO_SetTriggerMode(cameraHandle, 0);
                        error = PCO_SDK_LibWrapper.PCO_ArmCamera(cameraHandle);
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
                    }
                    finally
                    {
                        PCO_SDK_LibWrapper.PCO_SetRecordingState(cameraHandle, 0);
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
    }
}
