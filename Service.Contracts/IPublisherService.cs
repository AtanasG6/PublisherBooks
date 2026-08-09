using Entities.Models;

namespace Service.Contracts;

public interface IPublisherService
{
    IEnumerable<Publisher> GetAllPublishers(bool trackChanges);
}
