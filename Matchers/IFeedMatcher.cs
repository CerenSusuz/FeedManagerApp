using FeedManagerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedManagerApp.Matchers
{
    public interface IFeedMatcher<T> where T : TradeFeed
    {
        bool Match(T current, T other);
    }
}
