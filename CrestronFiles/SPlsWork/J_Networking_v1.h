namespace J_Networking;
        // class declarations
         class J_Socket;
         class J_SocketStatus;
         class J_TCPClient;
         class J_HTTP;
         class J_WebSocket;
         class J_UDP;
     class J_Socket 
    {
        // class delegates

        // class events

        // class functions
        FUNCTION ConnectTo ( STRING host , SIGNED_LONG_INTEGER port , SIGNED_LONG_INTEGER bufferSize );
        FUNCTION Disconnect ();
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        static SIGNED_LONG_INTEGER DEFAULT_BUFFERSIZE;

        // class properties
    };

    static class J_SocketStatus // enum
    {
        static SIGNED_LONG_INTEGER DISCONNECTED;
        static SIGNED_LONG_INTEGER CONNECTING;
        static SIGNED_LONG_INTEGER CONNECTED;
    };

     class J_TCPClient 
    {
        // class delegates

        // class events

        // class functions
        FUNCTION ConnectTo ( STRING host , SIGNED_LONG_INTEGER port , SIGNED_LONG_INTEGER bufferSize );
        FUNCTION Disconnect ();
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        static STRING DebugSystem[];
        static SIGNED_LONG_INTEGER DEFAULT_BUFFERSIZE;

        // class properties
        SIGNED_LONG_INTEGER Port;
        STRING RemoteAddress[];
        STRING LocalAddress[];
    };

     class J_HTTP 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION GetPage ( STRING url );
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        static STRING DebugSystem[];

        // class properties
    };

     class J_WebSocket 
    {
        // class delegates

        // class events

        // class functions
        FUNCTION ConnectTo ( STRING host , SIGNED_LONG_INTEGER port , SIGNED_LONG_INTEGER bufferSize , STRING path );
        FUNCTION Disconnect ();
        FUNCTION SendPing ();
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        static STRING DebugSystem[];
        static SIGNED_LONG_INTEGER DEFAULT_BUFFERSIZE;

        // class properties
        SIGNED_LONG_INTEGER Port;
        STRING RemoteAddress[];
        STRING LocalAddress[];
    };

     class J_UDP 
    {
        // class delegates

        // class events

        // class functions
        FUNCTION ConnectTo ( STRING host , SIGNED_LONG_INTEGER port , SIGNED_LONG_INTEGER bufferSize );
        FUNCTION Disconnect ();
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        static STRING DebugSystem[];
        static SIGNED_LONG_INTEGER DEFAULT_BUFFERSIZE;

        // class properties
        SIGNED_LONG_INTEGER Port;
        STRING RemoteAddress[];
        STRING LocalAddress[];
    };

