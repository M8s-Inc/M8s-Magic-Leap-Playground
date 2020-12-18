namespace Crestron.SimplSharp.SimplSharpCloudClient;
        // class declarations
         class CloudClient;
         class CloudArgs;
         class CloudActivationKeyArgs;
         class OnUploadFileToCloudArgs;
         class OnDownloadFileFromCloudArgs;
         class OnDownloadListFromCloudArgs;
         class OnGenericMessageFromCloudArgs;
         class OnCancelTransactionEventArgs;
         class OnResetFileListingTransactionEventArgs;
         class CloudStatusEventArgs;
         class HydrogenConnectionStateEventArgs;
         class eHydrogenConnectionState;
         class eCloudStatus;
         class eCloudRequestResultCodes;
         class eCancellationRequestResultCodes;
         class CloudFileInformation;
         class eBitField;
         class eCloudRequestErrorCode;
         class eCloudEventArgsType;
    static class CloudClient 
    {
        // class delegates

        // class events
        static EventHandler OnUploadFileToCloud ( OnUploadFileToCloudArgs args );
        static EventHandler OnDownloadFileFromCloud ( OnDownloadFileFromCloudArgs args );
        static EventHandler OnDownloadListFromCloud ( OnDownloadListFromCloudArgs args );
        static EventHandler OnCancelTransaction ( OnCancelTransactionEventArgs args );
        static EventHandler OnResetFileListingTransaction ( OnResetFileListingTransactionEventArgs args );
        static EventHandler CloudStatusChange ( CloudStatusEventArgs args );
        static EventHandler HydrogenConnectionStateChange ( HydrogenConnectionStateEventArgs args );
        static EventHandler OnGenericMessageFromCloud ( OnGenericMessageFromCloudArgs args );
        static EventHandler OnActivationKeyMessageFromCloud ( CloudActivationKeyArgs args );

        // class functions
        static FUNCTION ResetCloudUrl ();
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        eCloudStatus CloudStatus;
        STRING ActivationKey[];
        eHydrogenConnectionState HydrogenConnectionState;
        STRING CloudUrl[];
    };

     class CloudArgs 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        eCloudEventArgsType CloudArgsType;
        LONG_INTEGER TransactionId;
    };

     class CloudActivationKeyArgs 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING ActivationKey[];
        eCloudEventArgsType CloudArgsType;
        LONG_INTEGER TransactionId;
    };

     class OnUploadFileToCloudArgs 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING Path[];
        STRING Tag[];
        eCloudRequestErrorCode errorCode;
        eCloudEventArgsType CloudArgsType;
        LONG_INTEGER TransactionId;
    };

     class OnDownloadFileFromCloudArgs 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING Tag[];
        LONG_INTEGER Index;
        STRING Path[];
        eCloudRequestErrorCode errorCode;
        eCloudEventArgsType CloudArgsType;
        LONG_INTEGER TransactionId;
    };

     class OnDownloadListFromCloudArgs 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING Tag[];
        eCloudRequestErrorCode errorCode;
        eCloudEventArgsType CloudArgsType;
        LONG_INTEGER TransactionId;
    };

     class OnGenericMessageFromCloudArgs 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        eCloudEventArgsType CloudArgsType;
        LONG_INTEGER TransactionId;
    };

     class OnCancelTransactionEventArgs 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        eCancellationRequestResultCodes errorCode;
        eCloudEventArgsType CloudArgsType;
        LONG_INTEGER TransactionId;
    };

     class OnResetFileListingTransactionEventArgs 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        eCloudRequestErrorCode errorCode;
        eCloudEventArgsType CloudArgsType;
        LONG_INTEGER TransactionId;
    };

     class CloudStatusEventArgs 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        eCloudStatus Status;
        eCloudEventArgsType CloudArgsType;
        LONG_INTEGER TransactionId;
    };

     class HydrogenConnectionStateEventArgs 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        eHydrogenConnectionState State;
        eCloudEventArgsType CloudArgsType;
        LONG_INTEGER TransactionId;
    };

    static class eHydrogenConnectionState // enum
    {
        static SIGNED_LONG_INTEGER NA;
        static SIGNED_LONG_INTEGER Online;
        static SIGNED_LONG_INTEGER Offline;
    };

    static class eCloudStatus // enum
    {
        static SIGNED_LONG_INTEGER Registered;
        static SIGNED_LONG_INTEGER Unregistered;
        static SIGNED_LONG_INTEGER UrlUnresolved;
        static SIGNED_LONG_INTEGER NetworkError;
        static SIGNED_LONG_INTEGER CloudOffline;
        static SIGNED_LONG_INTEGER Unknown;
    };

    static class eCloudRequestResultCodes // enum
    {
        static SIGNED_LONG_INTEGER Pending;
        static SIGNED_LONG_INTEGER Error;
    };

    static class eCancellationRequestResultCodes // enum
    {
        static SIGNED_LONG_INTEGER TransactionAlreadyComplete;
        static SIGNED_LONG_INTEGER TransactionNotFound;
        static SIGNED_LONG_INTEGER TransactionCancelledSuccessfully;
        static SIGNED_LONG_INTEGER Error;
    };

     class CloudFileInformation 
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
        LONG_INTEGER Index;
        STRING DateAndTime[];
    };

    static class eBitField // enum
    {
        static SIGNED_LONG_INTEGER GoldenFile;
        static SIGNED_LONG_INTEGER FileGroup;
    };

    static class eCloudRequestErrorCode // enum
    {
        static SIGNED_LONG_INTEGER Completed;
        static SIGNED_LONG_INTEGER Failed;
        static SIGNED_LONG_INTEGER NotEnoughCloudSpace;
        static SIGNED_LONG_INTEGER CloudNotRegistered;
        static SIGNED_LONG_INTEGER URLNotResolved;
        static SIGNED_LONG_INTEGER NetworkError;
        static SIGNED_LONG_INTEGER InvalidRequest;
        static SIGNED_LONG_INTEGER DeployCodeExpired;
        static SIGNED_LONG_INTEGER DeployCodeInvalid;
    };

    static class eCloudEventArgsType // enum
    {
        static SIGNED_LONG_INTEGER FileUpload;
        static SIGNED_LONG_INTEGER FileListDownload;
        static SIGNED_LONG_INTEGER FileDownload;
        static SIGNED_LONG_INTEGER CancelTransaction;
        static SIGNED_LONG_INTEGER CloudStatus;
        static SIGNED_LONG_INTEGER GenericMessage;
        static SIGNED_LONG_INTEGER ActivationKeyMessage;
        static SIGNED_LONG_INTEGER HydrogenConnectionStateChange;
        static SIGNED_LONG_INTEGER ResetFileListing;
    };

