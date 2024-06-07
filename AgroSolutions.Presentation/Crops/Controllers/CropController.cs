using System.Net.Mime;
using _1_API.Response;
using Agrosolutions.Domain.Crops.Model.Queries;
using AutoMapper;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Presentation.Request;

namespace Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CropController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly ICropCommandService _cropCommandService;
    private readonly ICropQueryService _cropQueryService;
    
    public CropController(ICropQueryService cropQueryService, ICropCommandService cropCommandService, IMapper mapper)
    {
        _cropQueryService = cropQueryService;
        _cropCommandService = cropCommandService;
        _mapper = mapper;
    }
    
    
    /// <summary>
    /// Crea un nuevo calendario.
    /// </summary>
    /// <returns>Devuelve el ID del calendario creado o un error si no se puede crear.</returns>
    /// <response code="201">Si el calendario se crea con éxito, devuelve el ID del calendario.</response>
    /// <response code="400">Si hay un problema con la solicitud, devuelve un error BadRequest.</response>
    /// <response code="409">Si hay un conflicto al crear el calendario, devuelve un error Conflict.</response>
    /// <response code="500">Si hay un error interno del servidor, devuelve un error InternalServerError.</response>
    [HttpPost("Calendar")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(void), StatusCodes.Status409Conflict)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [Produces(MediaTypeNames.Application.Json)]
    public async Task<IActionResult> PostCalendarAsync([FromBody] CreateCalendarCommand command)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var result = await _cropCommandService.Handle(command);

        if (result > 0)
            return StatusCode(StatusCodes.Status201Created, result);

        return BadRequest();
    }
    
    
    /// <summary>
    /// Crea nuevos cultivos.
    /// </summary>
    /// <param name="command">Es el comando para crear cultivos.</param>
    /// <returns>Devuelve el ID de los cultivos creados o un error si no se pueden crear.</returns>
    /// <response code="201">Si los cultivos se crean con éxito, devuelve el ID de los cultivos.</response>
    /// <response code="400">Si hay un problema con la solicitud, devuelve un error BadRequest.</response>
    /// <response code="409">Si hay un conflicto al crear los cultivos, devuelve un error Conflict.</response>
    /// <response code="500">Si hay un error interno del servidor, devuelve un error InternalServerError.</response>
    [HttpPost("Crops")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(void), StatusCodes.Status409Conflict)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [Produces(MediaTypeNames.Application.Json)]
    public async Task<IActionResult> PostCropsAsync([FromBody] CreateCropsCommand command)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var result = await _cropCommandService.Handle(command);

        if (result > 0)
            return StatusCode(StatusCodes.Status201Created, result);

        return BadRequest();
    }

    
    /// <summary>
    /// Crea un nuevo asesor.
    /// </summary>
    /// <param name="command">Es el comando para crear un asesor.</param>
    /// <returns>Devuelve el ID del asesor creado o un error si no se puede crear.</returns>
    /// <response code="201">Si el asesor se crea con éxito, devuelve el ID del asesor.</response>
    /// <response code="400">Si hay un problema con la solicitud, devuelve un error BadRequest.</response>
    /// <response code="409">Si hay un conflicto al crear el asesor, devuelve un error Conflict.</response>
    /// <response code="500">Si hay un error interno del servidor, devuelve un error InternalServerError.</response>
    [HttpPost("Adviser")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(void), StatusCodes.Status409Conflict)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [Produces(MediaTypeNames.Application.Json)]
    public async Task<IActionResult> PostAdviserAsync([FromBody] CreateAdviserCommand command)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var result = await _cropCommandService.Handle(command);

        if (result > 0)
            return StatusCode(StatusCodes.Status201Created, result);

        return BadRequest();
    }

    
    /// <summary>
    /// Obtiene todos los asesores.
    /// </summary>
    /// <returns>Devuelve una lista de asesores o un error si no se encuentran.</returns>
    /// <response code="200">Si se encuentran asesores, devuelve la lista de asesores.</response>
    /// <response code="404">Si no se encuentran asesores, devuelve un error NotFound.</response>
    [HttpGet("Advisers")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Produces(MediaTypeNames.Application.Json)]
    public async Task<IActionResult> GetAllAdvisersAsync()
    {
        var result = await _cropQueryService.Handle(new GetAllAsesoresQuery());
        if (result == null || result.Count == 0) return NotFound();
        return Ok(result);
    }

    
    /// <summary>
    /// Obtiene un asesor por su identificador.
    /// </summary>
    /// <param name="id">Ingresa el id del asesor a obtener:</param>
    /// <returns>Devuelve el asesor si se encuentra o un error si no se encuentra.</returns>
    /// <response code="200">Si el asesor se encuentra, devuelve el asesor.</response>
    /// <response code="404">Si el asesor no se encuentra, devuelve un error NotFound.</response>
    [HttpGet("Adviser/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Produces(MediaTypeNames.Application.Json)]
    public async Task<IActionResult> GetAdviserAsync(int id)
    {
        var result = await _cropQueryService.Handle(new GetAsesorByIdQuery(id));
        if (result == null) StatusCode(StatusCodes.Status404NotFound);
        return Ok(result);
    }
    
    /// <summary>
    /// Obtiene un calendario por su identificador.
    /// </summary>
    /// <param name="id">Ingresa el id del calendario a obtener:</param>
    /// <returns>Devuelve el calendario si se encuentra o un error si no se encuentra.</returns>
    /// <response code="200">Si el calendario se encuentra, devuelve el calendario.</response>
    /// <response code="404">Si el calendario no se encuentra, devuelve un error NotFound.</response>
    [HttpGet("Calendar/ById/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Produces(MediaTypeNames.Application.Json)]
    public async Task<IActionResult> GetCalendarByIdAsync(int id)
    {
        var result = await _cropQueryService.Handle(new GetCalendarioByIdQuery(id));
        if (result == null) StatusCode(StatusCodes.Status404NotFound);
        return Ok(result);
    }

    /// <summary>
    /// Obtiene los cultivos por su identificador.
    /// </summary>
    /// <param name="id">Ingresa el id de los cultivos a obtener:</param>
    /// <returns>Devuelve los cultivos si se encuentran o un error si no se encuentran.</returns>
    /// <response code="200">Si los cultivos se encuentran, devuelve los cultivos.</response>
    /// <response code="404">Si los cultivos no se encuentran, devuelve un error NotFound.</response>
    [HttpGet("Crops/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Produces(MediaTypeNames.Application.Json)]
    public async Task<IActionResult> GetCropsAsync(int id)
    {
        var result = await _cropQueryService.Handle(new GetCultivoByIdQuery(id));
        if (result == null) StatusCode(StatusCodes.Status404NotFound);
        return Ok(result);
    }

    
    /// <summary>
    /// Obtiene todos los calendarios para un cultivo específico.
    /// </summary>
    /// <param name="cultivoId">Ingresa el id del cultivo para el cual obtener los calendarios:</param>
    /// <returns>Devuelve una lista de calendarios o un error si no se encuentran.</returns>
    /// <response code="200">Si se encuentran calendarios, devuelve la lista de calendarios.</response>
    /// <response code="404">Si no se encuentran calendarios, devuelve un error NotFound.</response>
    [HttpGet("Calendar/{cultivoId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Produces(MediaTypeNames.Application.Json)]
    public async Task<IActionResult> GetCalendarsForCultivoAsync(int cultivoId)
    {
        var result = await _cropQueryService.Handle(new GetAllCalendariosForCultivoQuery(cultivoId));
        if (result == null || result.Count == 0) return NotFound();
        return Ok(result);
    }
    
    
    /// <summary>
    /// Obtiene todos los cultivos.
    /// </summary>
    /// <returns>Devuelve una lista de cultivos o un error si no se encuentran.</returns>
    /// <response code="200">Si se encuentran cultivos, devuelve la lista de cultivos.</response>
    /// <response code="404">Si no se encuentran cultivos, devuelve un error NotFound.</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [Produces(MediaTypeNames.Application.Json)]
    public async Task<IActionResult> GetAllCropsAsync()
    {
        var result = await _cropQueryService.Handle(new GetAllCultivosQuery());
        if (result == null || result.Count == 0) return NotFound();
        return Ok(result);
    }
}
