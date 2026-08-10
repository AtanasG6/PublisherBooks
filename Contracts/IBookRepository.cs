using Entities.Models;

namespace Contracts;

public interface IBookRepository
{
    IEnumerable<Book> GetBooks(Guid publisherId, bool trackChanges);
}
