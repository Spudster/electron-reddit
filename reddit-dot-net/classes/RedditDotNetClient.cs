
using Reddit;

namespace reddit_dot_net
{
    public static class RedditDotNetClient
    {
        public static RedditClient Instance { get; set; }

        public static void InitializeRedditClient() => Instance = new RedditClient(Credentials.AppId, Credentials.RefreshToken);
    }
}
