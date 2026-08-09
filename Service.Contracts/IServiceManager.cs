namespace Service.Contracts;

public interface IServiceManager
{
    IPublisherService PublisherService { get; }
    IBookService BookService { get; }
}
