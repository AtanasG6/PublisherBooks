using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
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

    public PublisherDto GetPublisher(Guid publisherId, bool trackChanges)
    {
        var publisher = _repository.Publisher.GetPublisher(publisherId, trackChanges);
        if (publisher is null)
            throw new PublisherNotFoundException(publisherId);

        return _mapper.Map<PublisherDto>(publisher);
    }

    public PublisherDto CreatePublisher(PublisherForCreationDto publisher)
    {
        var publisherEntity = _mapper.Map<Publisher>(publisher);

        _repository.Publisher.CreatePublisher(publisherEntity);
        _repository.Save();

        return _mapper.Map<PublisherDto>(publisherEntity);
    }
}
