using Application.Abstraction;
using Endpoint.Model;
using Infratructure.Commands;
using Infratructure.Fabrics;
using Microsoft.AspNetCore.Mvc;

namespace Endpoint.Controllers;

[ApiController]
[Route("[controller]")]
public class EndpointController : ControllerBase
{
    private readonly ICommandRepository _commandRepository;
    public EndpointController(ICommandRepository commandRepository)
    {
        _commandRepository = commandRepository;
    }


    [HttpPost(Name = "Endpoint")]
    public IActionResult Get([FromBody] GameActionModel acceptModel)
    {
        _commandRepository.Enqueue(Fabtics.CreateInetrpretCommand(acceptModel));
        return Ok();
    }
}