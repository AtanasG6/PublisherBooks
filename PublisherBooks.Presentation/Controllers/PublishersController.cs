using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace PublisherBooks.Presentation.Controllers;

[Route("api/publishers")]
[ApiController]
public class PublishersController : ControllerBase
{
    private readonly IServiceManager _service;

    public PublishersController(IServiceManager service) => _service = service;

    [HttpGet]
    public IActionResult GetPublishers()
    {
        var publishers = _service.PublisherService.GetAllPublishers(trackChanges: false);

        return Ok(publishers);
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetPublisher(Guid id)
    {
        var publisher = _service.PublisherService.GetPublisher(id, trackChanges: false);

        return Ok(publisher);
    }
}
