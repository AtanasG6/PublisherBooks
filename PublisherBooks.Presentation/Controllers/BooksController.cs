using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace PublisherBooks.Presentation.Controllers;

[Route("api/publishers/{publisherId}/books")]
[ApiController]
public class BooksController : ControllerBase
{
    private readonly IServiceManager _service;

    public BooksController(IServiceManager service) => _service = service;

    [HttpGet]
    public IActionResult GetBooksForPublisher(Guid publisherId)
    {
        var books = _service.BookService.GetBooks(publisherId, trackChanges: false);

        return Ok(books);
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetBookForPublisher(Guid publisherId, Guid id)
    {
        var book = _service.BookService.GetBook(publisherId, id, trackChanges: false);

        return Ok(book);
    }
}
