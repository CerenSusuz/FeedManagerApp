using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedManagerApp.Repositories
{
    public interface IDatabaseRepository
    {
        List<T> LoadFeeds<T>();
        void SaveFeed<T>(T feed);
        void SaveErrors(int feedStagingId, List<string> errors);
    }
}
