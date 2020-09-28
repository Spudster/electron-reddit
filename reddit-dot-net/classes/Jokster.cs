using System;
using System.Collections.Generic;
using Reddit;
using Reddit.Controllers;
using Reddit.Inputs;
using reddit_dot_net.utility;

namespace reddit_dot_net.classes
{
    public class Jokster
    {
        public List<Post> GetTopPosts(List<string> subReddits, string dateInterval = "day", int topMany = 50)
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
                    postResults.Add(post);
                }
            }

            Utility.Shuffle(postResults);
            return postResults;
        }

    }
}
