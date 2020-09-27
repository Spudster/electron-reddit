using System;
using System.Collections.Generic;



namespace reddit_dot_net
{
    class Program
    {
        static void Main(string[] args)
        {
            RedditDotNetClient.InitializeRedditClient();
            var reddit = RedditDotNetClient.Instance;
            var results = reddit.SearchRedditNames("", false, true, false);

            //var sr = new SubReddit().Recommended("oldschoolcool");

            //var subReddits = new List<string> {"earthporn", "oldschoolcool", "astrophotography", "spaceporn" };
            //var posts = new SubRedditPictures().GetTopPictures(subReddits);



            //Console.WriteLine($"Post #: {posts.Count}");
            //foreach (var post in posts)
            //{
            //    Console.WriteLine($"Title: {post.Listing.Title}");
            //    Console.WriteLine($"URI: {post.Listing.URL}");
            //    Console.WriteLine($"Author: {post.Listing.Author}");
            //    Console.WriteLine($"Upvotes: {post.UpVotes}");
            //    Console.WriteLine($"Subreddit: {post.Subreddit}");

            //    Console.WriteLine($"-----------------------");
            //    Console.WriteLine();
            //}

            //Console.ReadLine();
        }
    }

    //Console.WriteLine("Username: " + reddit.Account.Me.Name);
    //Console.WriteLine("Cake Day: " + reddit.Account.Me.Created.ToString("D"));

}
