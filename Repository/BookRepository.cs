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

    public Book? GetBook(Guid publisherId, Guid id, bool trackChanges) =>
        FindByCondition(book => book.PublisherId.Equals(publisherId) && book.Id.Equals(id), trackChanges)
            .SingleOrDefault();

    public void CreateBookForPublisher(Guid publisherId, Book book)
    {
        book.PublisherId = publisherId;
        Create(book);
    }

    public void DeleteBook(Book book) => Delete(book);
}
