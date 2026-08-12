using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
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

    public BookDto GetBook(Guid publisherId, Guid id, bool trackChanges)
    {
        var publisher = _repository.Publisher.GetPublisher(publisherId, trackChanges);
        if (publisher is null)
            throw new PublisherNotFoundException(publisherId);

        var bookFromDb = _repository.Book.GetBook(publisherId, id, trackChanges);
        if (bookFromDb is null)
            throw new BookNotFoundException(id);

        return _mapper.Map<BookDto>(bookFromDb);
    }

    public BookDto CreateBookForPublisher(Guid publisherId, BookForCreationDto bookForCreation, bool trackChanges)
    {
        var publisher = _repository.Publisher.GetPublisher(publisherId, trackChanges);
        if (publisher is null)
            throw new PublisherNotFoundException(publisherId);

        var bookEntity = _mapper.Map<Book>(bookForCreation);

        _repository.Book.CreateBookForPublisher(publisherId, bookEntity);
        _repository.Save();

        return _mapper.Map<BookDto>(bookEntity);
    }

    public void DeleteBookForPublisher(Guid publisherId, Guid id, bool trackChanges)
    {
        var publisher = _repository.Publisher.GetPublisher(publisherId, trackChanges);
        if (publisher is null)
            throw new PublisherNotFoundException(publisherId);

        var bookForPublisher = _repository.Book.GetBook(publisherId, id, trackChanges);
        if (bookForPublisher is null)
            throw new BookNotFoundException(id);

        _repository.Book.DeleteBook(bookForPublisher);
        _repository.Save();
    }

    public void UpdateBookForPublisher(Guid publisherId, Guid id, BookForUpdateDto bookForUpdate,
        bool publisherTrackChanges, bool bookTrackChanges)
    {
        var publisher = _repository.Publisher.GetPublisher(publisherId, publisherTrackChanges);
        if (publisher is null)
            throw new PublisherNotFoundException(publisherId);

        var bookEntity = _repository.Book.GetBook(publisherId, id, bookTrackChanges);
        if (bookEntity is null)
            throw new BookNotFoundException(id);

        _mapper.Map(bookForUpdate, bookEntity);
        _repository.Save();
    }
}
