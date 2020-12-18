namespace Crestron.Tools.Runtime.HomeKit.Tokens.Mocks;
        // class declarations
         class TokenRecord;

namespace Crestron.Tools.Runtime.HomeKit.Devices.Remote;
        // class declarations
         class HomeKitRemoteTargetButton;
         class RemoteTargetButtonDTO;
         class HomeKitRemoteTarget;
           class HomeKitRemoteButton;
     class RemoteTargetButtonDTO 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        HomeKitRemoteButton Type;
        STRING Name[];
    };

namespace Crestron.Tools.Runtime.HomeKit.Common;
        // class declarations
         class LogEntryLevel;
         class Logger;
    static class LogEntryLevel // enum
    {
        static SIGNED_LONG_INTEGER Off;
        static SIGNED_LONG_INTEGER Error;
        static SIGNED_LONG_INTEGER Warning;
        static SIGNED_LONG_INTEGER Info;
        static SIGNED_LONG_INTEGER Normal;
        static SIGNED_LONG_INTEGER Debug;
        static SIGNED_LONG_INTEGER Trace;
    };

    static class Logger 
    {
        // class delegates

        // class events

        // class functions
        static FUNCTION Log ( LogEntryLevel level , STRING message );
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
    };

namespace Crestron.Tools.Runtime.HomeKit.HomeKitCore.Bridge;
        // class declarations
         class HKServerMessageType;
         class HKInterfaceErrors;
         class HKServerErrors;
         class HKAccessoryType;
         class HKRemoteCharacteristics;
         class HKRemoteButtonTypes;
         class HKRemoteTargetCategory;
         class HKLightbulbCharacteristics;
         class HKOutletCharacteristics;
         class HKSwitchCharacteristics;
         class HKThermostatCharacteristics;
         class HKRemoteType;
    static class HKServerMessageType // enum
    {
        static SIGNED_LONG_INTEGER HKServer_Invalid_Message;
        static SIGNED_LONG_INTEGER HKServer_Pause_Response;
        static SIGNED_LONG_INTEGER HKServer_Resume_Response;
        static SIGNED_LONG_INTEGER HKServer_Register_Response;
        static SIGNED_LONG_INTEGER HKServer_Unregister_Response;
        static SIGNED_LONG_INTEGER HKServer_Write;
        static SIGNED_LONG_INTEGER HKServer_Read;
        static SIGNED_LONG_INTEGER HKServer_Identify;
        static SIGNED_LONG_INTEGER HKServer_Update_Characteristic_Response;
        static SIGNED_LONG_INTEGER HKServer_Restore_Response;
        static SIGNED_LONG_INTEGER HKServer_Is_Provisioned_Response;
        static SIGNED_LONG_INTEGER HKServer_Update_MFi_UUID_Response;
        static SIGNED_LONG_INTEGER HKServer_Update_MFi_Token_Response;
        static SIGNED_LONG_INTEGER HKServer_Is_Paired_Response;
        static SIGNED_LONG_INTEGER HKServer_Set_Name_Response;
        static SIGNED_LONG_INTEGER HKServer_Set_Manufacturer_Response;
        static SIGNED_LONG_INTEGER HKServer_Set_Model_Response;
        static SIGNED_LONG_INTEGER HKServer_Set_SerialNumber_Response;
        static SIGNED_LONG_INTEGER HKServer_Set_FirmwareVersion_Response;
        static SIGNED_LONG_INTEGER HKServer_Set_HardwareVersion_Response;
        static SIGNED_LONG_INTEGER HKServer_Update_Setup_Info_Response;
        static SIGNED_LONG_INTEGER HKServer_Dummy_Message;
        static SIGNED_LONG_INTEGER HKServer_Is_Setup_Info_Stored_Response;
        static SIGNED_LONG_INTEGER HKServer_Set_Online_Status_Response;
        static SIGNED_LONG_INTEGER HKServer_Wipe_Factory_Provision_Response;
    };

    static class HKInterfaceErrors // enum
    {
        static SIGNED_LONG_INTEGER HKIFError_None;
        static SIGNED_LONG_INTEGER HKIFError_Unknown;
        static SIGNED_LONG_INTEGER HKIFError_Invalid_Parameter;
        static SIGNED_LONG_INTEGER HKIFError_Timed_Out;
        static SIGNED_LONG_INTEGER HKIFError_Invalid_Server_Message;
        static SIGNED_LONG_INTEGER HKIFError_Accessory_ID_Mismatch;
        static SIGNED_LONG_INTEGER HKIFError_Last_Message_Not_Handled;
        static SIGNED_LONG_INTEGER HKIFError_No_More_Data_Available;
        static SIGNED_LONG_INTEGER HKIFError_Characteristic_ID_Mismatch;
    };

    static class HKServerErrors // enum
    {
        static SIGNED_LONG_INTEGER HKServerError_None;
        static SIGNED_LONG_INTEGER HKServerError_Unknown;
        static SIGNED_LONG_INTEGER HKServerError_Invalid_Parameter;
        static SIGNED_LONG_INTEGER HKServerError_Operation_Not_Allowed;
        static SIGNED_LONG_INTEGER HKServerError_Accessory_Not_Registered;
        static SIGNED_LONG_INTEGER HKServerError_Bridged_Accessory_Offline;
        static SIGNED_LONG_INTEGER HKServerError_Bridged_Accessory_Malfunction;
        static SIGNED_LONG_INTEGER HKServerError_Characteristic_Not_Supported;
        static SIGNED_LONG_INTEGER HKServerError_Service_Type_Mismatch;
        static SIGNED_LONG_INTEGER HKServerError_Service_Not_Supported;
        static SIGNED_LONG_INTEGER HKServerError_Out_Of_Memory;
        static SIGNED_LONG_INTEGER HKServerError_Not_Implemented;
    };

    static class HKAccessoryType // enum
    {
        static SIGNED_LONG_INTEGER HKAccessory_Invalid;
        static SIGNED_LONG_INTEGER HKAccessory_Remote_Control;
        static SIGNED_LONG_INTEGER HKAccessory_Lightbulb;
        static SIGNED_LONG_INTEGER HKAccessory_Thermostat;
        static SIGNED_LONG_INTEGER HKAccessory_Motion_Sensor;
    };

    static class HKRemoteCharacteristics // enum
    {
        static SIGNED_LONG_INTEGER HKRemoteChar_Invalid;
        static SIGNED_LONG_INTEGER HKRemoteChar_Maximum_Targets;
        static SIGNED_LONG_INTEGER HKRemoteChar_Number_Of_Buttons;
        static SIGNED_LONG_INTEGER HKRemoteChar_Button_Type;
        static SIGNED_LONG_INTEGER HKRemoteChar_Select_Target;
        static SIGNED_LONG_INTEGER HKRemoteChar_Target_Configuration;
        static SIGNED_LONG_INTEGER HKRemoteChar_Reset_Target;
        static SIGNED_LONG_INTEGER HKRemoteChar_Button_Event;
        static SIGNED_LONG_INTEGER HKRemoteChar_Voice_Data;
        static SIGNED_LONG_INTEGER HKRemoteChar_Active_Status;
        static SIGNED_LONG_INTEGER HKRemoteChar_Type;
        static SIGNED_LONG_INTEGER HKRemoteChar_Button_Configuration;
    };

    static class HKRemoteButtonTypes // enum
    {
        static SIGNED_LONG_INTEGER HKRemoteButtonType_Invalid;
        static SIGNED_LONG_INTEGER HKRemoteButtonType_Menu;
        static SIGNED_LONG_INTEGER HKRemoteButtonType_Play_Pause;
        static SIGNED_LONG_INTEGER HKRemoteButtonType_TV_Home;
        static SIGNED_LONG_INTEGER HKRemoteButtonType_Select;
        static SIGNED_LONG_INTEGER HKRemoteButtonType_Arrow_Up;
        static SIGNED_LONG_INTEGER HKRemoteButtonType_Arrow_Right;
        static SIGNED_LONG_INTEGER HKRemoteButtonType_Arrow_Down;
        static SIGNED_LONG_INTEGER HKRemoteButtonType_Arrow_Left;
        static SIGNED_LONG_INTEGER HKRemoteButtonType_Volume_Up;
        static SIGNED_LONG_INTEGER HKRemoteButtonType_Volume_Down;
        static SIGNED_LONG_INTEGER HKRemoteButtonType_Audio_Input;
        static SIGNED_LONG_INTEGER HKRemoteButtonType_Power;
        static SIGNED_LONG_INTEGER HKRemoteButtonType_Generic;
    };

    static class HKRemoteTargetCategory // enum
    {
        static LONG_INTEGER Undefined;
        static LONG_INTEGER AppleTv;
    };

    static class HKLightbulbCharacteristics // enum
    {
        static SIGNED_LONG_INTEGER HKLightbulbChar_Invalid;
        static SIGNED_LONG_INTEGER HKLightbulbChar_On;
        static SIGNED_LONG_INTEGER HKLightbulbChar_Brightness;
        static SIGNED_LONG_INTEGER HKLightbulbChar_Hue;
        static SIGNED_LONG_INTEGER HKLightbulbChar_Name;
        static SIGNED_LONG_INTEGER HKLightbulbChar_Saturation;
        static SIGNED_LONG_INTEGER HKLightbulbChar_ColorTemperature;
    };

    static class HKOutletCharacteristics // enum
    {
        static SIGNED_LONG_INTEGER HKOutletChar_Invalid;
        static SIGNED_LONG_INTEGER HKOutletChar_On;
        static SIGNED_LONG_INTEGER HKOutletChar_In_Use;
        static SIGNED_LONG_INTEGER HKOutletChar_Name;
    };

    static class HKSwitchCharacteristics // enum
    {
        static SIGNED_LONG_INTEGER HKSwitchChar_Invalid;
        static SIGNED_LONG_INTEGER HKSwitchChar_On;
        static SIGNED_LONG_INTEGER HKSwitchChar_Name;
    };

    static class HKThermostatCharacteristics // enum
    {
        static SIGNED_LONG_INTEGER HKThermostatChar_Invalid;
        static SIGNED_LONG_INTEGER HKThermostatChar_Current_Heating_Cooling_State;
        static SIGNED_LONG_INTEGER HKThermostatChar_Target_Heating_Cooling_State;
        static SIGNED_LONG_INTEGER HKThermostatChar_Current_Temperature;
        static SIGNED_LONG_INTEGER HKThermostatChar_Target_Temperature;
        static SIGNED_LONG_INTEGER HKThermostatChar_Temperature_Display_Units;
        static SIGNED_LONG_INTEGER HKThermostatChar_Cooling_Threshold_Temperature;
        static SIGNED_LONG_INTEGER HKThermostatChar_Heating_Threshold_Temperature;
    };

    static class HKRemoteType // enum
    {
        static SIGNED_LONG_INTEGER Software;
        static SIGNED_LONG_INTEGER HardwareWithAudioInput;
        static SIGNED_LONG_INTEGER HardwareWithoutAudioInput;
    };

namespace Crestron.Tools.Runtime.HomeKit.Tokens;
        // class declarations
         class StoredTokenState;
         class TokenAcquiredEventArgs;
         class SetupCodeAcquiredEventArgs;
     class StoredTokenState 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING Uuid[];
        STRING AcknowledgeCode[];
    };

     class TokenAcquiredEventArgs 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
    };

namespace Crestron.Tools.Runtime.HomeKit.Devices.Events;
        // class declarations
         class IsReadyEventArgs;
         class HomeKitRemoteTargetsArgs;
         class RegisterCompleteArgs;
     class IsReadyEventArgs 
    {
        // class delegates

        // class events

        // class functions
        FUNCTION Pool ();
        FUNCTION InitializeItem ();
        FUNCTION Dispose ();
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
    };

     class HomeKitRemoteTargetsArgs 
    {
        // class delegates

        // class events

        // class functions
        FUNCTION Pool ();
        FUNCTION InitializeItem ();
        FUNCTION Dispose ();
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
    };

     class RegisterCompleteArgs 
    {
        // class delegates

        // class events

        // class functions
        FUNCTION Pool ();
        FUNCTION InitializeItem ();
        FUNCTION Dispose ();
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
    };

namespace Crestron.Tools.Runtime.HomeKit.Devices;
        // class declarations
         class HomeKitDeviceType;
         class HomeKitRemoteButton;
         class HomeKitRemoteTargetType;
         class HomeKitRemoteType;
    static class HomeKitDeviceType // enum
    {
        static SIGNED_LONG_INTEGER None;
        static SIGNED_LONG_INTEGER Remote;
    };

    static class HomeKitRemoteButton // enum
    {
        static SIGNED_LONG_INTEGER None;
        static SIGNED_LONG_INTEGER Menu;
        static SIGNED_LONG_INTEGER PlayPause;
        static SIGNED_LONG_INTEGER TvHome;
        static SIGNED_LONG_INTEGER Select;
        static SIGNED_LONG_INTEGER ArrowUp;
        static SIGNED_LONG_INTEGER ArrowRight;
        static SIGNED_LONG_INTEGER ArrowDown;
        static SIGNED_LONG_INTEGER ArrowLeft;
        static SIGNED_LONG_INTEGER VolumeUp;
        static SIGNED_LONG_INTEGER VolumeDown;
        static SIGNED_LONG_INTEGER AudioInput;
        static SIGNED_LONG_INTEGER Power;
        static SIGNED_LONG_INTEGER Generic;
    };

    static class HomeKitRemoteTargetType // enum
    {
        static SIGNED_LONG_INTEGER None;
        static SIGNED_LONG_INTEGER AppleTv;
    };

    static class HomeKitRemoteType // enum
    {
        static SIGNED_LONG_INTEGER Software;
        static SIGNED_LONG_INTEGER Hardware;
    };

namespace Crestron.Tools.Runtime.HomeKit;
        // class declarations
         class HomeKitRuntime;
         class HomeKitBridgePairingStatus;
           class HomeKitBridgePairingStatusArgs;
     class HomeKitRuntime 
    {
        // class delegates

        // class events
        EventHandler IsReadyChanged ( HomeKitRuntime sender, EventArgs e );
        EventHandler PairingStatusChanged ( HomeKitRuntime sender, HomeKitBridgePairingStatusArgs e );

        // class functions
        FUNCTION Dispose ();
        FUNCTION RestoreFactoryDefault ();
        FUNCTION WipeFactoryProvisionData ();
        STRING_FUNCTION ProvisionAndGetSetupCode ();
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        HomeKitBridgePairingStatus PairingStatus;
    };

    static class HomeKitBridgePairingStatus // enum
    {
        static SIGNED_LONG_INTEGER None;
        static SIGNED_LONG_INTEGER NotPaired;
        static SIGNED_LONG_INTEGER PairedNotConnected;
        static SIGNED_LONG_INTEGER Paired;
    };

namespace Crestron.Tools.Runtime.HomeKit.Events;
        // class declarations
         class HomeKitBridgePairingStatusArgs;
     class HomeKitBridgePairingStatusArgs 
    {
        // class delegates

        // class events

        // class functions
        FUNCTION Pool ();
        FUNCTION InitializeItem ();
        FUNCTION Dispose ();
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        HomeKitBridgePairingStatus State;
    };

