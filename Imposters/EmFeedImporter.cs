using FeedManagerApp.Matchers;
using FeedManagerApp.Models;
using FeedManagerApp.Repositories;
using FeedManagerApp.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedManagerApp.Imposters
{
    public class EmFeedImporter
    {
        private readonly IFeedValidator<EmFeed> _validator;
        private readonly IFeedMatcher<EmFeed> _matcher;
        private readonly IDatabaseRepository _repository;

        public EmFeedImporter(
            IFeedValidator<EmFeed> validator,
            IFeedMatcher<EmFeed> matcher,
            IDatabaseRepository repository)
        {
            _validator = validator;
            _matcher = matcher;
            _repository = repository;
        }

        public void Import(IEnumerable<EmFeed> feeds)
        {
            foreach (var feed in feeds)
            {
                var result = _validator.Validate(feed);

                if (!result.IsValid)
                {
                    _repository.SaveErrors(feed.StagingId, result.Errors);
                    continue;
                }

                var existingFeeds = _repository.LoadFeeds<EmFeed>();
                bool isDuplicate = existingFeeds.Exists(existing => _matcher.Match(feed, existing));

                if (!isDuplicate)
                    _repository.SaveFeed(feed);
            }
        }
    }
}
