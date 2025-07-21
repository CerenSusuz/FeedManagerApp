using FeedManagerApp.Helpers;
using FeedManagerApp.Models;
using FeedManagerApp.Results;
using System.Text.RegularExpressions;

namespace FeedManagerApp.Validators
{
    public class DeltaOneFeedValidator : IFeedValidator<DeltaOneFeed>
    {
        public ValidateResult Validate(DeltaOneFeed feed)
        {
            var result = new ValidateResult();

            if (feed.StagingId < 1 || feed.CounterpartyId < 1 || feed.PrincipalId < 1 || feed.SourceAccountId < 1)
                result.Errors.Add(ErrorCode.InvalidId);

            if (feed.CurrentPrice < 0 || FeedValidationUtils.DecimalPlaces(feed.CurrentPrice) > 2)
                result.Errors.Add(ErrorCode.InvalidPrice);

            if (!Regex.IsMatch(feed.Isin ?? "", @"^[A-Z]{2}\d{10}$"))
                result.Errors.Add(ErrorCode.InvalidIsin);

            if (feed.MaturityDate <= feed.ValuationDate)
                result.Errors.Add(ErrorCode.InvalidMaturityDate);

            return result;
        }
    }
}
