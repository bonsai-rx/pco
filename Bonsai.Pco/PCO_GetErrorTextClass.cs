using System;
using System.Collections.Generic;
using System.Text;

namespace Bonsai.Pco
{
    static class PCO_GetErrorTextClass
    {
        //========================================================================================================//
        // Commmon error messages                                                                                 //
        //========================================================================================================//

        static string[] PCO_ERROR_COMMON_TXT = new string[]
        {
          "No error.",                                     // 0x00000000  PCO_NOERROR
          "Function call with wrong parameter.",           // 0xA0000001  PCO_ERROR_WRONGVALUE 
          "Handle is invalid.",                            // 0xA0000002  PCO_ERROR_INVALIDHANDLE 
          "No memory available.",                          // 0xA0000003  PCO_ERROR_NOMEMORY 

          "A file handle could not be opened.",            // 0xA0000004  PCO_ERROR_NOFILE 
          "Timeout in function.",                          // 0xA0000005  PCO_ERROR_TIMEOUT 
          "A buffer is to small.",                         // 0xA0000006  PCO_ERROR_BUFFERSIZE
          "The called module is not initialized.",         // 0xA0000007  PCO_ERROR_NOTINIT
          "Disk full.",                                    // 0xA0000008  PCO_ERROR_DISKFULL
          "",                                              // 0xA0000009
          "Validation after programming camera failed.",   // 0xA0000010  PCO_ERROR_VALIDATION
          "Wrong library version.",                        // 0xA0000011  PCO_ERROR_LIBRARYVERSION
          "Wrong camera version",                          // 0xA0000012  PCO_ERROR_CAMERAVERSION
          "Option is not available"                        // 0xA0000013  PCO_ERROR_NOTAVAILABLE                      
        };

        static string[] PCO_ERROR_DRIVER_TXT = new string[]
        {
          "No error.",                                     // 0x00002000  PCO_NOERROR
          "Initialization failed; no camera connected.",   // 0x80002001  PCO_ERROR_DRIVER_NOTINIT     
          "",                                              // 0x80002002    
          "",                                              // 0x80002003  

          "",                                              // 0x80002004
          "Wrong driver for this OS.",                     // 0x80002005  PCO_ERROR_DRIVER_WRONGOS 
          "Open driver or driver class failed.",           // 0x80002006  PCO_ERROR_DRIVER_NODRIVER     
          "I/O operation failed.",                         // 0x80002007  PCO_ERROR_DRIVER_IOFAILURE     

          "Error in telegram checksum.",                   // 0x80002008  PCO_ERROR_DRIVER_CHECKSUMERROR     
          "Invalid Camera mode.",                          // 0x80002009  PCO_ERROR_DRIVER_INVMODE     
          "",                                              // 0x8000200A
          "Device is hold by an other process.",           // 0x8000200B  PCO_ERROR_DRIVER_DEVICEBUSY     

          "Error in reading or writing data to board.",    // 0x8000200C  PCO_ERROR_DRIVER_DATAERROR     
          "No function specified.",                        // 0x8000200D  PCO_ERROR_DRIVER_NOFUNCTION     
          "",                                              // 0x8000200E
          "",                                              // 0x8000200F

          "Buffer was cancelled.",                         // 0x80002010  PCO_ERROR_DRIVER_BUFFER_CANCELLED   

          "", "", "", "", "", "", "",                      // 0x80002011 - 0x80002017
          "", "", "", "", "", "", "", "",                  // 0x80002018 - 0x8000201F

          "A call to a windows-function fails.",           // 0x80002020  PCO_ERROR_DRIVER_SYSERR     
          "",                                              // 0x80002021    
          "Error in reading/writing to registry.",         // 0x80002022  PCO_ERROR_DRIVER_REGERR     
          "Need newer called vxd or dll.",                 // 0x80002023  PCO_ERROR_DRIVER_WRONGVERS   

          "Error while reading from file.",                // 0x80002024  PCO_ERROR_DRIVER_FILE_READ_ERR
          "Error while writing to file.",                  // 0x80002025  PCO_ERROR_DRIVER_FILE_WRITE_ERR
          "Camera and dll lut do not match.",              // 0x80002026  PCO_ERROR_DRIVER_LUT_MISMATCH
          "Grabber does not support the transfer format.", // 0x80002027  PCO_ERROR_DRIVER_FORMAT_NOT_SUPPORTED
          "Dmaerror not enough data transferred.",         // 0x80002028  PCO_ERROR_DRIVER_BUFFER_DMASIZE
          "Version information verify failed wrong typ id.",// 0x80002029  PCO_ERROR_DRIVER_WRONG_ATMEL_FOUND
          "Version information verify failed wrong size.", // 0x8000202A  PCO_ERROR_DRIVER_WRONG_ATMEL_SIZE
          "Version information verify failed wrong device id.",// 0x8000202B PCO_ERROR_DRIVER_WRONG_ATMEL_DEVICE
          "Board firmware not supported from this driver.",// 0x8000202C  PCO_ERROR_DRIVER_WRONG_BOARD
          "Board firmware verify failed.",                 // 0x8000202D  PCO_ERROR_DRIVER_READ_FLASH_FAILED
          "Camera head is not recognized correctly.",      // 0x8000202E  PCO_ERROR_DRIVER_HEAD_VERIFY_FAILED
          "Firmware does not support connected camera head.",// 0x8000202F PCO_ERROR_DRIVER_HEAD_BOARD_MISMATCH
          "Camera head is not connected.",                 // 0x80002030  PCO_ERROR_DRIVER_HEAD_LOST
          "Camera head power down.",                       // 0x80002031  PCO_ERROR_DRIVER_HEAD_POWER_DOWN
          "Camera busy.",                                   // 0x80002032  PCO_ERROR_DRIVER_CAMERA_BUSY
          "Camera busy (Buffers pending)."                 // 0x80002033  PCO_ERROR_DRIVER_BUFFERS_PENDING
        };

        //const int DRIVER_MSGNUM = sizeof(PCO_ERROR_DRIVER_TXT) / sizeof(PCO_ERROR_DRIVER_TXT[0]);


        //========================================================================================================//
        // Error messages for errors in SDK DLL                                                                   //
        //========================================================================================================//

        static string[] PCO_ERROR_SDKDLL_TXT = new string[]
        {
          "No error.",                                     // 0x00000000  PCO_NOERROR
          "wSize of an embedded buffer is to small.",      // 0x80003001  PCO_ERROR_SDKDLL_NESTEDBUFFERSIZE   
          "wSize of a buffer is to small.",                // 0x80003002  PCO_ERROR_SDKDLL_BUFFERSIZE   
          "A dialog is not available.",                    // 0x80003003  PCO_ERROR_SDKDLL_DIALOGNOTAVAILABLE   
          "Option is not available.",                      // 0x80003004  PCO_ERROR_SDKDLL_NOTAVAILABLE   
          "A call to a windows-function fails.",           // 0x80003005  PCO_ERROR_SDKDLL_INVALIDHANDLE 
          "Memory area is invalid.",                       // 0x80003006  PCO_ERROR_SDKDLL_BADMEMORY   
          "",                                              // 0x80003007    
          "Number of available buffers is exhausted.",     // 0x80003008  PCO_ERROR_SDKDLL_BUFCNTEXHAUSTED   
          "Dialog is already open.",                       // 0x80003009  PCO_ERROR_SDKDLL_ALREADYOPENED   
          "Error while destroying dialog.",                // 0x8000300A  PCO_ERROR_SDKDLL_ERRORDESTROYWND   
          "A requested buffer is not available.",          // 0x8000300B  PCO_ERROR_SDKDLL_BUFFERNOTVALID  
          "The buffer nr is out of range.",                // 0x8000300C  PCO_ERROR_SDKDLL_WRONGBUFFERNR
          "A DLL could not be found.",                     // 0x8000300D  PCO_ERROR_SDKDLL_DLLNOTFOUND  
          "Buffer already assigned to another buffernr.",  // 0x8000300E  PCO_ERROR_SDKDLL_BUFALREADYASSIGNED
          "Event already assigned to another buffernr.",   // 0x8000300F  PCO_ERROR_SDKDLL_EVENTALREADYASSIGNED
          "Recording must be active.",                     // 0x80003010 PCO_ERROR_SDKDLL_RECORDINGMUSTBEON
          "A DLL could not be found, due to div by zero.", // 0x80003011  PCO_ERROR_SDKDLL_DLLNOTFOUND_DIVZERO
          "Buffer is already queued.",                     // 0x80003012  PCO_ERROR_SDKDLL_BUFFERALREADYQUEUED
          "Buffer is not queued ."                         // 0x80003013  PCO_ERROR_SDKDLL_BUFFERNOTQUEUED
        };

        //const int SDKDLL_MSGNUM = sizeof(PCO_ERROR_SDKDLL_TXT) / sizeof(PCO_ERROR_SDKDLL_TXT[0]);


        //========================================================================================================//
        // Application error messages                                                                             //
        //========================================================================================================//

        static string[] PCO_ERROR_APPLICATION_TXT = new string[]
        {
          "No error.",                                     // 0x00000000  PCO_NOERROR
          "Error while waiting for a picture.",            // 0x80004001  PCO_ERROR_APPLICATION_PICTURETIMEOUT   
          "Error while saving file.",                      // 0x80004002  PCO_ERROR_APPLICATION_SAVEFILE 
          "A function inside a DLL could not be found.",   // 0x80004003  PCO_ERROR_APPLICATION_FUNCTIONNOTFOUND 

          "A DLL could not be found.",                     // 0x80004004  PCO_ERROR_APPLICATION_DLLNOTFOUND 
          "The board number is out of range.",             // 0x80004005  PCO_ERROR_APPLICATION_WRONGBOARDNR 
          "The decive does not support this function.",    // 0x80004006  PCO_ERROR_APPLICATION_FUNCTIONNOTSUPPORTED
          "Started Math with different resolution than reference.",// 0x80004007 PCO_ERROR_APPLICATION_WRONGRES
          "Disk full.",                                    // 0x80004008  PCO_ERROR_APPLICATION_DISKFULL
          "Error setting values to camera.",               // 0x80004009  PCO_ERROR_APPLICATION_SET_VALUES
        };

        //const int APPLICATION_MSGNUM = sizeof(PCO_ERROR_APPLICATION_TXT) / sizeof(PCO_ERROR_APPLICATION_TXT[0]);



        //========================================================================================================//
        // Firmware error messages                                                                                //
        //========================================================================================================//

        static string[] PCO_ERROR_FIRMWARE_TXT = new string[]
        {
          "No error.",                                     // 0x00000000  PCO_NOERROR
          "Timeout in telegram.",                          // 0x80001001  PCO_ERROR_FIRMWARE_TELETIMEOUT   
          "Wrong checksum in telegram.",                   // 0x80001002  PCO_ERROR_FIRMWARE_WRONGCHECKSUM   
          "No acknowledge.",                               // 0x80001003  PCO_ERROR_FIRMWARE_NOACK   

          "Wrong size in array.",                          // 0x80001004  PCO_ERROR_FIRMWARE_WRONGSIZEARR   
          "Data is inkonsistent.",                         // 0x80001005  PCO_ERROR_FIRMWARE_DATAINKONSISTENT   
          "Unknown command telegram.",                     // 0x80001006  PCO_ERROR_FIRMWARE_UNKNOWN_COMMAND
          "",                                              // 0x80001007  

          "FPGA init failed.",                             // 0x80001008  PCO_ERROR_FIRMWARE_INITFAILED   
          "FPGA configuration failed.",                    // 0x80001009  PCO_ERROR_FIRMWARE_CONFIGFAILED   
          "High temperature.",                             // 0x8000100A  PCO_ERROR_FIRMWARE_HIGH_TEMPERATURE
          "",                                              // 0x8000100B  

          "No response from I2C Device.",                  // 0x8000100C  PCO_ERROR_FIRMWARE_I2CNORESPONSE  
          "Checksum in code area is wrong.",               // 0x8000100D  PCO_ERROR_FIRMWARE_CHECKSUMCODEFAILED  
          "An address is out of range.",                   // 0x8000100E  PCO_ERROR_FIRMWARE_ADDRESSOUTOFRANGE  
          "No device is open for update.",                 // 0x8000100F  PCO_ERROR_FIRMWARE_NODEVICEOPENED  

          "The delivered buffer is to small.",             // 0x80001010  PCO_ERROR_FIRMWARE_BUFFERTOSMALL   
          "To much data delivered to function.",           // 0x80001011  PCO_ERROR_FIRMWARE_TOMUCHDATA   
          "Error while writing to camera.",                // 0x80001012  PCO_ERROR_FIRMWARE_WRITEERROR   
          "Error while reading from camera.",              // 0x80001013  PCO_ERROR_FIRMWARE_READERROR   

          "Was not able to render graph.",                 // 0x80001014  PCO_ERROR_FIRMWARE_NOTRENDERED   
          "The handle is not known.",                      // 0x80001015  PCO_ERROR_FIRMWARE_NOHANDLEAVAILABLE   
          "Value is out of allowed range.",                // 0x80001016  PCO_ERROR_FIRMWARE_DATAOUTOFRANGE   
          "Desired function not possible.",                // 0x80001017  PCO_ERROR_FIRMWARE_NOTPOSSIBLE   

          "SDRAM type read from SPD unknown.",             // 0x80001018  PCO_ERROR_FIRMWARE_UNSUPPORTED_SDRAM   
          "Different SDRAM modules mounted.",              // 0x80001019  PCO_ERROR_FIRMWARE_DIFFERENT_SDRAMS   
          "For CMOS sensor two modules needed.",           // 0x8000101A  PCO_ERROR_FIRMWARE_ONLY_ONE_SDRAM   
          "No SDRAM mounted.",                             // 0x8000101B  PCO_ERROR_FIRMWARE_NO_SDRAM_MOUNTED   

          "Segment size is too large.",                    // 0x8000101C  PCO_ERROR_FIRMWARE_SEGMENTS_TOO_LARGE   
          "Segment is out of range.",                      // 0x8000101D  PCO_ERROR_FIRMWARE_SEGMENT_OUT_OF_RANGE   
          "Value is out of range.",                        // 0x8000101E  PCO_ERROR_FIRMWARE_VALUE_OUT_OF_RANGE    
          "Image read not possible.",                      // 0x8000101F  PCO_ERROR_FIRMWARE_IMAGE_READ_NOT_POSSIBLE   

          "Command/data not supported by this hardware.",  // 0x80001020  PCO_ERROR_FIRMWARE_NOT_SUPPORTED            
          "Starting record failed due not armed.",         // 0x80001021  PCO_ERROR_FIRMWARE_ARM_NOT_SUCCESSFUL       
          "Arm is not possible while record active.",      // 0x80001022  PCO_ERROR_FIRMWARE_RECORD_MUST_BE_OFF       
          "",                                              // 0x80001023             

          "",                                              // 0x80001024  
          "Segment too small for image.",                  // 0x80001025  PCO_ERROR_FIRMWARE_SEGMENT_TOO_SMALL        
          "COC built is too large for internal memory.",   // 0x80001026  PCO_ERROR_FIRMWARE_COC_BUFFER_TO_SMALL      
          "COC has invalid data at fix position.",         // 0x80001027  PCO_ERROR_FIRMWARE_COC_DATAINKONSISTENT     

          "Correction data not valid.",                    // 0x80001028  PCO_ERROR_FIRMWARE_CORRECTION_DATA_INVALID
          "CCD calibration not finished.",                 // 0x80001029  PCO_ERROR_FIRMWARE_CCDCAL_NOT_FINISHED       
          "No new image transfer. Previous image pending.",// 0x8000102A  PCO_ERROR_FIRMWARE_IMAGE_TRANSFER_PENDING
          "",                                              // 0x8000102B  

          "",                                              // 0x8000102C        
          "",                                              // 0x8000102D  
          "",                                              // 0x8000102E  
          "",                                              // 0x8000102F  

          "COC Trigger setting invalid.",                  // 0x80001030  PCO_ERROR_FIRMWARE_COC_TRIGGER_INVALID 
          "COC PixelRate setting invalid.",                // 0x80001031  PCO_ERROR_FIRMWARE_COC_PIXELRATE_INVALID
          "COC Powerdown setting invalid.",                // 0x80001032  PCO_ERROR_FIRMWARE_COC_POWERDOWN_INVALID
          "COC Sensorformat setting invalid.",             // 0x80001033  PCO_ERROR_FIRMWARE_COC_SENSORFORMAT_INVALID
          "COC ROI to Binning setting invalid.",           // 0x80001034  PCO_ERROR_FIRMWARE_COC_ROI_BINNING_INVALID
          "COC ROI to Double setting invalid.",            // 0x80001035  PCO_ERROR_FIRMWARE_COC_ROI_DOUBLE_INVALID
          "COC Mode setting invalid.",                     // 0x80001036  PCO_ERROR_FIRMWARE_COC_MODE_INVALID
          "COC Delay setting invalid.",                    // 0x80001037  PCO_ERROR_FIRMWARE_COC_DELAY_INVALID
          "COC Exposure setting invalid.",                 // 0x80001038  PCO_ERROR_FIRMWARE_COC_EXPOS_INVALID
          "COC Timebase setting invalid.",                 // 0x80001039  PCO_ERROR_FIRMWARE_COC_TIMEBASE_INVALID
          "",                                              // 0x80001039
          "Interface settings are invalid.",               // 0x8000103B  PCO_ERROR_FIRMWARE_IF_SETTINGS_INVALID
          "ROI is not symmetrical.",                       // 0x8000103C  PCO_ERROR_FIRMWARE_ROI_NOT_SYMMETRICAL
          "ROI steps do not match.",                       // 0x8000103D  PCO_ERROR_FIRMWARE_ROI_STEPPING
          "ROI setting is wrong.",                         // 0x8000103E  PCO_ERROR_FIRMWARE_ROI_SETTING
          "",                                              // 0x8000103F

          "Firmware COC period is invalid.",               // 0x80001040  PCO_ERROR_FIRMWARE_COC_PERIOD_INVALID
          "Firmware COC monitor is invalid.",              // 0x80001041  PCO_ERROR_FIRMWARE_COC_MONITOR_INVALID
          "", "", "", "", "", "",                          // 0x80001042 - 0x80001047
          "", "", "", "", "", "", "", "",                  // 0x80001048 - 0x8000104F

          "Attempt to open unknown device for update.",    // 0x80001050  PCO_ERROR_FIRMWARE_UNKNOWN_DEVICE     
          "Attempt to open device not available.",         // 0x80001051  PCO_ERROR_FIRMWARE_DEVICE_NOT_AVAIL   
          "This or other device is already open.",         // 0x80001052  PCO_ERROR_FIRMWARE_OTHER_DEVICE_OPEN  
          "No device opened for update command.",          // 0x80001053  PCO_ERROR_FIRMWARE_NO_DEVICE_RESPONSE 

          "Device to open does not respond.",              // 0x80001054  PCO_ERROR_FIRMWARE_NO_DEVICE_RESPONSE 
          "Device to open is wrong device type.",          // 0x80001055  PCO_ERROR_FIRMWARE_WRONG_DEVICE_TYPE  
          "Erasing device flash/firmware failed.",         // 0x80001056  PCO_ERROR_FIRMWARE_ERASE_FLASH_FAILED 
          "Device to program is not blank.",               // 0x80001057  PCO_ERROR_FIRMWARE_DEVICE_NOT_BLANK   

          "Device address is out of range.",               // 0x80001058  PCO_ERROR_FIRMWARE_ADDRESS_OUT_OF_RANGE
          "Programming device flash/firmware failed.",     // 0x80001059  PCO_ERROR_FIRMWARE_PROG_FLASH_FAILED  
          "Programming device EEPROM failed.",             // 0x8000105A  PCO_ERROR_FIRMWARE_PROG_EEPROM_FAILED 
          "Reading device flash/firmware failed.",         // 0x8000105B  PCO_ERROR_FIRMWARE_READ_FLASH_FAILED  

          "Reading device EEPROM failed.",                 // 0x8000105C  PCO_ERROR_FIRMWARE_READ_EEPROM_FAILED 

          "", "", "",                                      // 0x8000105D - 0x8000105F
          "", "", "", "", "", "", "", "",                  // 0x80001060 - 0x80001067
          "", "", "", "", "", "", "", "",                  // 0x80001068 - 0x8000106F

          "", "", "", "", "", "", "", "",                  // 0x80001070 - 0x80001077
          "", "", "", "", "", "", "", "",                  // 0x80001078 - 0x8000107F

          "Command is invalid.",                           // 0x80001080  PCO_ERROR_FIRMWARE_GIGE_COMMAND_IS_INVALID
          "Camera UART not operational.",                  // 0x80001081  PCO_ERROR_FIRMWARE_GIGE_UART_NOT_OPERATIONAL         
          "Access denied. Debugging? See pco_err.h!",      // 0x80001082  PCO_ERROR_FIRMWARE_GIGE_ACCESS_DENIED                
          "Command unknown.",                              // 0x80001083  PCO_ERROR_FIRMWARE_GIGE_COMMAND_UNKNOWN              
          "Command group unknown.",                        // 0x80001084  PCO_ERROR_FIRMWARE_GIGE_COMMAND_GROUP_UNKNOWN        
          "Invalid command parameters.",                   // 0x80001085  PCO_ERROR_FIRMWARE_GIGE_INVALID_COMMAND_PARAMETERS   
          "Internal error.",                               // 0x80001086  PCO_ERROR_FIRMWARE_GIGE_INTERNAL_ERROR               
          "Interface blocked.",                            // 0x80001087  PCO_ERROR_FIRMWARE_GIGE_INTERFACE_BLOCKED            
          "Invalid session.",                              // 0x80001088  PCO_ERROR_FIRMWARE_GIGE_INVALID_SESSION              
          "Bad offset.",                                   // 0x80001089  PCO_ERROR_FIRMWARE_GIGE_BAD_OFFSET                   
          "NV write in progress.",                         // 0x8000108a  PCO_ERROR_FIRMWARE_GIGE_NV_WRITE_IN_PROGRESS         
          "Download block lost.",                          // 0x8000108b  PCO_ERROR_FIRMWARE_GIGE_DOWNLOAD_BLOCK_LOST          
          "Flash loader block invalid.",                   // 0x8000108c  PCO_ERROR_FIRMWARE_GIGE_DOWNLOAD_INVALID_LDR         
          "", "", "",                                      // 0x8000108D - 0x8000108F
          "Image packet lost.", 			                     // 0x080001090  PCO_ERROR_FIRMWARE_GIGE_DRIVER_IMG_PKT_LOST
          "GiGE Data bandwidth conflict.", 			           // 0x080001091  PCO_ERROR_FIRMWARE_GIGE_BANDWIDTH_CONFLICT

          "", "", "", "", "", "", "", "",                  // 0x80001092 - 0x80001099
          "", "", "", "", "", "",                          // 0x80001068 - 0x8000109F


          "External modulation frequency out of range.",   // 0x80001100  PCO_ERROR_FIRMWARE_FLICAM_EXT_MOD_OUT_OF_RANGE
          "Sync PLL not locked.",                          // 0x80001101  PCO_ERROR_FIRMWARE_FLICAM_SYNC_PLL_NOT_LOCKED
        };

        //const int FIRMWARE_MSGNUM = sizeof(PCO_ERROR_FIRMWARE_TXT) / sizeof(PCO_ERROR_FIRMWARE_TXT[0]);


        static string ERROR_CODE_OUTOFRANGE_TXT = "Error code out of range.";

        /////////////////////////////////////////////////////////////////////
        // end: error messages
        /////////////////////////////////////////////////////////////////////


        /////////////////////////////////////////////////////////////////////
        // warnings:
        /////////////////////////////////////////////////////////////////////

        static string[] PCO_ERROR_FWWARNING_TXT = new string[]
        {
          "No error.",
          "Function is already on.",                       // 0xC0001001 PCO_WARNING_FIRMWARE_FUNCALON     
          "Function is already off.",                      // 0xC0001002 PCO_WARNING_FIRMWARE_FUNCALOFF     
          "High temperature.",                             // 0xC0001003 PCO_WARNING_FIRMWARE_HIGH_TEMPERATURE
          "Offset regulation is not locked.",              // 0xC0001004 PCO_WARNING_FIRMWARE_OFFSET_NOT_LOCKED       
        };

        //const int FWWARNING_MSGNUM = sizeof(PCO_ERROR_FWWARNING_TXT) / sizeof(PCO_ERROR_FWWARNING_TXT[0]);

        static string[] PCO_ERROR_DRIVERWARNING_TXT = new string[]
        {
          "No error.",                                     // 0x00000000  PCO_NOERROR
        };

        //const int DRIVERWARNING_MSGNUM = sizeof(PCO_ERROR_DRIVERWARNING_TXT) / sizeof(PCO_ERROR_DRIVERWARNING_TXT[0]);


        static string[] PCO_ERROR_SDKDLLWARNING_TXT = new string[]
        {
            "No error.",                                     // 0x00000000  PCO_NOERROR
            "Buffers are still allocated.",                  // 0xC0003001  PCO_WARNING_SDKDLL_BUFFER_STILL_ALLOKATED
            "No Images are in the board buffer.",            // 0xC0003002  PCO_WARNING_SDKDLL_NO_IMAGE_BOARD
            "value change when testing COC.",                // 0xC0003003  PCO_WARNING_SDKDLL_COC_VALCHANGE
            "string buffer to short for replacement."        // 0xC0003004  PCO_WARNING_SDKDLL_COC_STR_SHORT
        };

        //const int SDKDLLWARNING_MSGNUM = sizeof(PCO_ERROR_SDKDLLWARNING_TXT) / sizeof(PCO_ERROR_SDKDLLWARNING_TXT[0]);

        static string[] PCO_ERROR_APPLICATIONWARNING_TXT = new string[]
        {
            "No error.",                                     // 0x00000000  PCO_NOERROR
            "Memory recorder buffer is full.",               // 0xC0004001  PCO_WARNING_APPLICATION_RECORDERFULL
            "Settings have been adapted to valid values."    // 0xC0004002  PCO_WARNING_APPLICATION_SETTINGSADAPTED
        };

        //const int APPLICATIONWARNING_MSGNUM = sizeof(PCO_ERROR_APPLICATIONWARNING_TXT) / sizeof(PCO_ERROR_APPLICATIONWARNING_TXT[0]);


        /////////////////////////////////////////////////////////////////////
        // end: warnings
        /////////////////////////////////////////////////////////////////////


        const UInt32 PCO_NOERROR = 0;
        // ====================================================================================================== //
        // -- 1. Masks for evaluating error layer, error device and error code: --------------------------------- //
        // ====================================================================================================== //
        const UInt32 PCO_ERROR_CODE_MASK = 0x00000FFF;    // in this bit range the error codes reside
        const UInt32 PCO_ERROR_LAYER_MASK = 0x0000F000;   // in this bit range the layer codes reside
        const UInt32 PCO_ERROR_DEVICE_MASK = 0x00FF0000;  // bit range for error devices / sources 
        const UInt32 PCO_ERROR_RESERVED_MASK = 0x1F000000;// reserved for future use
        const UInt32 PCO_ERROR_IS_COMMON = 0x20000000;    // indicates error message common to all layers
        const UInt32 PCO_ERROR_IS_WARNING = 0x40000000;   // indicates a warning
        const UInt32 PCO_ERROR_IS_ERROR = 0x80000000;     // indicates an error condition

        // ====================================================================================================== //
        // -- 2. Layer definitions: ----------------------------------------------------------------------------- //
        // ====================================================================================================== //
        const UInt32 PCO_ERROR_FIRMWARE = 0x00001000;     // error inside the firmware
        const UInt32 PCO_ERROR_DRIVER = 0x00002000;       // error inside the driver
        const UInt32 PCO_ERROR_SDKDLL = 0x00003000;       // error inside the SDK-dll
        const UInt32 PCO_ERROR_APPLICATION = 0x00004000;  // error inside the application

        // ====================================================================================================== //
        // -- 3.1 FIRMWARE error sources / devices: ------------------------------------------------------------- //
        // ====================================================================================================== //
        const UInt32 SC2_ERROR_POWER_CPLD = 0x00010000;   // error at CPLD in pco.power unit
        const UInt32 SC2_ERROR_HEAD_UP = 0x00020000;      // error at uP of head board in pco.camera
        const UInt32 SC2_ERROR_MAIN_UP = 0x00030000;      // error at uP of main board in pco.camera 
        const UInt32 SC2_ERROR_FWIRE_UP = 0x00040000;     // error at uP of firewire board in pco.camera 
        const UInt32 SC2_ERROR_MAIN_FPGA = 0x00050000;    // error at FPGA of main board in pco.camera 
        const UInt32 SC2_ERROR_HEAD_FPGA = 0x00060000;    // error at FGPA of head board in pco.camera 
        const UInt32 SC2_ERROR_MAIN_BOARD = 0x00070000;   // error at main board in pco.camera
        const UInt32 SC2_ERROR_HEAD_CPLD = 0x00080000;    // error at CPLD of head board in pco.camera
        const UInt32 SC2_ERROR_SENSOR = 0x00090000;       // error at image sensor (CCD or CMOS)
        const UInt32 SC2_ERROR_POWER = 0x000D0000;        // error within power unit
        const UInt32 SC2_ERROR_GIGE = 0x000E0000;         // error at uP of GigE board GigE firmware
        const UInt32 SC2_ERROR_USB = 0x000F0000;          // error at uP of GigE board USB firmware
        const UInt32 SC2_ERROR_BOOT_FPGA = 0x00100000;    // error at Boot FPGA in pco.camera 

        // ====================================================================================================== //
        // -- 3.2 DRIVER devices -------------------------------------------------------------------------------- //
        // ====================================================================================================== //
        const UInt32 PCO_ERROR_DRIVER_FIREWIRE = 0x00300000;// error inside the firewire driver
        const UInt32 PCO_ERROR_DRIVER_USB = 0x00310000;   // error inside the usb driver
        const UInt32 PCO_ERROR_DRIVER_GIGE = 0x00320000;  // error inside the GigE driver
        const UInt32 PCO_ERROR_DRIVER_CAMERALINK = 0x00330000;// error inside the CameraLink driver
        // obsolete (will be removed in a future release):
        // SC2_ERROR_DRIVER renamed to PCO_ERROR_DRIVER_xyz
        const UInt32 SC2_ERROR_DRIVER = 0x000B0000;       // error inside the driver
        // ====================================================================================================== //
        // -- 3.3 SDKDLL devices -------------------------------------------------------------------------------- //
        // ====================================================================================================== //
        const UInt32 PCO_ERROR_PCO_SDKDLL = 0x000A0000;   // error inside the camera sdk dll
        const UInt32 PCO_ERROR_CONVERTDLL = 0x00110000;   // error inside the convert dll
        const UInt32 PCO_ERROR_FILEDLL = 0x00120000;      // error inside the file dll
        const UInt32 PCO_ERROR_JAVANATIVEDLL = 0x00130000;// error inside a java native dll

        // ====================================================================================================== //
        // -- 3.4 Application devices --------------------------------------------------------------------------- //
        // ====================================================================================================== //
        const UInt32 PCO_ERROR_CAMWARE = 0x00100000;      // error in CamWare (also some kind of "device")

        public static void PCO_GetErrorText(UInt32 dwerr, ref string pbuf)
        {
            string layertxt;
            string errortxt;
            string devicetxt;
            string msg;
            UInt32 index;
            UInt32 device;
            UInt32 layer;

            if (dwerr == PCO_NOERROR)
            {
                pbuf = "No error.";
                return;
            }


            // -- evaluate device information within complete error code -- //
            // ------------------------------------------------------------ //

            device = dwerr & PCO_ERROR_DEVICE_MASK;
            layer = dwerr & PCO_ERROR_LAYER_MASK;

            // -- evaluate layer information within complete error code --- //
            // ------------------------------------------------------------ //

            switch (dwerr & PCO_ERROR_LAYER_MASK)   // evaluate layer
            {
                case PCO_ERROR_FIRMWARE:
                    {
                        layertxt = "Firmware";
                        switch (device)
                        {
                            case SC2_ERROR_POWER_CPLD: devicetxt = "SC2 Power CPLD"; break;
                            case SC2_ERROR_HEAD_UP: devicetxt = "SC2 Head uP"; break;
                            case SC2_ERROR_MAIN_UP: devicetxt = "SC2 Main uP"; break;
                            case SC2_ERROR_FWIRE_UP: devicetxt = "SC2 Firewire uP"; break;
                            case SC2_ERROR_MAIN_FPGA: devicetxt = "SC2 Main FPGA"; break;
                            case SC2_ERROR_HEAD_FPGA: devicetxt = "SC2 Head FPGA"; break;
                            case SC2_ERROR_MAIN_BOARD: devicetxt = "SC2 Main board"; break;
                            case SC2_ERROR_HEAD_CPLD: devicetxt = "SC2 Head CPLD"; break;
                            case SC2_ERROR_SENSOR: devicetxt = "SC2 Image sensor"; break;
                            case SC2_ERROR_POWER: devicetxt = "SC2 Power Unit"; break;
                            case SC2_ERROR_GIGE: devicetxt = "SC2 GigE board"; break;
                            case SC2_ERROR_USB: devicetxt = "SC2 GigE/USB board"; break;
                            case SC2_ERROR_BOOT_FPGA: devicetxt = "BOOT FPGA"; break;
                            default: devicetxt = "Unknown device"; break;
                        }
                        break;
                    }
                case PCO_ERROR_DRIVER:
                    {
                        layertxt = "Driver";
                        switch (device)
                        {
                            case SC2_ERROR_DRIVER: devicetxt = "pco.camera driver"; break;

                            case PCO_ERROR_DRIVER_FIREWIRE: devicetxt = "Firewire driver"; break;
                            case PCO_ERROR_DRIVER_USB: devicetxt = "Usb driver"; break;
                            case PCO_ERROR_DRIVER_GIGE: devicetxt = "GigE driver"; break;
                            case PCO_ERROR_DRIVER_CAMERALINK: devicetxt = "CameraLink driver"; break;
                            default: devicetxt = "Unknown device"; break;
                        }
                        break;
                    }
                case PCO_ERROR_SDKDLL:
                    {
                        layertxt = "SDK DLL";
                        switch (device)
                        {
                            case PCO_ERROR_PCO_SDKDLL: devicetxt = "camera sdk dll"; break;
                            case PCO_ERROR_CONVERTDLL: devicetxt = "convert dll"; break;
                            case PCO_ERROR_FILEDLL: devicetxt = "file dll"; break;
                            case PCO_ERROR_JAVANATIVEDLL: devicetxt = "java native dll"; break;
                            default: devicetxt = "Unknown device"; break;
                        }
                        break;
                    }
                case PCO_ERROR_APPLICATION:
                    {
                        layertxt = "Application";
                        switch (device)
                        {
                            case PCO_ERROR_CAMWARE: devicetxt = "CamWare"; break;
                            default: devicetxt = "Unknown device"; break;
                        }

                        break;
                    }
                default:
                    {
                        layertxt = "Undefined layer";
                        devicetxt = "Unknown device";
                        break;
                    }
            }


            // -- evaluate error information within complete error code --- //
            // ------------------------------------------------------------ //

            index = dwerr & PCO_ERROR_CODE_MASK;

            if ((dwerr & PCO_ERROR_IS_COMMON) > 0)
            {
                if (index < PCO_ERROR_COMMON_TXT.Length)
                    errortxt = PCO_ERROR_COMMON_TXT[index];
                else
                    errortxt = ERROR_CODE_OUTOFRANGE_TXT;
            }
            else
            {
                switch (dwerr & PCO_ERROR_LAYER_MASK)   // evaluate layer
                {
                    case PCO_ERROR_FIRMWARE:

                        if ((dwerr & PCO_ERROR_IS_WARNING) > 0)
                        {
                            if (index < PCO_ERROR_FWWARNING_TXT.Length)
                                errortxt = PCO_ERROR_FWWARNING_TXT[index];
                            else
                                errortxt = ERROR_CODE_OUTOFRANGE_TXT;
                        }
                        else
                        {
                            if (index < PCO_ERROR_FIRMWARE_TXT.Length)
                                errortxt = PCO_ERROR_FIRMWARE_TXT[index];
                            else
                                errortxt = ERROR_CODE_OUTOFRANGE_TXT;
                        }
                        break;


                    case PCO_ERROR_DRIVER:

                        if ((dwerr & PCO_ERROR_IS_WARNING) > 0)
                        {
                            if (index < PCO_ERROR_DRIVERWARNING_TXT.Length)
                                errortxt = PCO_ERROR_DRIVERWARNING_TXT[index];
                            else
                                errortxt = ERROR_CODE_OUTOFRANGE_TXT;
                        }
                        else
                        {
                            if (index < PCO_ERROR_DRIVER_TXT.Length)
                                errortxt = PCO_ERROR_DRIVER_TXT[index];
                            else
                                errortxt = ERROR_CODE_OUTOFRANGE_TXT;
                        }
                        break;


                    case PCO_ERROR_SDKDLL:

                        if ((dwerr & PCO_ERROR_IS_WARNING) > 0)
                        {
                            if (index < PCO_ERROR_SDKDLLWARNING_TXT.Length)
                                errortxt = PCO_ERROR_SDKDLLWARNING_TXT[index];
                            else
                                errortxt = ERROR_CODE_OUTOFRANGE_TXT;
                        }
                        else
                        {
                            if (index < PCO_ERROR_SDKDLL_TXT.Length)
                                errortxt = PCO_ERROR_SDKDLL_TXT[index];
                            else
                                errortxt = ERROR_CODE_OUTOFRANGE_TXT;
                        }
                        break;


                    case PCO_ERROR_APPLICATION:

                        if ((dwerr & PCO_ERROR_IS_WARNING) > 0)
                        {
                            if (index < PCO_ERROR_APPLICATIONWARNING_TXT.Length)
                                errortxt = PCO_ERROR_APPLICATIONWARNING_TXT[index];
                            else
                                errortxt = ERROR_CODE_OUTOFRANGE_TXT;
                        }
                        else
                        {
                            if (index < PCO_ERROR_APPLICATION_TXT.Length)
                                errortxt = PCO_ERROR_APPLICATION_TXT[index];
                            else
                                errortxt = ERROR_CODE_OUTOFRANGE_TXT;
                        }
                        break;


                    default:

                        errortxt = "No error text available!";
                        break;
                }
            }

            if ((dwerr & PCO_ERROR_IS_WARNING) > 0)
            {
                msg = layertxt;
                msg = String.Concat(msg, " warning 0x");
                msg = String.Concat(msg, dwerr.ToString("X"));
                msg = String.Concat(msg, " at device '");
                msg = String.Concat(msg, devicetxt);
                msg = String.Concat(msg, "': ");
                msg = String.Concat(msg, errortxt);
            }
            else
            {
                msg = layertxt;
                msg = String.Concat(msg, " error 0x");
                msg = String.Concat(msg, dwerr.ToString("X"));
                msg = String.Concat(msg, " at device '");
                msg = String.Concat(msg, devicetxt);
                msg = String.Concat(msg, "': ");
                msg = String.Concat(msg, errortxt);
            }

            pbuf = msg;

        }

    }
}
