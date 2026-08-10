using Shared.DataTransferObjects;

namespace Service.Contracts;

public interface IBookService
{
    IEnumerable<BookDto> GetBooks(Guid publisherId, bool trackChanges);
}
