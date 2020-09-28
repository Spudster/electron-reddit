using System;
using System.Collections.Generic;
using Reddit.Controllers;
using Reddit.Inputs;
using reddit_dot_net.models;
using reddit_dot_net.utility;

namespace reddit_dot_net
{
    public class Pictureizer
    {
        private List<string> _pictureExtensions = new List<string>{".jpg", ".png"};

        public List<SimplifiedPost> GetTopPictures(List<string> subReddits, string dateInterval = "day",int topMany = 10)
        {
            var reddit = RedditDotNetClient.Instance;
            var today = DateTime.Today;
            var postResults = new List<SimplifiedPost>();

            foreach (var sub in subReddits)
            {
                var subReddit = reddit.Subreddit(sub);
                var posts = subReddit.Posts.GetTop(new TimedCatSrListingInput(t: dateInterval, limit: topMany));
                if (posts.Count <= 0) return postResults;

                foreach (var post in posts)
                {
                    if (post.Listing.URL.Contains(".jpg") || post.Listing.URL.Contains(".png"))
                    {
                        postResults.Add(Utility.SimplifyPost(post));
                    }
                }
            }

            Utility.Shuffle(postResults);
            return postResults;
        }

        public List<string> GetTopPicturesStrings( string dateInterval = "day", int topMany = 10)
        {
            var reddit = RedditDotNetClient.Instance;
            var postResults = new List<string>();

            var subReddits = reddit.SearchRedditNames("foodporn", false, true, false);
  

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
