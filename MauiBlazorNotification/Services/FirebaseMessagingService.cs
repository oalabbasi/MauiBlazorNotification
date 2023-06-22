namespace MauiBlazorNotification.Services
{
    // This class implements the IFirebaseTokenRetriever interface and its functionality.
    // The purpose of this class is to retrieve and store Firebase tokens, which are used 
    // for sending notifications to specific devices via Firebase Cloud Messaging (FCM).
    public class FirebaseTokenRetriever : IFirebaseTokenRetriever
    {
        // This property holds the Firebase token. 
        // It has a public get accessor but a private set accessor, 
        // meaning that it can be publicly read, but only changed internally by the class.
        public string Token { get; private set; }

        // This method allows for the saving of a new Firebase token.
        // It takes in a string token and assigns it to the Token property.
        public void SaveToken(string token)
        {
            Token = token;
        }
    }
}
