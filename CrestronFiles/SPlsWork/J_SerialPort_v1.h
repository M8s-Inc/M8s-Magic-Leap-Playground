namespace J_SerialPort_NS;
        // class declarations
         class J_SerialPort_New;
         class J_SerialPort;
     class J_SerialPort_New 
    {
        // class delegates
        delegate FUNCTION StringParamDelegate ( SIMPLSHARPSTRING str );

        // class events

        // class functions
        FUNCTION SimplRxSerialMessage ( SIMPLSHARPSTRING msg );
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        static STRING SUBSYSTEM_NAME[];

        // class properties
        DelegateProperty StringParamDelegate SerialTxDelegate;
    };

     class J_SerialPort 
    {
        // class delegates
        delegate FUNCTION StringParamDelegate ( SIMPLSHARPSTRING str );

        // class events

        // class functions
        FUNCTION SendSerialMessage ( SIMPLSHARPSTRING msg );
        FUNCTION RxSerialMessage ( SIMPLSHARPSTRING msg );
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        static STRING SUBSYSTEM_NAME[];

        // class properties
        DelegateProperty StringParamDelegate SerialTxDelegate;
    };

