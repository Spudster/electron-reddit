using System;
using System.Collections.Generic;
using Reddit.Controllers;
using reddit_dot_net.models;

namespace reddit_dot_net.utility
{
    public class Utility
    {
        private static readonly Random Rand = new Random();
        public static void Shuffle<T>(IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = Rand.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }


        public static SimplifiedPost SimplifyPost(Post p)
        {
            return new SimplifiedPost
            {
                Awards = new Awards
                {
                    Count = p.Awards.Count,
                    Gold = p.Awards.Gold,
                    Platinum = p.Awards.Platinum,
                    Silver = p.Awards.Silver
                },

                Listing = new Listing
                {
                    Edited = p.Listing.Edited,
                    Id = p.Listing.Id,
                    Subreddit = p.Listing.Subreddit,
                    Url = p.Listing.URL,
                    Title = p.Listing.Title,
                    SelfText = p.Listing.SelfText,
                    AuthorFullName = p.Listing.AuthorFullname,
                    ContentCategories = p.Listing.ContentCategories,
                    Gilded = p.Listing.Gilded,
                    Gildings = p.Listing.Gildings,
                    Name = p.Listing.Name,
                    SubredditId = p.Listing.SubredditId,
                    SubredditNamePrefixed = p.Listing.SubredditNamePrefixed,
                    SubredditSubScribers = p.Listing.SubredditSubscribers
                },

                Author = p.Author,
                Created = p.Created,
                DownVotes = p.DownVotes,
                Edited = p.Edited,
                Fullname = p.Fullname,
                Id = p.Id,
                IsDownvoted = p.IsDownvoted,
                IsUpvoted = p.IsUpvoted,
                NSFW = p.NSFW,
                Permalink = p.Permalink,
                Removed = p.Removed,
                Score = p.Score,
                Spam = p.Spam,
                Subreddit = p.Subreddit,
                Title = p.Title,
                UpvoteRatio = p.UpvoteRatio,
                Upvotes = p.UpVotes,

                Url = p.Listing.URL,
                Thumbnail = p.Listing.Thumbnail,
                ThumbnailHeight = p.Listing.ThumbnailHeight,
                ThumbnailWidth = p.Listing.ThumbnailWidth


            };
        }
    }
}
