using System;
using System.Diagnostics;
using Reddit.AuthTokenRetriever;

namespace reddit_dot_net
{
    public class User
    {
        public  string Authorize(string appId, string appSecret = null, int port = 8080)
        {
            // Create a new instance of the auth token retrieval library.  --Kris
            AuthTokenRetrieverLib authTokenRetrieverLib = new AuthTokenRetrieverLib(appId, appSecret, port);

            // Start the callback listener.  --Kris
            // Note - Ignore the logging exception message if you see it.  You can use Console.Clear() after this call to get rid of it if you're running a console app.
            authTokenRetrieverLib.AwaitCallback();

            // Open the browser to the Instance authentication page.  Once the user clicks "accept", Instance will redirect the browser to localhost:8080, where AwaitCallback will take over.  --Kris
            OpenBrowser(authTokenRetrieverLib.AuthURL());

            // Replace this with whatever you want the app to do while it waits for the user to load the auth page and click Accept.  --Kris
            Console.ReadLine();

            // Cleanup.  --Kris
            authTokenRetrieverLib.StopListening();

            return authTokenRetrieverLib.RefreshToken;
        }

        private void OpenBrowser(string authUrl)
        {
            try
            {
                ProcessStartInfo processStartInfo = new ProcessStartInfo(authUrl);
                Process.Start(processStartInfo);
            }
            catch (System.ComponentModel.Win32Exception)
            {
                // This typically occurs if the runtime doesn't know where your browser is.  Use BrowserPath for when this happens.  --Kris
                ProcessStartInfo processStartInfo = new ProcessStartInfo(GetChromePathWindows())
                {
                    Arguments = authUrl
                };
                Process.Start(processStartInfo);
            }
        }

        private string GetChromePathWindows()
        {
            var path = Microsoft.Win32.Registry.GetValue(
                @"HKEY_CLASSES_ROOT\ChromeHTML\shell\open\command", null, null) as string;

            if (path != null)
            {
                var split = path.Split('\"');
                path = split.Length >= 2 ? split[1] : null;
            }

            return path;
        }
    }
}
