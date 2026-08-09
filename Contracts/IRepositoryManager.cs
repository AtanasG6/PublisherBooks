namespace Contracts;

public interface IRepositoryManager
{
    IPublisherRepository Publisher { get; }
    IBookRepository Book { get; }
    void Save();
}
