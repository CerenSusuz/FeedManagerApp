using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedManagerApp.Models
{
    public class DeltaOneFeed : TradeFeed
    {
        public string Isin { get; set; }
        public DateTime MaturityDate { get; set; }
    }
}
