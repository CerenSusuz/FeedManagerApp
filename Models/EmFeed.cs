using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedManagerApp.Models
{
    public class EmFeed : TradeFeed
    {
        public decimal Sedol { get; set; }
        public decimal AssetValue { get; set; }
    }
}
