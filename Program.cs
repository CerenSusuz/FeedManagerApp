using FeedManagerApp.Imposters;
using FeedManagerApp.Matchers;
using FeedManagerApp.Models;
using FeedManagerApp.Repositories;
using FeedManagerApp.Validators;

var repo = new InMemoryDatabaseRepository();
var deltaImporter = new Delta1FeedImporter(
    new DeltaOneFeedValidator(), new DeltaOneFeedMatcher(), repo);

deltaImporter.Import(new List<DeltaOneFeed>
{
    new DeltaOneFeed
    {
        StagingId = 1, CounterpartyId = 10, PrincipalId = 20,
        SourceAccountId = 5, CurrentPrice = 100.50m,
        Isin = "US1234567890", ValuationDate = DateTime.Today,
        MaturityDate = DateTime.Today.AddDays(10)
    }
});
