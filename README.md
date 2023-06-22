# MauiBlazorNotification

This repository demonstrates how to enable and handle notifications in a .NET MAUI Blazor application using Firebase Cloud Messaging (FCM).

## Project Overview

The `MauiBlazorNotification` project uses .NET MAUI Blazor to create a cross-platform application. This application features the implementation of push notifications, a common requirement for modern mobile applications. The notifications functionality is provided by the Firebase Cloud Messaging Service.

## Structure of Work

### Root

1. Create a `Services` folder in root and add your service classes.
2. Modify `MauiProgram.cs` in root to build services.

### platforms/android/

1. Create a `Services` folder and add the service classes.
2. Modify `AndroidManifest.xml` for necessary permissions and services.
3. Modify `MainActivity.cs` for Firebase initialization and notification channel creation.
4. Add `google-services.json` which you can get from Firebase console.

### platforms/android/Resources

1. Add a `Drawable` folder for notification icons.

## Getting Started

### Prerequisites

- Install the [.NET MAUI Blazor](https://docs.microsoft.com/dotnet/maui/user-interface/controls/blazor/) framework
- A Google Firebase account to set up and manage the Firebase Cloud Messaging service

### Running the Application

1. Clone the repository: `git clone https://github.com/oalabbasi/MauiBlazorNotification.git`
2. Navigate to the cloned repository: `cd MauiBlazorNotification`
3. Open the project in your preferred code editor.
4. Replace Firebase App ID and API key with your own in `MainActivity.cs`.
5. Run the project.

## Dependencies

- [Firebase Cloud Messaging](https://firebase.google.com/docs/cloud-messaging) - version 123.0.3 of `Xamarin.Firebase.Messaging` was used in this project. (Note: Using the latest version may cause issues due to potential breaking changes or differences in implementation)
- [Firebase.Iid](https://firebase.google.com/docs/reference/android/com/google/firebase/iid/FirebaseInstanceId) - version 121.1.0 of `Xamarin.Firebase.Iid` was used in this project. 

Be sure to use these specific versions while working with this project to avoid any compatibility issues.

## Contributing

If you would like to contribute to this project, feel free to fork the repository, make your changes and submit a pull request. We appreciate any contributions, whether they're issues, new features, or improvements to the existing code.

## License

This project is free and open for any purpose. You can use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the software. The original copyright notice and the permission notice are included in the distribution.

## Credits

This project was developed and thoroughly tested with the support and guidance of OpenAI's ChatGPT-4. ChatGPT-4, a large language model trained by OpenAI, provided in-depth technical assistance, prompt solutions, and necessary explanations which immensely contributed to the successful completion of this project.

The project is a demonstration of the capabilities of AI-assisted development, emphasizing the valuable role AI can play in educational endeavors and software development process. By providing clear, accurate, and detailed guidance, ChatGPT-4 played a crucial role in developing this "MauiBlazorNotification" solution.

We would like to express our heartfelt appreciation to OpenAI for providing access to such a powerful tool that has greatly simplified the software development process and taken it to new heights.
