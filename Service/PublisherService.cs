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

    public IEnumerable<PublisherDto> GetByIds(IEnumerable<Guid> ids, bool trackChanges)
    {
        if (ids is null)
            throw new IdParametersBadRequestException();

        var publisherEntities = _repository.Publisher.GetByIds(ids, trackChanges);
        if (ids.Count() != publisherEntities.Count())
            throw new CollectionByIdsBadRequestException();

        return _mapper.Map<IEnumerable<PublisherDto>>(publisherEntities);
    }

    public (IEnumerable<PublisherDto> publishers, string ids) CreatePublisherCollection(
        IEnumerable<PublisherForCreationDto>? publisherCollection)
    {
        if (publisherCollection is null)
            throw new PublisherCollectionBadRequestException();

        var publisherEntities = _mapper.Map<IEnumerable<Publisher>>(publisherCollection);
        foreach (var publisher in publisherEntities)
            _repository.Publisher.CreatePublisher(publisher);

        _repository.Save();

        var publisherCollectionToReturn = _mapper.Map<IEnumerable<PublisherDto>>(publisherEntities);
        var ids = string.Join(",", publisherCollectionToReturn.Select(publisher => publisher.Id));

        return (publishers: publisherCollectionToReturn, ids: ids);
    }
}
