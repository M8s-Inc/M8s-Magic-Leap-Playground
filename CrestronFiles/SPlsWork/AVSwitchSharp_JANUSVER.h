namespace AVSwitchSharp;
        // class declarations
         class AVSwitchCS;
         class SetOut;
         class MatrixMode;
     class AVSwitchCS 
    {
        // class delegates
        delegate FUNCTION StringParamDelegate ( SIMPLSHARPSTRING str );
        delegate FUNCTION IntParamDelegate ( INTEGER value );
        delegate FUNCTION TwoIntParamDelegate ( INTEGER value1 , INTEGER value2 );

        // class events

        // class functions
        FUNCTION SetSerialRx ( STRING msg );
        FUNCTION ConsoleCommand ( STRING command );
        FUNCTION GetStatus ();
        FUNCTION SetOutputToInput ( INTEGER output , INTEGER input );
        FUNCTION SetAudioOutputToInput ( INTEGER output , INTEGER input );
        FUNCTION SetVideoSource ( INTEGER output , INTEGER source );
        FUNCTION SetAudio ( INTEGER output , INTEGER source );
        FUNCTION SetAudioDelay ( INTEGER output , INTEGER source );
        FUNCTION SetExAMxMode ( INTEGER mode );
        FUNCTION CreateTCPConnection ( SIMPLSHARPSTRING Ip_Address , INTEGER Port );
        FUNCTION CreateSerialConnection ();
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        STRING DebugSystem[];
        static INTEGER MAX_MATRIX_SIZE;

        // class properties
        DelegateProperty StringParamDelegate ConnectionStatusDelegate;
        DelegateProperty IntParamDelegate ConnectionStateDelegate;
        DelegateProperty TwoIntParamDelegate OutputToInputDelegate;
        DelegateProperty TwoIntParamDelegate OutputToInputAudioDelegate;
        DelegateProperty StringParamDelegate TheSerialTXDelegate;
        SIGNED_LONG_INTEGER MessageTimeoutTime;
        SIGNED_LONG_INTEGER HeartbeatTimeoutTime;
    };

    static class SetOut // enum
    {
        static SIGNED_LONG_INTEGER DIS;
        static SIGNED_LONG_INTEGER EN;
    };

    static class MatrixMode // enum
    {
        static SIGNED_LONG_INTEGER BIND_TO_OUTPUT;
        static SIGNED_LONG_INTEGER BIND_TO_INPUT;
        static SIGNED_LONG_INTEGER MATRIX;
    };

