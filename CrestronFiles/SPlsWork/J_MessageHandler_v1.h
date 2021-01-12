namespace J_MessageHandler;
        // class declarations
         class MessageHandler;
         class MessageItem;
     class MessageHandler 
    {
        // class delegates

        // class events

        // class functions
        FUNCTION AddMessage ( MessageItem msgItm );
        FUNCTION SetHeartbeat ( MessageItem msgItm , SIGNED_LONG_INTEGER milliseconds );
        FUNCTION MessageProcessed ();
        FUNCTION ClearMessageList ();
        FUNCTION ReduceList ();
        STRING_FUNCTION GetCurrentTag ();
        FUNCTION RemoveNextMessage ();
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        static STRING DebugSystem[];

        // class properties
    };

     class MessageItem 
    {
        // class delegates

        // class events

        // class functions
        FUNCTION StartSending ();
        FUNCTION DoneSending ();
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING Tag[];
    };

