using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Bonsai.Pco
{
    static class PCO_Convert_LibWrapper
    {
        const string LibName = "PCO_Conv";

        #region Class Members
        public const int PCO_BW_CONVERT = 0;
        public const int PCO_COLOR_CONVERT = 2;
        public const int PCO_PSEUDO_CONVERT = 3;
        public const int PCO_COLOR16_CONVERT = 4;
        #endregion

        /**************************************************************************************************************************
         * PCO Convert Object API Calls
         * ***********************************************************************************************************************/
        #region PCO Convert Object API Calls

        // Creates a new convert object based on the PCO_SensorInfor structure. Convert structure handle will be used during conversion.
        // Call PCO_ConvertDelete to unload convert dll.
        // pHandle = Int handle to store the address of the created convert object
        // pSensorInfo = Pass by Ref SensorInfo structure
        // iConvertType = Int variable to determine the conversion type
        // returns Int error code value
        [DllImport(LibName, CallingConvention = CallingConvention.StdCall)]
        public static extern int PCO_ConvertCreate(ref IntPtr pHandle, ref PCO_ConvertStructures.PCO_SensorInfo pSensorInfo, int iConvertType);

        // Deletes a previously created convert object. Mandatory to call this before closing application
        // pHandle = Int handle to a previously created convert object
        // returns Int error code value
        [DllImport(LibName, CallingConvention = CallingConvention.StdCall)]
        public static extern int PCO_ConvertDelete(IntPtr pHandle);

        // Gets all the values of a previously created convert object
        // pHandle = Int handle to a previously created object
        // pConvert = Pass by Ref Convert structure
        // returns Int error code value
        [DllImport(LibName, CallingConvention = CallingConvention.StdCall)]
        public static extern int PCO_ConvertGet(IntPtr pHandle, ref PCO_ConvertStructures.PCO_Convert pConvert);

        #endregion


        [DllImport(LibName, CallingConvention = CallingConvention.StdCall)]
        public static extern int PCO_ConvertGetDisplay(IntPtr pHandle, ref PCO_ConvertStructures.PCO_Display pDisplay);


        [DllImport(LibName, CallingConvention = CallingConvention.StdCall)]
        public static extern int PCO_ConvertSetDisplay(IntPtr pHandle, ref PCO_ConvertStructures.PCO_Display pDisplay);

        // Converts the camera raw 16 bit data to 8 bit b/w format
        // pHandle = Handle to a previously created convert object
        // imode = Mode parameter
        // icolormode = Color mode parameter
        // width = Width of the image to convert
        // height = Height of the image to convert
        // rawImagePointer = Pointer to the raw image
        // resultingImagePointer = Pointer to allocated memory to store the resulting image
        // returns Int error code value
        [DllImport(LibName, CallingConvention = CallingConvention.StdCall)]
        public static extern int PCO_Convert16TO8(IntPtr pHandle, int imode, int icolormode, int width, int height, UIntPtr rawImagePointer, byte[] resultingImagePointer);

        [DllImport(LibName, CallingConvention = CallingConvention.StdCall)]
        public static extern int PCO_Convert16TOCOL(IntPtr pHandle, int imode, int icolormode, int width, int height, UIntPtr rawImagePointer, byte[] resultingImagePointer);

        // Sets the PCO_SensorInfo structure for a previously created convert object
        // pHandle = Handle to a previously created convert object
        // pSensorInfo = Pass by Ref Sensor information structure. Do not forget to set pSensorInfo.wSize
        // returns Int error code value
        [DllImport(LibName, CallingConvention = CallingConvention.StdCall)]
        public static extern int PCO_ConvertSetSensorInfo(IntPtr pHandle, ref PCO_ConvertStructures.PCO_SensorInfo pSensorInfo);

        [DllImport(LibName, CallingConvention = CallingConvention.StdCall)]
        public static extern int PCO_OpenConvertDialog(ref IntPtr hLutDialog, IntPtr parent, [MarshalAs(UnmanagedType.LPStr)]string title, int msg_id, IntPtr hlut, int xpos, int ypos);

        [DllImport(LibName, CallingConvention = CallingConvention.StdCall)]
        public static extern int PCO_CloseConvertDialog(IntPtr hLutDialog);

        // Sets the converted and raw image data to the convert dialog. This will update the histogram diagrams shown in the dialog
        // hLutDialog = Handle of a previously created dialog
        // ixres = Width of the image data transferred
        // iyres = Height of the image data transferred
        // b16_image = Pointer to the raw data
        // rgb_image = Pointer to the converted data
        // returns Int error code value
        [DllImport(LibName, CallingConvention = CallingConvention.StdCall)]
        public static extern int PCO_SetDataToDialog(IntPtr hLutDialog, int ixres, int iyres, UIntPtr b16Image, byte[] rgbImage);

        [DllImport(LibName, CallingConvention = CallingConvention.StdCall)]
        public static extern int PCO_SetConvertDialog(IntPtr hLutDialog, IntPtr hLut);

        [DllImport(LibName, CallingConvention = CallingConvention.StdCall)]
        public static extern int PCO_GetConvertDialog(IntPtr hLutDialog, IntPtr hLut);
    }
}