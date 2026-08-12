using Shared.DataTransferObjects;

namespace Service.Contracts;

public interface IBookService
{
    IEnumerable<BookDto> GetBooks(Guid publisherId, bool trackChanges);
    BookDto GetBook(Guid publisherId, Guid id, bool trackChanges);
    BookDto CreateBookForPublisher(Guid publisherId, BookForCreationDto bookForCreation, bool trackChanges);
    void DeleteBookForPublisher(Guid publisherId, Guid id, bool trackChanges);
    void UpdateBookForPublisher(Guid publisherId, Guid id, BookForUpdateDto bookForUpdate,
        bool publisherTrackChanges, bool bookTrackChanges);
}
