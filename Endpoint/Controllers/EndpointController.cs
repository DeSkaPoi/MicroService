using Application.Abstraction;
using Application.AppModel;
using Application.HttpModel;
using Endpoint.Model;
using Infratructure.Commands;
using Infratructure.Fabrics;
using Infratructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Endpoint.Controllers;

[ApiController]
[Route("[controller]")]
public class EndpointController : ControllerBase
{
    private readonly ICommandRepository _commandRepository;
    private readonly IHelperService _helperService;
    public EndpointController(ICommandRepository commandRepository, IHelperService helperService)
    {
        _commandRepository = commandRepository;
        _helperService = helperService;
    }

    [HttpPost("NewGame")]
    public IActionResult CreateGame([FromBody] List<GameObject> acceptModel)
    {
        var game = _helperService.CreateGame(acceptModel, default);
        return Ok(game.Id);
    }

    [HttpPost("Auth")]
    public IActionResult AuthPlayer([FromBody] AuthPlayer acceptModel)
    {
        var token = _helperService.GetToket(acceptModel);
        return Ok(token);
    }

    [Authorize]
    [HttpPost("Endpoint")]
    public IActionResult Get([FromBody] GameActionModel acceptModel)
    {
        _commandRepository.Enqueue(Fabrics.CreateInetrpretCommand(acceptModel));
        return Ok();
    }
}