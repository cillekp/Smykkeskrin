using System.Collections.Generic;
using Smykkeskrin.model;

public interface IFeedRepository
{
    IEnumerable<Feed> GetAll();
    Feed GetById(int id);
    Feed Add(Feed feed);
    void Update(Feed feed);
    void Delete(int id);
}
