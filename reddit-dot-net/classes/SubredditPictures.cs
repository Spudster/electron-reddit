using System;
using System.Collections.Generic;
using System.Linq;
using Reddit;
using Reddit.Controllers;
using Reddit.Inputs;

namespace reddit_dot_net
{
    public class SubRedditPictures
    {
        private List<string> _pictureExtensions = new List<string>{".jpg", ".png"};
        private Random rng = new Random();
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

            Shuffle(postResults);
            return postResults;
        }
        public List<string> GetTopPicturesStrings(List<string> subReddits, string dateInterval = "day", int topMany = 3)
        {
            var reddit = RedditDotNetClient.Instance;
            var today = DateTime.Today;
            var postResults = new List<string>();
            foreach (var sub in subReddits)
            {

                var subReddit = reddit.Subreddit(sub);
                var posts = subReddit.Posts.GetTop(new TimedCatSrListingInput(t: dateInterval, limit: topMany));
                if (posts.Count <= 0) return postResults;

                foreach (var post in posts)
                {
                    if (post.Created >= today && post.Created < today.AddDays(1))
                    {
                        if(post.Listing.URL.Contains(".jpg") || post.Listing.URL.Contains(".png"))
                             postResults.Add($"{post.Listing.URL}");
                    }
                }
            }

            Shuffle(postResults);
            return postResults;
        }

        private void Shuffle<T>( IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
