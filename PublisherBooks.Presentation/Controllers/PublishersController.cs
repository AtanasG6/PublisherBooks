using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace PublisherBooks.Presentation.Controllers;

[Route("api/publishers")]
[ApiController]
public class PublishersController : ControllerBase
{
    private readonly IServiceManager _service;

    public PublishersController(IServiceManager service) => _service = service;
}
