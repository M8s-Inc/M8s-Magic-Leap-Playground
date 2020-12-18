namespace Ultamation.SimplSharp.AppleTvClient;
        // class declarations
         class AppleTvClient;
     class AppleTvClient 
    {
        // class delegates
        delegate FUNCTION UShortDelegate ( INTEGER val );
        delegate FUNCTION NakedDelegate ( );

        // class events

        // class functions
        FUNCTION Initialise ( SIMPLSHARPSTRING atvName );
        FUNCTION Up ();
        FUNCTION Down ();
        FUNCTION Left ();
        FUNCTION Right ();
        FUNCTION Select ();
        FUNCTION UpRelease ();
        FUNCTION DownRelease ();
        FUNCTION LeftRelease ();
        FUNCTION RightRelease ();
        FUNCTION SelectRelease ();
        FUNCTION Menu ();
        FUNCTION ContextMenu ();
        FUNCTION TopMenu ();
        FUNCTION PlayPause ();
        FUNCTION Play ();
        FUNCTION Pause ();
        FUNCTION Stop ();
        FUNCTION Rewind ();
        FUNCTION Forward ();
        FUNCTION Next ();
        FUNCTION Previous ();
        FUNCTION PositionSet ( INTEGER pos );
        FUNCTION GestureDown ( INTEGER x , INTEGER y );
        FUNCTION GestureMove ( INTEGER x , INTEGER y );
        FUNCTION GestureUp ( INTEGER x , INTEGER y );
        FUNCTION KeyboardEnter ();
        FUNCTION KeyboardBack ();
        FUNCTION KeyboardClear ();
        FUNCTION KeyboardTextMessage ( SIMPLSHARPSTRING KeyboardText );
        FUNCTION PollPlayerStatus ();
        FUNCTION GenericHid ( INTEGER page , INTEGER key , INTEGER press );
        FUNCTION SubscribeTo ( INTEGER artwork , INTEGER player , INTEGER volume , INTEGER keyboard );
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING Title[];
        STRING Album[];
        STRING Artist[];
        STRING RadioStation[];
        INTEGER Duration;
        INTEGER ElapsedTime;
        INTEGER PlayingState;
        INTEGER Position;
        INTEGER VerifiedSPLUS;
        INTEGER KeyboardActiveSPlus;
        STRING InputText[];
        INTEGER InGameMode;
        STRING IpAddress[];
        INTEGER Port;
        DelegateProperty UShortDelegate UpdateSocketStatus;
        DelegateProperty NakedDelegate UpdatePairingStatus;
        DelegateProperty NakedDelegate UpdatePlayerStatus;
        DelegateProperty NakedDelegate UpdateVolumeStatus;
        DelegateProperty NakedDelegate UpdateKeyboardStatus;
        INTEGER ConfigLoaded;
        INTEGER LicenceOk;
    };

namespace Ultamation.SimplSharp.MediaRemote;
        // class declarations
         class ProtobufException;

namespace Ultamation.SimplSharp.MediaRemote.Serialisation;
        // class declarations
         class AppleTvCommissioningToolConfig;
         class AppleTvCommissioningToolDevice;
     class AppleTvCommissioningToolConfig 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING ControlSystemGuid[];
        STRING ControlSystemSerialNumber[];
        STRING ControlSystemTouchSettableId[];
        STRING ControlSystemPrivateKey[];
    };

     class AppleTvCommissioningToolDevice 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING Name[];
        STRING AtvUniqueIdentifier[];
        STRING AtvPairingIdentifier[];
        STRING AtvPublicKey[];
        STRING LicenceKey[];
    };

namespace ultamr;
        // class declarations

