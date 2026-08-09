using Contracts;

namespace Repository;

public sealed class RepositoryManager : IRepositoryManager
{
    private readonly RepositoryContext _repositoryContext;
    private readonly Lazy<IPublisherRepository> _publisherRepository;
    private readonly Lazy<IBookRepository> _bookRepository;

    public RepositoryManager(RepositoryContext repositoryContext)
    {
        _repositoryContext = repositoryContext;
        _publisherRepository = new Lazy<IPublisherRepository>(() => new PublisherRepository(repositoryContext));
        _bookRepository = new Lazy<IBookRepository>(() => new BookRepository(repositoryContext));
    }

    public IPublisherRepository Publisher => _publisherRepository.Value;

    public IBookRepository Book => _bookRepository.Value;

    public void Save() => _repositoryContext.SaveChanges();
}
