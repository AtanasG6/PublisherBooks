using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service;

internal sealed class BookService : IBookService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;

    public BookService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public IEnumerable<BookDto> GetBooks(Guid publisherId, bool trackChanges)
    {
        var publisher = _repository.Publisher.GetPublisher(publisherId, trackChanges);
        if (publisher is null)
            throw new PublisherNotFoundException(publisherId);

        var booksFromDb = _repository.Book.GetBooks(publisherId, trackChanges);

        return _mapper.Map<IEnumerable<BookDto>>(booksFromDb);
    }
}
