using Contracts;
using Entities.Models;

namespace Repository;

public class BookRepository : RepositoryBase<Book>, IBookRepository
{
    public BookRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    {
    }

    public IEnumerable<Book> GetBooks(Guid publisherId, bool trackChanges) =>
        FindByCondition(book => book.PublisherId.Equals(publisherId), trackChanges)
            .OrderBy(book => book.Title)
            .ToList();
}
