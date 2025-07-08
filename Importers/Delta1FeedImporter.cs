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
    public class Delta1FeedImporter : FeedImporterBase<DeltaOneFeed>
    {
        public Delta1FeedImporter(IDatabaseRepository repository) : base(repository) { }

        protected override IFeedValidator<DeltaOneFeed> GetValidator() => new DeltaOneFeedValidator();
        protected override IFeedMatcher<DeltaOneFeed> GetMatcher() => new DeltaOneFeedMatcher();
    }
}
