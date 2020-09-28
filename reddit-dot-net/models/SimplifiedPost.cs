using System;
using System.Collections.Generic;


namespace reddit_dot_net.models
{
    public class SimplifiedPost
    {
        public Awards Awards { get; set; }
        public Listing Listing { get; set; }
        public string Subreddit { get; set; }
   
        public string Author { get; set; }
        public int DownVotes { get; set; }
        public string Fullname { get; set; }
        public string Id { get; set; }
        public bool IsDownvoted { get; set; }
        public bool IsUpvoted { get; set; }
        public bool NSFW { get; set; }
        public string Permalink { get; set; }
        public bool Removed { get; set; }
        public int Score { get; set; }
        public bool Spam { get; set; }
        public string Title { get; set; }

        public string Url { get; set; }
        public string Thumbnail { get; set; }
        public int? ThumbnailHeight { get; set; }
        public int? ThumbnailWidth { get; set; }

        public int Upvotes { get; set; }
        public double UpvoteRatio { get; set; }
        public DateTime Created { get; set; }
        public DateTime Edited { get; set; }

    }

    public class Awards
    {
        public int Count { get; set; }
        public int Gold { get; set; }
        public int Platinum { get; set; }
        public int Silver { get; set; }
    }

    public class Listing
    {
        public string AuthorFullName { get; set; }
        public object ContentCategories { get; set; }
        public DateTime Edited { get; set; }
        public int Gilded { get; set; }
        public Dictionary<string, int> Gildings { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public int SubredditSubScribers { get; set; }
        public string SubredditNamePrefixed { get; set; }
        public string Subreddit { get; set; }
        public string SubredditId { get; set; }
        public string SelfText { get; set; }
    }
}
