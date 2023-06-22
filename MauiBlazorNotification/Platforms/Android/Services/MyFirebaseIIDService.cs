// Required namespaces for Android, Firebase Messaging, and MAUI Blazor functionalities
using Android.App;
using Android.OS;
using Android.Content;
using Android.Media;
using AndroidX.Core.App;
using MauiBlazorNotification.Services;

// Firebase.Messaging namespace provides the Firebase Cloud Messaging (FCM) APIs, which help you send notifications and data messages to users. 
// Note: The latest version may not be installed. At the time of writing this code, version 123.0.3 of Xamarin.Firebase.Messaging was used.
using Firebase.Messaging;

namespace MauiBlazorNotification.Platforms.Android.Services
{
    // Declaring a service and specifying the intent filter
    [Service]
    [IntentFilter(new[] { "com.google.firebase.MESSAGING_EVENT" })]
    public class MyFirebaseIIDService : FirebaseMessagingService
    {
        // This constant is used to define the unique ID for the notification channel.
        // The notification channel ID is required for compatibility with Android 8.0 (API level 26) and higher.
        // You can choose any string, but make sure it remains consistent across the entire application
        // as it will be used to manage notification behaviors.
        private const string CHANNEL_ID = "Any_Name_CHANNEL";

        // This constant is an arbitrary integer that's used to identify our notification. 
        // It can be any integer, and you'll use it when you need to update or remove the notification.
        // Make sure to use a unique ID for each distinct type of notification your app may send,
        // to ensure they don't overwrite each other.
        private const int NOTIFICATION_ID = 123;


        // Called when a new token is generated
        public override void OnNewToken(string token)
        {
            base.OnNewToken(token);

            // Getting services from the current Maui application
            var services = MauiApplication.Current.Services;

            // Getting the token retriever service and saving the new token
            var tokenRetriever = services.GetService<IFirebaseTokenRetriever>();
            tokenRetriever.SaveToken(token);
        }

        // Called when a message is received
        public override void OnMessageReceived(RemoteMessage message)
        {
            try
            {
                base.OnMessageReceived(message);

                // Extracting the message body and title
                var body = message.GetNotification().Body;
                var Title = message.GetNotification().Title;

                // Calling the method to send the notification
                SendNotification(body, Title, message.Data);
            }
            catch (Exception ex)
            {
                // Catching any exceptions that occur and saving the error message
                var err = ex.Message;
            }
        }

        // Method for sending the notification
        void SendNotification(string messageBody, string messageTitle, IDictionary<string, string> data)
        {
            try
            {
                // Creating an intent for the MainActivity
                var intent = new Intent(this, typeof(MainActivity));
                intent.AddFlags(ActivityFlags.ClearTop);

                // Putting each key-value pair from the data dictionary into the intent as extras
                foreach (var key in data?.Keys ?? Enumerable.Empty<string>())
                {
                    try
                    {
                        intent.PutExtra(key, data[key]);
                    }
                    catch (Exception ex)
                    {
                        // Catching any exceptions that occur and saving the error message
                        var err = $"Error putting extra: {key}, {data[key]}: {ex.Message}";
                    }
                }

                // Supporting different Android API levels
                PendingIntentFlags pendingIntentFlags = PendingIntentFlags.OneShot;
                if (Build.VERSION.SdkInt >= BuildVersionCodes.S)
                {
                    pendingIntentFlags |= PendingIntentFlags.Immutable;
                }

                // Creating a pending intent from the intent
                var pendingIntent = PendingIntent.GetActivity(this,
                                                                      NOTIFICATION_ID,
                                                                      intent,
                                                                      pendingIntentFlags);

                // This section of code is responsible for building the notification.
                // Before you can build the notification, you need to add an icon to the Drawable folder located in:
                // -> Platforms
                //    -----> Android
                //         ---------> Resources
                //              -------------> Drawable
                // You should use a simple white-on-transparent icon for best results.
                // To generate an icon, you can visit this URL:
                // https://romannurik.github.io/AndroidAssetStudio/icons-notification.html#source.type=image&source.space.trim=1&source.space.pad=0&name=ic_stat_example
                // The online tool will help you create an icon and provide it to you in different sizes for different screen resolutions.

                // After setting up the icon, create an instance of NotificationCompat.Builder with the channel id.
                // NotificationCompat.Builder allows you to set properties for the notification, such as icon, title, text, sound, and more.
                // Here we set the small icon using .SetSmallIcon method, passing in the resource ID of our icon.
                // We then set the title and the text of the notification using .SetContentTitle and .SetContentText methods.
                // .SetAutoCancel(true) is used to remove the notification once the user taps on it.
                // The notification sound is set using the .SetSound method, using the default notification sound of the device.
                // Finally, the .SetContentIntent method sets a pending intent that will be fired when the user taps the notification.
                var notificationBuilder = new NotificationCompat.Builder(this, CHANNEL_ID)
                                          .SetSmallIcon(Resource.Drawable.my_icon)
                                          .SetContentTitle(messageTitle)
                                          .SetContentText(messageBody)
                                          .SetAutoCancel(true)
                                          .SetSound(RingtoneManager.GetDefaultUri(RingtoneType.Notification))
                                          .SetContentIntent(pendingIntent);


                // Getting the notification manager and sending the notification
                var notificationManager = NotificationManagerCompat.From(this);
                notificationManager.Notify(NOTIFICATION_ID, notificationBuilder.Build());
            }
            catch (Exception e)
            {
                // Catching any exceptions that occur and saving the error message
                var err = e.Message;
            }
        }
    }
}
