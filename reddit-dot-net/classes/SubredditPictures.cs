using System;
using System.Collections.Generic;
using Reddit;
using Reddit.Controllers;
using Reddit.Inputs;
using reddit_dot_net.utility;

namespace reddit_dot_net
{
    public class SubRedditPictures
    {
        private List<string> _pictureExtensions = new List<string>{".jpg", ".png"};

        public List<Post> GetTopPictures(List<string> subReddits, string dateInterval = "day",int topMany = 10)
        {
            var reddit = new RedditClient(Credentials.AppId, Credentials.RefreshToken);
            var today = DateTime.Today;
            var postResults = new List<Post>();

            foreach (var sub in subReddits)
            {
                var subReddit = reddit.Subreddit(sub);
                var posts = subReddit.Posts.GetTop(new TimedCatSrListingInput(t: dateInterval, limit: topMany));
                if (posts.Count <= 0) return postResults;

                foreach (var post in posts)
                {
                    if (post.Created >= today && post.Created < today.AddDays(1))
                    {
                        postResults.Add(post);
                    }
                }
            }

            Utility.Shuffle(postResults);
            return postResults;
        }

        public List<string> GetTopPicturesStrings(string query, string dateInterval = "day", int topMany = 10)
        {
            var reddit = RedditDotNetClient.Instance;
            var today = DateTime.Today;
            var postResults = new List<string>();

            var subReddits = reddit.SearchRedditNames(query, false, true, false);

            foreach (var sub in subReddits)
            {

                var subReddit = reddit.Subreddit(sub);
                var posts = subReddit.Posts.GetTop(new TimedCatSrListingInput(t: dateInterval, limit: topMany));
                if (posts.Count <= 0) return postResults;

                foreach (var post in posts)
                {
                     if (post.Listing.URL.Contains(".jpg") || post.Listing.URL.Contains(".png"))
                       postResults.Add($"{post.Listing.URL}");
                }
            }

            Utility.Shuffle(postResults);
            return postResults;
        }
    }
}
