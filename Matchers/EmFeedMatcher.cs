using FeedManagerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedManagerApp.Matchers
{
    public class EmFeedMatcher : IFeedMatcher<EmFeed>
    {
        public bool Match(EmFeed current, EmFeed other)
        {
            if (current.SourceAccountId != 0 && other.SourceAccountId != 0)
                return current.SourceAccountId == other.SourceAccountId;

            return current.StagingId == other.StagingId;
        }
    }
}
