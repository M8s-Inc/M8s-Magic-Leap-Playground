namespace J_Timers;
        // class declarations
         class J_Timer;
     class J_Timer 
    {
        // class delegates
        delegate FUNCTION J_TimerCallback ( J_Timer firedBy );

        // class events

        // class functions
        FUNCTION CreateTimerWithRepeat ( SIGNED_LONG_INTEGER time , SIGNED_LONG_INTEGER repeat );
        FUNCTION CreateTimer ( SIGNED_LONG_INTEGER time );
        FUNCTION Stop ();
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        static STRING DebugSystem[];

        // class properties
        SIGNED_LONG_INTEGER StartDelay;
        SIGNED_LONG_INTEGER Repeat;
        DelegateProperty J_TimerCallback Callback;
    };

