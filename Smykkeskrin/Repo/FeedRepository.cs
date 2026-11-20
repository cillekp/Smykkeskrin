using System.Collections.Generic;
using System.Linq;
using Smykkeskrin.Model;

namespace Smykkeskrin.Repo
{
    public class FeedRepository : IFeedRepository
    {
        //List som lokal data lige pt, kan udskiftes med SQL eller whatever
        private static readonly List<Feed> _feeds = new();
        private static int _nextId = 1;

        public IEnumerable<Feed> GetAll()
        {
            return _feeds;
        }

        public Feed GetById(int id)
        {
            return _feeds.FirstOrDefault(f => f.Id == id);
        }

        public Feed Add(Feed feed)
        {
            feed.Id = _nextId++;
            _feeds.Add(feed);
            return feed;
        }

        public void Update(Feed feed)
        {
            var existing = GetById(feed.Id);
            if (existing != null)
            {
                existing.Description = feed.Description;
                existing.CreatedOn = feed.CreatedOn;
            }
        }

        public void Delete(int id)
        {
            var feed = GetById(id);
            if (feed != null)
            {
                _feeds.Remove(feed);
            }
        }
    }
}
