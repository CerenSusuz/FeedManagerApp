using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedManagerApp.Validators
{
    public static class ErrorCode
    {
        public const string InvalidId = "ID fields must be >= 1";
        public const string InvalidPrice = "CurrentPrice must be >= 0 and have max 2 decimal digits";
        public const string InvalidIsin = "ISIN must start with 2 uppercase letters followed by 10 digits";
        public const string InvalidMaturityDate = "MaturityDate must be after ValuationDate";
        public const string InvalidSedol = "Sedol must be > 0 and < 100";
        public const string InvalidAssetValue = "AssetValue must be > 0 and < Sedol";
    }
}
