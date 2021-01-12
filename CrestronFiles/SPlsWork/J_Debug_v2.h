namespace J_Debug;
        // class declarations
         class J_Debugger;
         class J_DebugSystem;
         class SubsystemNameException;
         class J_DebugSystem_Plus;
     class J_Debugger 
    {
        // class delegates

        // class events

        // class functions
        static FUNCTION EnableSystem ( STRING systemName );
        static FUNCTION DisableSystem ( STRING systemName );
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
    };

     class J_DebugSystem_Plus 
    {
        // class delegates

        // class events

        // class functions
        FUNCTION ConfigureAsSubSystem ( STRING toUse );
        FUNCTION PrintLine ( STRING toPrint );
        FUNCTION Print ( STRING toPrint );
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
    };

