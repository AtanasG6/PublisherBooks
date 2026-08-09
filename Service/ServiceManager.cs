using Contracts;
using Service.Contracts;

namespace Service;

public sealed class ServiceManager : IServiceManager
{
    private readonly Lazy<IPublisherService> _publisherService;
    private readonly Lazy<IBookService> _bookService;

    public ServiceManager(IRepositoryManager repository, ILoggerManager logger)
    {
        _publisherService = new Lazy<IPublisherService>(() => new PublisherService(repository, logger));
        _bookService = new Lazy<IBookService>(() => new BookService(repository, logger));
    }

    public IPublisherService PublisherService => _publisherService.Value;

    public IBookService BookService => _bookService.Value;
}
