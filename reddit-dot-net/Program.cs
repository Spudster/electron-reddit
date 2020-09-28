using System;
using System.Collections.Generic;
using Newtonsoft.Json;


namespace reddit_dot_net
{
    class Program
    {
        static void Main(string[] args)
        {
            RedditDotNetClient.InitializeRedditClient();
            var reddit = RedditDotNetClient.Instance;
            //var results = reddit.SearchRedditNames("dadjokes", false, false, false);

            // var posts = new Jokster().GetTopPosts(new List<string> {"dadjokes"}, "year", 100);

            var posts = new Pictureizer().GetTopPictures(new List<string> { "foodporn" }, "month", 20);

            

            foreach (var post in posts)
            {
                Console.WriteLine(JsonConvert.SerializeObject(post, Formatting.Indented));

                Console.WriteLine($"Title: {post.Title}");
                Console.WriteLine($"Self Text: {post.Listing.SelfText}");
                Console.WriteLine($"URI: {post.Url}");
                Console.WriteLine($"Author: {post.Author}");
                Console.WriteLine($"Upvotes: {post.Upvotes}");
                Console.WriteLine($"Subreddit: {post.Subreddit}");
                Console.WriteLine($"-----------------------");
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }

    //Console.WriteLine("Username: " + reddit.Account.Me.Name);
    //Console.WriteLine("Cake Day: " + reddit.Account.Me.Created.ToString("D"));

}
