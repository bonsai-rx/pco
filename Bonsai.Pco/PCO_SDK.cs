using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Bonsai.Pco
{
    [StructLayout(LayoutKind.Sequential)]
    struct PCO_SC2_Hardware_DESC
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public String szName;               // string with board name
        public ushort wBatchNo;             // production batch no
        public ushort wRevision;            // use range 0 to 99
        public ushort wVariant;             // variant    // 22
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public ushort[] ZZwDummy;             //            // 62
    };

    [StructLayout(LayoutKind.Sequential)]
    struct PCO_SC2_Firmware_DESC
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public String szName;                // string with device name
        public byte bMinorRev;              // use range 0 to 99
        public byte bMajorRev;              // use range 0 to 255
        public ushort wVariant;             // variant    // 20
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 22)]
        public ushort[] ZZwDummy;             //            // 64
    };

    [StructLayout(LayoutKind.Sequential)]
    struct PCO_HW_Vers
    {
        public ushort BoardNum;       // number of devices
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 10)]
        public PCO_SC2_Hardware_DESC[] Board;// 622
    };

    [StructLayout(LayoutKind.Sequential)]
    struct PCO_FW_Vers
    {
        public ushort DeviceNum;       // number of devices
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 10)]
        public PCO_SC2_Firmware_DESC[] Device;// 642
    };

    [StructLayout(LayoutKind.Sequential)]
    struct PCO_CameraType
    {
        public ushort wSize;                   // Sizeof this struct
        public ushort wCamType;                // Camera type
        public ushort wCamSubType;             // Camera sub type
        public ushort ZZwAlignDummy1;
        public UInt32 dwSerialNumber;          // Serial number of camera // 12
        public UInt32 dwHWVersion;             // Hardware version number
        public UInt32 dwFWVersion;             // Firmware version number
        public ushort wInterfaceType;          // Interface type          // 22
        public PCO_HW_Vers strHardwareVersion;      // Hardware versions of all boards // 644
        public PCO_FW_Vers strFirmwareVersion;      // Firmware versions of all devices // 1286
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 39)]
        public ushort[] ZZwDummy;                                          // 1364
    };

    [StructLayout(LayoutKind.Sequential)]
    struct PCO_Description
    {
        public ushort wSize;                   // Sizeof this struct
        public ushort wSensorTypeDESC;         // Sensor type
        public ushort wSensorSubTypeDESC;      // Sensor subtype
        public ushort wMaxHorzResStdDESC;      // Maxmimum horz. resolution in std.mode
        public ushort wMaxVertResStdDESC;      // Maxmimum vert. resolution in std.mode
        public ushort wMaxHorzResExtDESC;      // Maxmimum horz. resolution in ext.mode
        public ushort wMaxVertResExtDESC;      // Maxmimum vert. resolution in ext.mode
        public ushort wDynResDESC;             // Dynamic resolution of ADC in bit
        public ushort wMaxBinHorzDESC;         // Maxmimum horz. binning
        public ushort wBinHorzSteppingDESC;    // Horz. bin. stepping (0:bin, 1:lin)
        public ushort wMaxBinVertDESC;         // Maxmimum vert. binning
        public ushort wBinVertSteppingDESC;    // Vert. bin. stepping (0:bin, 1:lin)
        public ushort wRoiHorStepsDESC;        // Minimum granularity of ROI in pixels
        public ushort wRoiVertStepsDESC;       // Minimum granularity of ROI in pixels
        public ushort wNumADCsDESC;            // Number of ADCs in system
        public ushort ZZwAlignDummy1;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public uint[] dwPixelRateDESC;       // Possible pixelrate in Hz
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public uint[] ZZdwDummypr;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public ushort[] wConvFactDESC;       // Possible conversion factor in e/cnt
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public ushort[] ZZdwDummycv;
        public ushort wIRDESC;                 // IR enhancment possibility
        public ushort ZZwAlignDummy2;
        public uint dwMinDelayDESC;          // Minimum delay time in ns
        public uint dwMaxDelayDESC;          // Maximum delay time in ms
        public uint dwMinDelayStepDESC;      // Minimum stepping of delay time in ns
        public uint dwMinExposureDESC;       // Minimum exposure time in ns
        public uint dwMaxExposureDESC;       // Maximum exposure time in ms
        public uint dwMinExposureStepDESC;   // Minimum stepping of exposure time in ns
        public uint dwMinDelayIRDESC;        // Minimum delay time in ns
        public uint dwMaxDelayIRDESC;        // Maximum delay time in ms
        public uint dwMinExposureIRDESC;     // Minimum exposure time in ns
        public uint dwMaxExposureIRDESC;     // Maximum exposure time in ms
        public ushort wTimeTableDESC;          // Timetable for exp/del possibility
        public ushort wDoubleImageDESC;        // Double image mode possibility
        public short sMinCoolSetDESC;         // Minimum value for cooling
        public short sMaxCoolSetDESC;         // Maximum value for cooling
        public short sDefaultCoolSetDESC;     // Default value for cooling
        public ushort wPowerDownModeDESC;      // Power down mode possibility 
        public ushort wOffsetRegulationDESC;   // Offset regulation possibility
        public ushort wColorPatternDESC;       // Color pattern of color chip
        // four nibbles (0,1,2,3) in ushort 
        //  ----------------- 
        //  | 3 | 2 | 1 | 0 |
        //  ----------------- 
        //   
        // describe row,column  2,2 2,1 1,2 1,1
        // 
        //   column1 column2
        //  ----------------- 
        //  |       |       |
        //  |   0   |   1   |   row1
        //  |       |       |
        //  -----------------
        //  |       |       |
        //  |   2   |   3   |   row2
        //  |       |       |
        //  -----------------
        // 
        public ushort wPatternTypeDESC;        // Pattern type of color chip
        // 0: Bayer pattern RGB
        // 1: Bayer pattern CMY
        public ushort wDSNUCorrectionModeDESC; // DSNU correction mode possibility
        public ushort ZZwAlignDummy3;          //
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public UInt32[] dwReservedDESC;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 40)]
        public UInt32[] ZZdwDummy;
    };

    [StructLayout(LayoutKind.Sequential)]
    struct PCO_Description2
    {
        public ushort wSize;                   // Sizeof this struct
        public ushort ZZwAlignDummy1;
        public uint dwMinPeriodicalTimeDESC2;// Minimum periodical time tp in (nsec)
        public uint dwMaxPeriodicalTimeDESC2;// Maximum periodical time tp in (msec)        (12)
        public uint dwMinPeriodicalConditionDESC2;// System imanent condition in (nsec)
        // tp - (td + te) must be equal or longer than
        // dwMinPeriodicalCondition
        public uint dwMaxNumberOfExposuresDESC2;// Maximum number of exporures possible        (20)
        public int lMinMonitorSignalOffsetDESC2;// Minimum monitor signal offset tm in (nsec)
        // if(td + tstd) > dwMinMon.)
        //   tm must not be longer than dwMinMon
        // else
        //   tm must not be longer than td + tstd
        public uint dwMaxMonitorSignalOffsetDESC2;// Maximum -''- in (nsec)                      
        public uint dwMinPeriodicalStepDESC2;// Minimum step for periodical time in (nsec)  (32)
        public uint dwStartTimeDelayDESC2; // Minimum monitor signal offset tstd in (nsec)
        // see condition at dwMinMonitorSignalOffset
        public uint dwMinMonitorStepDESC2; // Minimum step for monitor time in (nsec)     (40)
        public uint dwMinDelayModDESC2;    // Minimum delay time for modulate mode in (nsec)
        public uint dwMaxDelayModDESC2;    // Maximum delay time for modulate mode in (msec)
        public uint dwMinDelayStepModDESC2;// Minimum delay time step for modulate mode in (nsec)(52)
        public uint dwMinExposureModDESC2; // Minimum exposure time for modulate mode in (nsec)
        public uint dwMaxExposureModDESC2; // Maximum exposure time for modulate mode in (msec)(60)
        public uint dwMinExposureStepModDESC2;// Minimum exposure time step for modulate mode in (nsec)
        public uint dwModulateCapsDESC2;   // Modulate capabilities descriptor
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public UInt32[] dwReservedDESC;                                                    //(132)
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 41)]
        public UInt32[] ZZdwDummy;                                                         // 296};
    };

    [StructLayout(LayoutKind.Sequential)]
    struct PCO_DescriptionEx
    {
        public ushort wSize;                   // Sizeof this struct
    };

    [StructLayout(LayoutKind.Sequential)]
    struct PCO_Storage
    {
        public ushort wSize;                   // Sizeof this struct
        public ushort ZZwAlignDummy1;
        public UInt32 dwRamSize;               // Size of camera ram in pages
        public ushort wPageSize;               // Size of one page in pixel       // 10
        public ushort ZZwAlignDummy4;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public UInt32[] dwRamSegSize;          // Size of ram segment 1-4 in pages // 28
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public UInt32[] ZZdwDummyrs;                                                // 108
        public ushort wActSeg;                 // no. (0 .. 3) of active segment  // 110
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 39)]
        public ushort[] ZZwDummy;                                     // 188
    };

    [StructLayout(LayoutKind.Sequential)]
    struct PCO_Segment
    {
        public ushort wSize;                   // Sizeof this struct
        public ushort wXRes;                   // Res. h. = resulting horz.res.(sensor resolution, ROI, binning)
        public ushort wYRes;                   // Res. v. = resulting vert.res.(sensor resolution, ROI, binning)
        public ushort wBinHorz;                // Horizontal binning
        public ushort wBinVert;                // Vertical binning                // 10
        public ushort wRoiX0;                  // Roi upper left x
        public ushort wRoiY0;                  // Roi upper left y
        public ushort wRoiX1;                  // Roi lower right x
        public ushort wRoiY1;                  // Roi lower right y
        public ushort ZZwAlignDummy1;                                             // 20
        public UInt32 dwValidImageCnt;         // no. of valid images in segment
        public UInt32 dwMaxImageCnt;           // maximum no. of images in segment // 28
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 40)]
        public ushort[] ZZwDummy;                                         // 188
    };

    [StructLayout(LayoutKind.Sequential)]
    struct PCO_Image
    {
        public ushort wSize;      // Sizeof this struct
        public ushort ZZwAlignDummy1;                                    // 4
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4)]
        public PCO_Segment[] strSegment;// Segment info                      // 436
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 16)]
        public PCO_Segment[] ZZstrDummySeg;// Segment info dummy            // 2164
        public ushort wBitAlignment;// Bitalignment during readout. 0: MSB, 1: LSB aligned
        public ushort wHotPixelCorrectionMode;   // Correction mode for hotpixel
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 38)]
        public ushort[] ZZwDummy;                                              // 2244
    };

    [StructLayout(LayoutKind.Sequential)]
    struct PCO_OpenStruct
    {
        public ushort wSize;        // Sizeof this struct
        public ushort wInterfaceType;
        public ushort wCameraNumber;
        public ushort wCameraNumAtInterface; // Current number of camera at the interface
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 10)]
        public ushort[] wOpenFlags;   // [0]: moved to dwnext to position 0xFF00
        // [1]: moved to dwnext to position 0xFFFF0000
        // [2]: Bit0: PCO_OPENFLAG_GENERIC_IS_CAMLINK
        //            Set this bit in case of a generic Cameralink interface
        //            This enables the import of the additional three camera-
        //            link interface functions.

        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 5)]
        public UInt32[] dwOpenFlags;// [0]-[4]: moved to strCLOpen.dummy[0]-[4]
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 6)]
        public IntPtr[] wOpenPtr;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 8)]
        public ushort[] zzwDummy;     // 88 - 64bit: 112
    };

    class PCO_SDK_LibWrapper
    {
        const string Sc2Cam = "sc2_cam";
        const string Sc2Dlg = "sc2_Dlg";

        [DllImport(Sc2Cam, CallingConvention = CallingConvention.StdCall)]
        public static extern int PCO_OpenCamera(ref IntPtr pHandle, UInt16 wCamNum);

        [DllImport(Sc2Cam, CallingConvention = CallingConvention.StdCall)]
        public static extern int PCO_OpenCameraEx(ref IntPtr pHandle, PCO_OpenStruct strOpen);

        [DllImport(Sc2Cam, CallingConvention = CallingConvention.StdCall)]
        public static extern int PCO_CloseCamera(IntPtr pHandle);

        [DllImport(Sc2Cam, CallingConvention = CallingConvention.StdCall)]
        public static extern int PCO_ResetLib();

        [DllImport(Sc2Cam, CallingConvention = CallingConvention.StdCall)]
        public static extern int PCO_GetCameraDescription(IntPtr pHandle, ref PCO_Description strDescription);

        // In C# it is hard to deal with pointer to structures with different sizes.
        // Thus it is easier to setup a similar function call for each available structure.
        [DllImport(Sc2Cam, CallingConvention = CallingConvention.StdCall)]
        public static extern int PCO_GetCameraDescriptionEx(IntPtr pHandle, ref PCO_Description strDescription, UInt16 wType);

        [DllImport(Sc2Cam, EntryPoint = "PCO_GetCameraDescriptionEx", CallingConvention = CallingConvention.StdCall)]
        public static extern int PCO_GetCameraDescriptionEx2(IntPtr pHandle, ref PCO_Description2 strDescription, UInt16 wType);

        [DllImport(Sc2Cam, CallingConvention = CallingConvention.StdCall)]
        public static extern int PCO_GetCameraHealthStatus(IntPtr pHandle, ref UInt32 dwWarn, ref UInt32 dwError, ref UInt32 dwStatus);

        [DllImport(Sc2Cam, CallingConvention = CallingConvention.StdCall)]
        public static extern int PCO_AllocateBuffer(IntPtr pHandle, ref short sBufNr, int size, ref UIntPtr wBuf, ref IntPtr hEvent);
        //HANDLE ph,SHORT* sBufNr,DWORD size,WORD** wBuf,HANDLE *hEvent

        [DllImport(Sc2Cam, CallingConvention = CallingConvention.StdCall)]
        public static extern int PCO_GetBuffer(IntPtr pHandle, short sBufNr, ref UIntPtr wBuf, ref IntPtr hEvent);

        [DllImport(Sc2Cam, CallingConvention = CallingConvention.StdCall)]
        public static extern int PCO_FreeBuffer(IntPtr pHandle, short sBufNr);

        [DllImport(Sc2Cam, CallingConvention = CallingConvention.StdCall)]
        public static extern int PCO_ArmCamera(IntPtr pHandle);

        [DllImport(Sc2Cam, CallingConvention = CallingConvention.StdCall)]
        public static extern int PCO_CamLinkSetImageParameters(IntPtr pHandle, UInt16 wXRes, UInt16 wYRes);

        [DllImport(Sc2Cam, CallingConvention = CallingConvention.StdCall)]
        public static extern int PCO_SetRecordingState(IntPtr pHandle, UInt16 wRecState);

        [DllImport(Sc2Cam, CallingConvention = CallingConvention.StdCall)]
        public static extern int PCO_GetRecordingState(IntPtr pHandle, ref UInt16 wRecState);

        [DllImport(Sc2Cam, CallingConvention = CallingConvention.StdCall)]
        public static extern int PCO_CancelImages(IntPtr pHandle);

        [DllImport(Sc2Cam, CallingConvention = CallingConvention.StdCall)]
        public static extern int PCO_AddBuffer(IntPtr pHandle, UInt32 dwFirstImage, UInt32 dwLastImage, short sBufNr);

        [DllImport(Sc2Cam, CallingConvention = CallingConvention.StdCall)]
        public static extern int PCO_AddBufferEx(IntPtr pHandle, UInt32 dwFirstImage, UInt32 dwLastImage, short sBufNr, UInt16 wXRes, UInt16 wYRes, UInt16 wBitPerPixel);

        [DllImport(Sc2Cam, CallingConvention = CallingConvention.StdCall)]
        public static extern int PCO_GetBufferStatus(IntPtr pHandle, short sBufNr, ref UInt32 dwStatusDll, ref UInt32 dwStatusDrv);

        [DllImport(Sc2Cam, CallingConvention = CallingConvention.StdCall)]
        public static extern int PCO_GetStorageStruct(IntPtr pHandle, ref PCO_Storage strStorage);

        [DllImport(Sc2Cam, CallingConvention = CallingConvention.StdCall)]
        public static extern int PCO_GetImageStruct(IntPtr pHandle, ref PCO_Image strImage);

        [DllImport(Sc2Cam, CallingConvention = CallingConvention.StdCall)]
        public static extern int PCO_GetCameraType(IntPtr pHandle, ref PCO_CameraType strCameraType);

        [DllImport(Sc2Cam, CallingConvention = CallingConvention.StdCall)]
        public static extern int PCO_GetCameraName(IntPtr pHandle, byte[] szCameraName, ushort wSZCameraNameLen);

        [DllImport(Sc2Cam, CallingConvention = CallingConvention.StdCall)]
        public static extern int PCO_SetTriggerMode(IntPtr pHandle, ushort wTriggerMode);

        [DllImport(Sc2Cam, CallingConvention = CallingConvention.StdCall)]
        public static extern int PCO_GetSizes(IntPtr pHandle,
                                  ref UInt16 wXResAct, // Actual X Resolution
                                  ref UInt16 wYResAct, // Actual Y Resolution
                                  ref UInt16 wXResMax, // Maximum X Resolution
                                  ref UInt16 wYResMax); // Maximum Y Resolution

        [DllImport(Sc2Cam, CallingConvention = CallingConvention.StdCall)]
        public static extern int PCO_GetTimestampMode(IntPtr pHandle, out ushort wTimeStampMode);

        [DllImport(Sc2Cam, CallingConvention = CallingConvention.StdCall)]
        public static extern int PCO_SetTimestampMode(IntPtr pHandle, ushort wTimeStampMode);

        [DllImport(Sc2Dlg, CallingConvention = CallingConvention.StdCall)]
        public static extern int PCO_OpenDialogCam(ref IntPtr hCamDialog, IntPtr pHandle, IntPtr parent, UInt32 uiFlags, UInt32 uiMsgArm, UInt32 uiMsgCtrl, int xpos, int ypos, [MarshalAs(UnmanagedType.LPStr)]string title);

        [DllImport(Sc2Dlg, CallingConvention = CallingConvention.StdCall)]
        public static extern int PCO_CloseDialogCam(IntPtr hCamDialog);

        [DllImport(Sc2Dlg, CallingConvention = CallingConvention.StdCall)]
        public static extern int PCO_EnableDialogCam(IntPtr hCamDialog, bool bEnable);
    };

}
