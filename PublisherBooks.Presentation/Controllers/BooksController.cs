using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

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

    [HttpGet("{id:guid}", Name = "GetBookForPublisher")]
    public IActionResult GetBookForPublisher(Guid publisherId, Guid id)
    {
        var book = _service.BookService.GetBook(publisherId, id, trackChanges: false);

        return Ok(book);
    }

    [HttpPost]
    public IActionResult CreateBookForPublisher(Guid publisherId, [FromBody] BookForCreationDto? book)
    {
        if (book is null)
            return BadRequest("BookForCreationDto object is null");

        var bookToReturn = _service.BookService.CreateBookForPublisher(publisherId, book, trackChanges: false);

        return CreatedAtRoute("GetBookForPublisher", new { publisherId, id = bookToReturn.Id }, bookToReturn);
    }
}
