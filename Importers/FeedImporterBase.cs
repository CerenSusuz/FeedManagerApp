using FeedManagerApp.Matchers;
using FeedManagerApp.Models;
using FeedManagerApp.Repositories;
using FeedManagerApp.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedManagerApp.Importers
{
    public abstract class FeedImporterBase<T> where T : TradeFeed
    {
        protected readonly IDatabaseRepository Repository;

        protected FeedImporterBase(IDatabaseRepository repository)
        {
            Repository = repository;
        }

        public void Import(IEnumerable<T> feeds)
        {
            var existingFeeds = Repository.LoadFeeds<T>();

            foreach (var feed in feeds)
            {
                var result = GetValidator().Validate(feed);

                if (!result.IsValid)
                {
                    Repository.SaveErrors(feed.StagingId, result.Errors);
                    continue;
                }

                bool isDuplicate = existingFeeds.Exists(existing => GetMatcher().Match(feed, existing));

                if (!isDuplicate)
                    Repository.SaveFeed(feed);
            }
        }

        protected abstract IFeedValidator<T> GetValidator();
        protected abstract IFeedMatcher<T> GetMatcher();
    }
}
