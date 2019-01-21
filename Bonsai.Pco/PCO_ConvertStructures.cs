using System;
using System.Collections.Generic;
using System.Text;

//Added References For StructLayout

using System.Runtime.InteropServices;
//

namespace Bonsai.Pco
{
    static class PCO_ConvertStructures
    {
        public const int BAYER_UPPER_LEFT_IS_RED = 0x000000000;
        public const int BAYER_UPPER_LEFT_IS_GREEN_RED = 0x000000001;
        public const int BAYER_UPPER_LEFT_IS_GREEN_BLUE = 0x000000002;
        public const int BAYER_UPPER_LEFT_IS_BLUE = 0x000000003;

        [StructLayout(LayoutKind.Sequential)]
        public struct SRGBCOLCORRCOEFF
        {
            public double da11, da12, da13;
            public double da21, da22, da23;
            public double da31, da32, da33;
        }//sRGB_color_correction_coefficients


        [StructLayout(LayoutKind.Sequential)]
        public struct PCO_SensorInfo
        {
            public UInt16 wSize;
            public UInt16 wDummy;
            public Int32 iConversionFactor;              // Conversion factor of sensor in 1/100 e/count
            public Int32 iDataBits;                      // Bit resolution of sensor
            public Int32 iSensorInfoBits;                // Flags:
            // 0x00000001: Input is a color image (see Bayer struct!)
            // 0x00000002: Input is upper aligned
            public Int32 iDarkOffset;                    // Hardware dark offset
            public UInt32 dwzzDummy0;
            public SRGBCOLCORRCOEFF strColorCoeff;      // 9 double -> 18int // 24 int
            public Int32 iCamNum;                        // Camera number (enumeration of cameras controlled by app)
            public IntPtr hCamera;                      // Handle of the camera loaded, future use; set to zero.
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 38)]
            public UInt32[] dwzzDummy1;
        };

        [StructLayout(LayoutKind.Sequential)]
        public struct PCO_Display
        {
            public PCO_Display(int d)
            {
                wSize = 0;
                wDummy = 0;
                iScale_maxmax = 0;
                iScale_max = 0;
                iScale_min = 0;
                iColor_temp = 0;
                iColor_tint = 0;
                iColor_saturation = 0;
                iColor_vibrance = 0;
                iColor_vibrance = 0;
                iContrast = 0;
                iGamma = 0;
                iSRGB = 0;
                pucLut = IntPtr.Zero;
                dwzzDummy1 = new UInt32[52];
                for (int i = 0; i < 52; i++)
                    dwzzDummy1[i] = 0;
            }
            public UInt16 wSize;
            public UInt16 wDummy;
            public Int32 iScale_maxmax;// Maximum value for max 
            public Int32 iScale_min;   // Lowest value for processing
            public Int32 iScale_max;   // Highest value for processing
            public Int32 iColor_temp;  // Color temperature  3500...20000
            public Int32 iColor_tint;  // Color correction  -100...100 // 5 int
            public Int32 iColor_saturation; // Color saturation  -100...100
            public Int32 iColor_vibrance; // Color dynamic saturation  -100...100
            public Int32 iContrast;    // Contrast  -100...100
            public Int32 iGamma;       // Gamma  -100...100
            public Int32 iSRGB;				 // sRGB mode
            public IntPtr pucLut;       // Pointer to Lookup-Table // 10 int
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 52)]
            public UInt32[] dwzzDummy1;
        };

        [StructLayout(LayoutKind.Sequential)]
        public struct PCO_Bayer
        {
            public UInt16 wSize;
            public UInt16 wDummy;
            public Int32 iKernel;
            public Int32 iColorMode;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 61)]
            public UInt32[] dwzzDummy1;
        };

        [StructLayout(LayoutKind.Sequential)]
        public struct PCO_Filter
        {
            public UInt16 wSize;
            public UInt16 wDummy;
            public Int32 iMode;
            public Int32 iType;
            public Int32 iSharpen;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 60)]
            public UInt32[] dwzzDummy1;
        };

        [StructLayout(LayoutKind.Sequential)]
        public struct PCO_Convert
        {
            public UInt16 wSize;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public UInt16[] wDummy;
            public PCO_Display str_Display;     // Process settings for output image // 66 int
            public PCO_Bayer str_Bayer;       // Bayer processing settings // 130 int
            public PCO_Filter str_Filter;      // Filter processing settings // 198 int
            public PCO_SensorInfo str_SensorInfo;  // Sensor parameter // 258 int
            public Int32 iData_Bits_Out;

            public UInt32 dwModeBitsDataOut;
            public Int32 iGPU_Processing_mode;// Mode for processing: 0->CPU, 1->GPU // 261 int
            public Int32 iConvertType;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 58)]
            public UInt32[] dwzzDummy1;
        };

        public const int PCO_CNV_DLG_CMD_CLOSING = 0x0001; // Dialog is closing (bye, bye)
        public const int PCO_CNV_DLG_CMD_UPDATE = 0x0002; // Changed values in dialog
        public const int PCO_CNV_DLG_CMD_WHITEBALANCE = 0x0010; // White balance button pressed
        public const int PCO_CNV_DLG_CMD_MINMAX = 0x0011; // Minmax button pressed
        public const int PCO_CNV_DLG_CMD_MINMAXSMALL = 0x0012; // Minmax small button pressed
        [StructLayout(LayoutKind.Sequential)]
        public struct PCO_ConvDlg_Message
        {
            public UInt16 wCommand;              // Command sent to the main application
            public IntPtr pstrConvert;     // Pointer to the controlled PCO_Convert
            public Int32 iXPos;                  // Actual left position
            public Int32 iYPos;                  // Actual upper position
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
            public UInt32[] iReserved;           // Reserved for future use, set to zero.
        };

    }
}
