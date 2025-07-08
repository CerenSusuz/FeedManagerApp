using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedManagerApp.Repositories
{
    public class InMemoryDatabaseRepository : IDatabaseRepository
    {
        private readonly Dictionary<string, List<object>> _storage = new();
        private readonly List<string> _errorLog = new();

        public List<T> LoadFeeds<T>()
        {
            var key = typeof(T).Name;

            return _storage.ContainsKey(key)
                ? _storage[key].Cast<T>().ToList()
                : new List<T>();
        }

        public void SaveFeed<T>(T feed)
        {
            var key = typeof(T).Name;

            if (!_storage.ContainsKey(key))
                _storage[key] = new List<object>();

            _storage[key].Add(feed);
        }

        public void SaveErrors(int feedStagingId, List<string> errors)
        {
            foreach (var error in errors)
                _errorLog.Add($"[FeedId {feedStagingId}] {error}");
        }

        public List<string> GetAllErrors() => _errorLog;
    }
}
