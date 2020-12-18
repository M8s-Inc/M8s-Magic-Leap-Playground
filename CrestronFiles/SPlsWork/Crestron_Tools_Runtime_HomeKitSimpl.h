namespace Crestron.Tools.Runtime.HomeKitSimpl;
        // class declarations
         class SimplProvisioningHelper;
         class HomeKitAppleTvSimpl;
     class SimplProvisioningHelper 
    {
        // class delegates

        // class events

        // class functions
        FUNCTION RestoreFactoryDefault ();
        FUNCTION PauseBridgeServer ();
        FUNCTION ResumeBridgeServer ();
        FUNCTION IdentifyBridge ();
        FUNCTION Dispose ();
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
    };

     class HomeKitAppleTvSimpl 
    {
        // class delegates

        // class events

        // class functions
        FUNCTION Start ();
        FUNCTION SelectTarget ( SIGNED_LONG_INTEGER targetIndex );
        FUNCTION UpButton ( SIGNED_LONG_INTEGER isPressed );
        FUNCTION DownButton ( SIGNED_LONG_INTEGER isPressed );
        FUNCTION LeftButton ( SIGNED_LONG_INTEGER isPressed );
        FUNCTION RightButton ( SIGNED_LONG_INTEGER isPressed );
        FUNCTION SelectButton ( SIGNED_LONG_INTEGER isPressed );
        FUNCTION MenuButton ( SIGNED_LONG_INTEGER isPressed );
        FUNCTION TvHomeButton ( SIGNED_LONG_INTEGER isPressed );
        FUNCTION PlayPauseButton ( SIGNED_LONG_INTEGER isPressed );
        FUNCTION AudioInputButton ( SIGNED_LONG_INTEGER isPressed );
        FUNCTION SendVoiceData ( STRING dataAsString );
        FUNCTION SetOnlineStatus ( SIGNED_LONG_INTEGER isOnline );
        FUNCTION RestoreHomeKitSettings ();
        FUNCTION StopHomeKitRuntime ();
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        SIMPLSHARPSTRING RemoteName[];
        SIMPLSHARPSTRING RemoteSerialNumber[];
        SIGNED_LONG_INTEGER RemoteId;
    };

