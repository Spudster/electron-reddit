
using System.Collections.Generic;
using Reddit.Inputs.Subreddits;
using Reddit.Things;

namespace reddit_dot_net
{
    public class SubReddit
    {
        public IEnumerable<SubredditRecommendations> Recommended(string sub)
        {
            var reddit = RedditDotNetClient.Instance;
            var recommended = reddit.Models.Subreddits.Recommended(sub, new SubredditsRecommendInput());
            return recommended;
        }
    }
}
