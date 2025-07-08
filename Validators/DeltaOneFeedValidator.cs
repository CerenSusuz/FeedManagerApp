using System.Text.RegularExpressions;
using FeedManagerApp.Models;
using FeedManagerApp.Results;

namespace FeedManagerApp.Validators
{
    public class DeltaOneFeedValidator : IFeedValidator<DeltaOneFeed>
    {
        public ValidateResult Validate(DeltaOneFeed feed)
        {
            var result = new ValidateResult();

            if (feed.StagingId < 1 || feed.CounterpartyId < 1 || feed.PrincipalId < 1 || feed.SourceAccountId < 1)
                result.Errors.Add(ErrorCode.InvalidId);

            if (feed.CurrentPrice < 0 || DecimalPlaces(feed.CurrentPrice) > 2)
                result.Errors.Add(ErrorCode.InvalidPrice);

            if (!Regex.IsMatch(feed.Isin ?? "", @"^[A-Z]{2}\d{10}$"))
                result.Errors.Add(ErrorCode.InvalidIsin);

            if (feed.MaturityDate <= feed.ValuationDate)
                result.Errors.Add(ErrorCode.InvalidMaturityDate);

            return result;
        }

        private int DecimalPlaces(decimal number)
        {
            var str = number.ToString(System.Globalization.CultureInfo.InvariantCulture);
            var dot = str.IndexOf('.');

            return dot < 0 ? 0 : str.Length - dot - 1;
        }
    }
}
