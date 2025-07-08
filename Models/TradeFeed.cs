using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedManagerApp.Models
{
    public class TradeFeed
    {
        public int StagingId { get; set; }
        public string SourceTradeRef { get; set; }
        public int CounterpartyId { get; set; }
        public int PrincipalId { get; set; }
        public DateTime ValuationDate { get; set; }
        public decimal CurrentPrice { get; set; }
        public int SourceAccountId { get; set; }
    }
}
