﻿
namespace reddit_dot_net
{
    public static class Credentials
    {
        public static string AppId = "0Nis1NA2SzJ0vA";//always the same

        public static string AccessToken = "25661343-UsorRqDUxlOXbj8sUaT0m-sgykc";
        public static string RefreshToken = "25661343-eq_FXzRm2GXyNJgcX4aOG1aCOnk";

        public static void ChangeCredentials(string accessToken, string refreshToken)
        {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
        }
    }
}
