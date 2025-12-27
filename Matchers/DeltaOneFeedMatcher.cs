using FeedManagerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedManagerApp.Matchers
{
    public class DeltaOneFeedMatcher : IFeedMatcher<DeltaOneFeed>
    {
        public bool Match(DeltaOneFeed current, DeltaOneFeed other)
        {
            return current.CounterpartyId == other.CounterpartyId &&
                   current.PrincipalId == other.PrincipalId;
        }
    }
}
