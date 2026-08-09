using Contracts;
using Service.Contracts;
using Shared.DataTransferObjects;

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

    public IEnumerable<PublisherDto> GetAllPublishers(bool trackChanges)
    {
        try
        {
            var publishers = _repository.Publisher.GetAllPublishers(trackChanges);

            return publishers
                .Select(publisher => new PublisherDto(
                    publisher.Id,
                    publisher.Name,
                    string.Join(", ", publisher.City, publisher.Country)))
                .ToList();
        }
        catch (Exception exception)
        {
            _logger.LogError($"Something went wrong in the {nameof(GetAllPublishers)} service method {exception}");
            throw;
        }
    }
}
