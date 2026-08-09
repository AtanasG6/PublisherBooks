using AutoMapper;
using Contracts;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service;

internal sealed class PublisherService : IPublisherService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;

    public PublisherService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public IEnumerable<PublisherDto> GetAllPublishers(bool trackChanges)
    {
        var publishers = _repository.Publisher.GetAllPublishers(trackChanges);

        return _mapper.Map<IEnumerable<PublisherDto>>(publishers);
    }
}
