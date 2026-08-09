using Contracts;
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
}
