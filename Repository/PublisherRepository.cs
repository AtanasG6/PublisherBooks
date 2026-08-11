using Contracts;
using Entities.Models;

namespace Repository;

public class PublisherRepository : RepositoryBase<Publisher>, IPublisherRepository
{
    public PublisherRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    {
    }

    public IEnumerable<Publisher> GetAllPublishers(bool trackChanges) =>
        FindAll(trackChanges)
            .OrderBy(publisher => publisher.Name)
            .ToList();

    public Publisher? GetPublisher(Guid publisherId, bool trackChanges) =>
        FindByCondition(publisher => publisher.Id.Equals(publisherId), trackChanges)
            .SingleOrDefault();

    public IEnumerable<Publisher> GetByIds(IEnumerable<Guid> ids, bool trackChanges) =>
        FindByCondition(publisher => ids.Contains(publisher.Id), trackChanges)
            .ToList();

    public void CreatePublisher(Publisher publisher) => Create(publisher);
}
