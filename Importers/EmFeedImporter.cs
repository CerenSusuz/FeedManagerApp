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
    public class EmFeedImporter : FeedImporterBase<EmFeed>
    {
        public EmFeedImporter(IDatabaseRepository repository) : base(repository) { }

        protected override IFeedValidator<EmFeed> GetValidator() => new EmFeedValidator();
        protected override IFeedMatcher<EmFeed> GetMatcher() => new EmFeedMatcher();
    }
}
