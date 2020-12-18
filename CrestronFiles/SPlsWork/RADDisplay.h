namespace Crestron.RAD.DeviceTypes.Display;
        // class declarations
         class Power;
         class Input;
         class Audio;
         class Connection;
         class EnergyStar;
         class VideoMute;
         class Projector;
         class ADisplayProtocol;
         class DataValidation;
         class DisplayStandardCommands;
         class DeviceSupportConverter;
         class SimplDisplay;
         class ABasicVideoDisplay;
         class DisplayRootObject;
         class CrestronSerialDeviceApi;
         class Api;
         class Feedback;
         class SupportedFeatureEnum;
         class PowerFeedback;
         class MuteFeedback;
         class VolumeFeedback;
         class InputFeedback;
         class InputFeedbackValues;
         class EnergyStarFeedback;
         class OnScreenDisplayFeedback;
         class VideoMuteFeedback;
         class LampHourFeedback;
         class ExtensionMethods;
         class ResponseValidation;
     class Power 
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

     class Input 
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

     class Audio 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        LONG_INTEGER VolumeIs;
    };

     class Connection 
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

     class EnergyStar 
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

     class VideoMute 
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

     class Projector 
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

     class DataValidation 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        Feedback Feedback;
        PowerFeedback PowerFeedback;
        MuteFeedback MuteFeedback;
        InputFeedback InputFeedback;
        VolumeFeedback VolumeFeedback;
        EnergyStarFeedback EnergyStarFeedback;
        LampHourFeedback LampHourFeedback;
        VideoMuteFeedback VideoMuteFeedback;
        STRING AckDefinition[];
        STRING NakDefinition[];
    };

    static class DisplayStandardCommands 
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

     class DeviceSupportConverter 
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

     class SimplDisplay 
    {
        // class delegates
        delegate FUNCTION BasicInformationDelegate ( SIMPLSHARPSTRING sdkVersion , SIMPLSHARPSTRING manufacturer , SIMPLSHARPSTRING baseModel , SIMPLSHARPSTRING supportedModels , SIMPLSHARPSTRING supportedSeries , SIMPLSHARPSTRING description , SIMPLSHARPSTRING driverVersion , SIMPLSHARPSTRING driverVersionDate , SIMPLSHARPSTRING guid , INTEGER supportsFeedback );
        delegate FUNCTION TxUpdatedDelegate ( SIMPLSHARPSTRING message );
        delegate FUNCTION PacketTxUpdatedDelegate ( SIMPLSHARPSTRING message );
        delegate FUNCTION LogDelegate ( SIMPLSHARPSTRING logMessage );
        delegate FUNCTION RxOutDelegate ( SIMPLSHARPSTRING message );
        delegate FUNCTION BasicConnectionSupportsDelegate ( INTEGER disconnect , INTEGER reconnect );
        delegate FUNCTION CustomIrCommandSupportsDelegate ( );
        delegate FUNCTION DriverLoadedDelegate ( INTEGER loaded , INTEGER port , INTEGER rebootRequired );
        delegate FUNCTION DriverAuthenticationSupportsDelegate ( INTEGER supportsUserName , INTEGER supportsPassword , INTEGER isRequired );
        delegate FUNCTION DriverAuthenticationUpdateDelegate ( INTEGER authStatus );
        delegate FUNCTION DriverCustomCommandDelegate ( );
        delegate FUNCTION DisplayStatusDelegate ( INTEGER power , INTEGER warmingUp , INTEGER coolingDown , INTEGER inputType , SIMPLSHARPSTRING inputConnector , SIMPLSHARPSTRING inputDescription , INTEGER volume , INTEGER mute , INTEGER connectionStatus , INTEGER videoMute );
        delegate FUNCTION PowerSupportsDelegate ( INTEGER discretePower , INTEGER togglePower , INTEGER powerFeedback , INTEGER warmUpTime , INTEGER coolDownTime , INTEGER warpUpTimeValue , INTEGER coolDownTimeValue );
        delegate FUNCTION InputsSupportsDelegate ( INTEGER setInput , INTEGER inputFeedback );
        delegate FUNCTION VolumeSupportsDelegate ( INTEGER volumeFeedback , INTEGER muteFeedback , INTEGER discreteMute , INTEGER mute , INTEGER setVolume , INTEGER changeVolume );
        delegate FUNCTION VideoDisplaySupportsDelegate ( INTEGER lampHours , INTEGER discreteVideoMute , INTEGER toggleVideoMute , INTEGER feedbackVideoMute );
        delegate FUNCTION EnergyStarSupportsDelegate ( INTEGER discreteEnergyStar , INTEGER toggleEnergyStar , INTEGER feedbackEnergyStar );
        delegate FUNCTION InputDetailsDelegate ( );
        delegate FUNCTION LampHoursDelegate ( );
        delegate FUNCTION NavigationSupportsDelegate ( INTEGER arrowKeys , INTEGER clear , INTEGER exit , INTEGER home , INTEGER menu , INTEGER select , INTEGER search );
        delegate FUNCTION MediaSupportsDelegate ( INTEGER supportsYouTube , INTEGER supportsYouTubeTv , INTEGER supportsNetflix , INTEGER supportsHulu , INTEGER supportsDirectvNow , INTEGER supportsAmazonVideo , INTEGER supportsPlaystationVue , INTEGER supportsSlingTv );
        delegate FUNCTION MediaTransportDelegate ( INTEGER forwardScan , INTEGER reverseScan , INTEGER play , INTEGER pause , INTEGER stop , INTEGER forwarkSkip , INTEGER reverseSkip , INTEGER repeat , INTEGER returnCommand , INTEGER back , INTEGER playPause , INTEGER options , INTEGER info );

        // class events

        // class functions
        FUNCTION Initialize ( STRING filename , SIGNED_LONG_INTEGER id , STRING ipAddress , SIGNED_LONG_INTEGER port , SIGNED_LONG_INTEGER warmUpTime , SIGNED_LONG_INTEGER coolDownTime );
        FUNCTION Initialize2 ( STRING filename , SIGNED_LONG_INTEGER id , STRING ipAddress , SIGNED_LONG_INTEGER port , SIGNED_LONG_INTEGER warmUpTime , SIGNED_LONG_INTEGER coolDownTime , SIGNED_LONG_INTEGER enableLogging );
        FUNCTION SimplPowerToggle ();
        FUNCTION SimplPowerOn ();
        FUNCTION SimplPowerOff ();
        FUNCTION SimplWarmUpTime ( INTEGER time );
        FUNCTION SimplCoolDownTime ( INTEGER time );
        FUNCTION SimplMute ();
        FUNCTION SimplMuteOn ();
        FUNCTION SimplMuteOff ();
        FUNCTION SimplSetVolume ( LONG_INTEGER volume );
        FUNCTION VolUpHold ();
        FUNCTION VolUpRelease ();
        FUNCTION VolDownHold ();
        FUNCTION VolDownRelease ();
        FUNCTION SimplEnergyStarToggle ();
        FUNCTION SimplEnergyStarOn ();
        FUNCTION SimplEnergyStarOff ();
        FUNCTION SimplVideoMuteOn ();
        FUNCTION SimplVideoMuteOff ();
        FUNCTION SimplVideoMuteToggle ();
        FUNCTION SimplSetInputSource ( LONG_INTEGER id );
        FUNCTION SimplOverrideUsername ( STRING userName );
        FUNCTION SimplOverridePassword ( STRING password );
        FUNCTION SimplArrowKey ( STRING direction );
        FUNCTION SimplReleaseArrow ();
        FUNCTION SimplClear ();
        FUNCTION SimplExit ();
        FUNCTION SimplHome ();
        FUNCTION SimplMenu ();
        FUNCTION SimplSelect ();
        FUNCTION SimplSearch ();
        FUNCTION SimplYouTube ();
        FUNCTION SimplYouTubeTv ();
        FUNCTION SimplNetflix ();
        FUNCTION SimplHulu ();
        FUNCTION SimplDirecTvNow ();
        FUNCTION SimplAmazonVideo ();
        FUNCTION SimplPlaystationVue ();
        FUNCTION SimplSlingTv ();
        FUNCTION SimplForwardScan ();
        FUNCTION SimplReverseScan ();
        FUNCTION SimplPlay ();
        FUNCTION SimplPause ();
        FUNCTION SimplStop ();
        FUNCTION SimplForwardSkip ();
        FUNCTION SimplReverseSkip ();
        FUNCTION SimplRepeat ();
        FUNCTION SimplReturn ();
        FUNCTION SimplBack ();
        FUNCTION SimplPlayPause ();
        FUNCTION SimplOptions ();
        FUNCTION SimplInfo ();
        FUNCTION SimplRelease ();
        STRING_FUNCTION SimplSetComportSpec ( INTEGER comPort );
        FUNCTION ReceiveData ( STRING message );
        FUNCTION SimplEnableLogging ();
        FUNCTION SimplDisableLogging ();
        FUNCTION SimplEnableTxDebug ();
        FUNCTION SimplDisableTxDebug ();
        FUNCTION SimplEnableRxDebug ();
        FUNCTION SimplDisableRxDebug ();
        FUNCTION SimplDisconnect ();
        FUNCTION SimplReconnect ();
        FUNCTION SimplConnect ();
        FUNCTION SimplEnableRxOut ();
        FUNCTION SimplDisableRxOut ();
        FUNCTION SimplSendCustomCommand ( STRING message );
        FUNCTION SimplSendCustomCommandByName ( STRING commandName );
        FUNCTION SimplSendCustomCommandByValue ( STRING value );
        FUNCTION SimplTriggerCustomCommand ( STRING commandName );
        INTEGER_FUNCTION SimplCustomCommandExists ( STRING commandName );
        FUNCTION SimplCustomCommandPageUp ();
        FUNCTION SimplCustomCommandPageDown ();
        FUNCTION SetDriverCustomCommands ();
        FUNCTION UpdateCustomCommands ( SIMPLSHARPSTRING labels[] , INTEGER curPage );
        FUNCTION SimplSetStringUserAttribute ( INTEGER index , STRING value );
        FUNCTION SimplSetAnalogUserAttribute ( INTEGER index , INTEGER value );
        FUNCTION SimplSetDigitalUserAttribute ( INTEGER index , INTEGER value );
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER UserAttributeIsAvailable[];
        INTEGER UserAttributeDataTypes[];
        INTEGER UserAttributeTypes[];
        STRING UserAttributeLabels[][];
        INTEGER UserAttributeIsPersistent[];
        INTEGER UserAttributeRequiredForConnection[];
        STRING UserAttributeDescriptions[][];
        SIMPLSHARPSTRING SimplCustomCommandNames[][];
        INTEGER SimplNumPages;
        INTEGER SimplNumCustomCommands;
        INTEGER SimplCurrentPage;

        // class properties
        DelegateProperty BasicInformationDelegate BasicInformationUpdated;
        DelegateProperty TxUpdatedDelegate TxUpdated;
        DelegateProperty PacketTxUpdatedDelegate PacketTxUpdated;
        DelegateProperty LogDelegate LogOut;
        DelegateProperty RxOutDelegate RxOut;
        DelegateProperty BasicConnectionSupportsDelegate BasicConnectionSupportsUpdated;
        DelegateProperty CustomIrCommandSupportsDelegate CustomIrCommandSupportsUpdatead;
        DelegateProperty DriverLoadedDelegate DriverLoadedCallback;
        DelegateProperty DriverAuthenticationSupportsDelegate DriverAuthenticationSupportsCallback;
        DelegateProperty DriverAuthenticationUpdateDelegate DriverAuthenticationUpdateCallback;
        DelegateProperty DriverCustomCommandDelegate DriverCustomCommandCallback;
        DelegateProperty DisplayStatusDelegate DisplayStatusUpdated;
        DelegateProperty PowerSupportsDelegate PowerSupportsUpdated;
        DelegateProperty InputsSupportsDelegate InputsSupportsUpdated;
        DelegateProperty VolumeSupportsDelegate VolumeSupportsUpdated;
        DelegateProperty VideoDisplaySupportsDelegate VideoDisplaySupportsUpdated;
        DelegateProperty EnergyStarSupportsDelegate EnergyStarSupportsUpdated;
        DelegateProperty InputDetailsDelegate InputDetailsUpdated;
        DelegateProperty LampHoursDelegate LampHoursUpdated;
        DelegateProperty NavigationSupportsDelegate NavigationSupportsUpdated;
        DelegateProperty MediaSupportsDelegate MediaSupportsUpdated;
        DelegateProperty MediaTransportDelegate MediaTransportsUpdated;
        INTEGER SimplArrowDirectionsSupported[];
        STRING SimplInputDescriptions[][];
        INTEGER SimplInputTypes[];
        STRING SimplInputConnectors[][];
        INTEGER NumberOfInputs;
        INTEGER SimplLampHours[];
        INTEGER NumberOfLampHours;
        STRING UserName[];
        STRING Password[];
        STRING ApplicationDirectory[];
        STRING InterfaceName[];
    };

     class ABasicVideoDisplay 
    {
        // class delegates

        // class events

        // class functions
        FUNCTION Netflix ();
        FUNCTION Hulu ();
        FUNCTION DirecTvNow ();
        FUNCTION AmazonVideo ();
        FUNCTION PlaystationVue ();
        FUNCTION SlingTv ();
        FUNCTION Airplay ();
        FUNCTION GoogleCast ();
        FUNCTION Dlna ();
        FUNCTION Tidal ();
        FUNCTION Deezer ();
        FUNCTION Crackle ();
        FUNCTION OnDemand ();
        FUNCTION GooglePlay ();
        FUNCTION Bluetooth ();
        FUNCTION ForwardScan ();
        FUNCTION ReverseScan ();
        FUNCTION Play ();
        FUNCTION Pause ();
        FUNCTION Stop ();
        FUNCTION ForwardSkip ();
        FUNCTION ReverseSkip ();
        FUNCTION Repeat ();
        FUNCTION Return ();
        FUNCTION Back ();
        FUNCTION PlayPause ();
        FUNCTION Options ();
        FUNCTION Info ();
        FUNCTION ConvertJsonFileToDriverData ( STRING jsonString );
        FUNCTION Dispose ();
        FUNCTION EnergyStarOn ();
        FUNCTION EnergyStarOff ();
        FUNCTION EnergyStarToggle ();
        FUNCTION PowerOn ();
        FUNCTION PowerOff ();
        FUNCTION PowerToggle ();
        FUNCTION MuteOn ();
        FUNCTION MuteOff ();
        FUNCTION Mute ();
        FUNCTION SetVolume ( LONG_INTEGER volume );
        FUNCTION OnScreenDisplayOn ();
        FUNCTION OnScreenDisplayOff ();
        FUNCTION OnScreenDisplayPoll ();
        FUNCTION OnScreenDisplay ();
        FUNCTION VideoMuteToggle ();
        FUNCTION VideoMuteOn ();
        FUNCTION VideoMuteOff ();
        FUNCTION Select ();
        FUNCTION Clear ();
        FUNCTION Exit ();
        FUNCTION Home ();
        FUNCTION Menu ();
        FUNCTION Search ();
        FUNCTION Sirius ();
        FUNCTION Xm ();
        FUNCTION SiriusXm ();
        FUNCTION HdRadio ();
        FUNCTION InternetRadio ();
        FUNCTION LastFm ();
        FUNCTION PandoraRadio ();
        FUNCTION Rhapsody ();
        FUNCTION Spotify ();
        FUNCTION YouTube ();
        FUNCTION YouTubeTv ();
        FUNCTION SendCustomCommand ( STRING command );
        FUNCTION SendCustomCommandByName ( STRING commandName );
        FUNCTION SendCustomCommandValue ( STRING commandValue );
        FUNCTION Disconnect ();
        FUNCTION Reconnect ();
        FUNCTION Connect ();
        FUNCTION OverrideUsername ( STRING username );
        FUNCTION OverridePassword ( STRING password );
        FUNCTION SetUserAttribute ( STRING attributeId , STRING attributeValue );
        FUNCTION LoadModelFile ( STRING filePath );
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        LONG_INTEGER WarmUpTime;
        LONG_INTEGER CoolDownTime;
        LONG_INTEGER VolumePercent;
        STRING VolumeDb[];
        SIGNED_LONG_INTEGER Port;
        STRING Description[];
        STRING Manufacturer[];
        STRING BaseModel[];
        STRING DriverVersion[];
        STRING UsernameMask[];
        STRING UsernameKey[];
        STRING PasswordMask[];
        STRING PasswordKey[];
        STRING DefaultUsername[];
        STRING DefaultPassword[];
    };

     class DisplayRootObject 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        CrestronSerialDeviceApi CrestronSerialDeviceApi;
    };

     class CrestronSerialDeviceApi 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        Api Api;
    };

     class Api 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        Feedback Feedback;
    };

     class Feedback 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING Header[];
        PowerFeedback PowerFeedback;
        MuteFeedback MuteFeedback;
        InputFeedback InputFeedback;
        VolumeFeedback VolumeFeedback;
        EnergyStarFeedback EnergyStarFeedback;
        OnScreenDisplayFeedback OnScreenDisplayFeedback;
        VideoMuteFeedback VideoMuteFeedback;
        LampHourFeedback LampHourFeedback;
    };

    static class SupportedFeatureEnum // enum
    {
        static SIGNED_LONG_INTEGER SupportsArrowKeys;
        static SIGNED_LONG_INTEGER SupportsBack;
        static SIGNED_LONG_INTEGER SupportsChangeVolume;
        static SIGNED_LONG_INTEGER SupportsClear;
        static SIGNED_LONG_INTEGER SupportsCoolDownTime;
        static SIGNED_LONG_INTEGER SupportsDisconnect;
        static SIGNED_LONG_INTEGER SupportsDiscreteMute;
        static SIGNED_LONG_INTEGER SupportsDiscretePower;
        static SIGNED_LONG_INTEGER SupportsEnter;
        static SIGNED_LONG_INTEGER SupportsExit;
        static SIGNED_LONG_INTEGER SupportsForwardScan;
        static SIGNED_LONG_INTEGER SupportsForwardSkip;
        static SIGNED_LONG_INTEGER SupportsHome;
        static SIGNED_LONG_INTEGER SupportsInfo;
        static SIGNED_LONG_INTEGER SupportsMenu;
        static SIGNED_LONG_INTEGER SupportsMute;
        static SIGNED_LONG_INTEGER SupportsMuteFeedback;
        static SIGNED_LONG_INTEGER SupportsPause;
        static SIGNED_LONG_INTEGER SupportsPlay;
        static SIGNED_LONG_INTEGER SupportsPowerFeedback;
        static SIGNED_LONG_INTEGER SupportsReconnect;
        static SIGNED_LONG_INTEGER SupportsRepeat;
        static SIGNED_LONG_INTEGER SupportsReturn;
        static SIGNED_LONG_INTEGER SupportsReverseScan;
        static SIGNED_LONG_INTEGER SupportsReverseSkip;
        static SIGNED_LONG_INTEGER SupportsSetVolume;
        static SIGNED_LONG_INTEGER SupportsStop;
        static SIGNED_LONG_INTEGER SupportsTogglePower;
        static SIGNED_LONG_INTEGER SupportsVolumePercentFeedback;
        static SIGNED_LONG_INTEGER SupportsWarmUpTime;
        static SIGNED_LONG_INTEGER SupportsFeedback;
        static SIGNED_LONG_INTEGER SupportsOptions;
        static SIGNED_LONG_INTEGER SupportsInputFeedback;
        static SIGNED_LONG_INTEGER SupportsLampHours;
        static SIGNED_LONG_INTEGER SupportsSetInputSource;
        static SIGNED_LONG_INTEGER SupportsToggleVideoMute;
        static SIGNED_LONG_INTEGER SupportsToggleEnergyStar;
        static SIGNED_LONG_INTEGER SupportsDiscreteEnergyStar;
        static SIGNED_LONG_INTEGER SupportsEnergyStarFeedback;
        static SIGNED_LONG_INTEGER SupportsDiscreteVideoMute;
        static SIGNED_LONG_INTEGER SupportsVideoMuteFeedback;
        static SIGNED_LONG_INTEGER SupportsOnScreenDisplayFeedback;
        static SIGNED_LONG_INTEGER SupportsSelect;
        static SIGNED_LONG_INTEGER SupportsSearch;
        static SIGNED_LONG_INTEGER SupportsSetAudioInputSource;
        static SIGNED_LONG_INTEGER SupportsSetVideoInputSource;
        static SIGNED_LONG_INTEGER SupportsAudioInputFeedback;
        static SIGNED_LONG_INTEGER SupportsVideoInputFeedback;
        static SIGNED_LONG_INTEGER SupportsSetAudioOutputSource;
        static SIGNED_LONG_INTEGER SupportsSetVideoOutputSource;
        static SIGNED_LONG_INTEGER SupportsAudioOutputFeedback;
        static SIGNED_LONG_INTEGER SupportsVideoOutputFeedback;
        static SIGNED_LONG_INTEGER SupportsUsername;
        static SIGNED_LONG_INTEGER SupportsPassword;
        static SIGNED_LONG_INTEGER SupportsPlayPause;
        static SIGNED_LONG_INTEGER SupportsYouTube;
        static SIGNED_LONG_INTEGER SupportsYouTubeTv;
        static SIGNED_LONG_INTEGER SupportsNetflix;
        static SIGNED_LONG_INTEGER SupportsHulu;
        static SIGNED_LONG_INTEGER SupportsDirectvNow;
        static SIGNED_LONG_INTEGER SupportsAmazonVideo;
        static SIGNED_LONG_INTEGER SupportsPlaystationVue;
        static SIGNED_LONG_INTEGER SupportsSlingTv;
    };

     class PowerFeedback 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING GroupHeader[];
    };

     class MuteFeedback 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING GroupHeader[];
    };

     class VolumeFeedback 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING GroupHeader[];
    };

     class InputFeedback 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING GroupHeader[];
    };

     class InputFeedbackValues 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        SIGNED_LONG_INTEGER InputType;
        STRING Feedback[];
    };

     class EnergyStarFeedback 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING GroupHeader[];
    };

     class OnScreenDisplayFeedback 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING GroupHeader[];
    };

     class VideoMuteFeedback 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING GroupHeader[];
    };

     class LampHourFeedback 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING GroupHeader[];
    };

    static class ExtensionMethods 
    {
        // class delegates

        // class events

        // class functions
        static FUNCTION UnescapeFeedback ( PowerFeedback feedback );
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
    };

