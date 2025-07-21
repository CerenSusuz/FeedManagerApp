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
    public class DeltaOneFeedImporter : FeedImporterBase<DeltaOneFeed>
    {
        public DeltaOneFeedImporter(IDatabaseRepository repository) : base(repository) { }

        protected override IFeedValidator<DeltaOneFeed> GetValidator() => new DeltaOneFeedValidator();
        protected override IFeedMatcher<DeltaOneFeed> GetMatcher() => new DeltaOneFeedMatcher();
    }
}
