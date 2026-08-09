using Contracts;
using Entities.Models;
using Service.Contracts;

namespace Service;

internal sealed class PublisherService : IPublisherService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;

    public PublisherService(IRepositoryManager repository, ILoggerManager logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public IEnumerable<Publisher> GetAllPublishers(bool trackChanges)
    {
        try
        {
            return _repository.Publisher.GetAllPublishers(trackChanges);
        }
        catch (Exception exception)
        {
            _logger.LogError($"Something went wrong in the {nameof(GetAllPublishers)} service method {exception}");
            throw;
        }
    }
}
