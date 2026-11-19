using Smykkeskrin.Model;
using Smykkeskrin.Repo;

public class FeedService
{
    private readonly IFeedRepository _feedRepository;

    public FeedService(IFeedRepository feedRepository)
    {
        _feedRepository = feedRepository;
    }

    // Create
    public Feed CreateFeed(string description)
    {
        var feed = new Feed
        {
            Description = description,
            CreatedOn = DateTime.Now
        };
        return _feedRepository.Add(feed);
    }

    // Read (all feeds)
    public IEnumerable<Feed> GetAllFeeds()
    {
        return _feedRepository.GetAll();
    }

    // Read (one feed)
    public Feed GetFeedById(int id)
    {
        return _feedRepository.GetById(id);
    }

    // Update
    public void UpdateFeed(int id, string description)
    {
        var feed = _feedRepository.GetById(id);
        if (feed != null)
        {
            feed.Description = description;
            _feedRepository.Update(feed);
        }
    }

    // Delete
    public void DeleteFeed(int id)
    {
        _feedRepository.Delete(id);
    }
}
