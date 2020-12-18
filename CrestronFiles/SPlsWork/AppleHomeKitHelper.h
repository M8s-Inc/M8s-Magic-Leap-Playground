namespace AppleHomeKitHelper;
        // class declarations
         class AppleHomeKitSSharpComponent;
     class AppleHomeKitSSharpComponent 
    {
        // class delegates
        delegate FUNCTION DelegateFnString ( INTEGER myInt , SIMPLSHARPSTRING myString );
        delegate FUNCTION DelegateFnInteger ( INTEGER myInt );

        // class events

        // class functions
        FUNCTION Start ();
        FUNCTION UpButtonPressed ( SIGNED_LONG_INTEGER isPressed );
        FUNCTION DownButtonPressed ( SIGNED_LONG_INTEGER isPressed );
        FUNCTION LeftButtonPressed ( SIGNED_LONG_INTEGER isPressed );
        FUNCTION RightButtonPressed ( SIGNED_LONG_INTEGER isPressed );
        FUNCTION SelectButtonPressed ( SIGNED_LONG_INTEGER isPressed );
        FUNCTION MenuButtonPressed ( SIGNED_LONG_INTEGER isPressed );
        FUNCTION PlayPauseButtonPressed ( SIGNED_LONG_INTEGER isPressed );
        FUNCTION AudioInputButtonPressed ( SIGNED_LONG_INTEGER isPressed );
        FUNCTION HomeButtonPressed ( SIGNED_LONG_INTEGER isPressed );
        FUNCTION RestoreSettings ();
        FUNCTION SendVoiceData ( SIMPLSHARPSTRING data );
        FUNCTION SelectTarget ( SIGNED_LONG_INTEGER target );
        FUNCTION SendRemoteName ( SIMPLSHARPSTRING name );
        FUNCTION SendRemoteId ( SIGNED_LONG_INTEGER id );
        FUNCTION SendRemoteSerialNumber ( SIMPLSHARPSTRING serialnumber );
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        DelegateProperty DelegateFnString AppleTVNames;
        DelegateProperty DelegateFnInteger IsReadyDelegate;
        DelegateProperty DelegateFnInteger IdentifyRemoteDelegate;
        DelegateProperty DelegateFnInteger SelectedTargetDelegate;
    };

