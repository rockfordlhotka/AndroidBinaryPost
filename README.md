This repo includes code to demonstrate the potential bug reported here:

https://github.com/dotnet/maui/issues/21933

## Steps to run

1. Launch the AppServer project
2. Use something like [ngrok](https://ngrok.com/) to make the AppServer available to MAUI apps

Now you can run the MAUI client. 

1. Look in `MauiProgram.cs` and you can see the `ServerAddress` value - update that based on your tunnel address from ngrok, etc.
2. Look in `MauiProgram.cs` and you can see how the `HttpClient` service is defined
   a. Use the default `HttpClient` and it will fail on Android, but work on Windows
   b. Use the `HttpClient` created with the socket handler and it works on Android and Windows

   
