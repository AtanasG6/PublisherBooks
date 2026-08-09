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
}
