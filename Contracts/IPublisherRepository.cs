using Entities.Models;

namespace Contracts;

public interface IPublisherRepository
{
    IEnumerable<Publisher> GetAllPublishers(bool trackChanges);
    Publisher? GetPublisher(Guid publisherId, bool trackChanges);
    IEnumerable<Publisher> GetByIds(IEnumerable<Guid> ids, bool trackChanges);
    void CreatePublisher(Publisher publisher);
}
