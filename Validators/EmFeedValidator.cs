using FeedManagerApp.Models;
using FeedManagerApp.Results;

namespace FeedManagerApp.Validators
{
    public class EmFeedValidator : IFeedValidator<EmFeed>
    {
        public ValidateResult Validate(EmFeed feed)
        {
            var result = new ValidateResult();

            if (feed.StagingId < 1 || feed.CounterpartyId < 1 || feed.PrincipalId < 1 || feed.SourceAccountId < 1)
                result.Errors.Add(ErrorCode.InvalidId);

            if (feed.CurrentPrice < 0 || DecimalPlaces(feed.CurrentPrice) > 2)
                result.Errors.Add(ErrorCode.InvalidPrice);

            if (feed.Sedol <= 0 || feed.Sedol >= 100)
                result.Errors.Add(ErrorCode.InvalidSedol);

            if (feed.AssetValue <= 0 || feed.AssetValue >= feed.Sedol)
                result.Errors.Add(ErrorCode.InvalidAssetValue);

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
