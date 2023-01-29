using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http;

namespace HW2.Controllers;

[ApiController]
[Route("[controller]")]
public class StoreItemsCOntroller : ControllerBase
{


    private readonly ILogger<StoreItemsCOntroller> _logger;

    public StoreItemsCOntroller(ILogger<StoreItemsCOntroller> logger)
    {
        _logger = logger;
    }


    [HttpGet]
    [ProducesResponseType(200)]

    public IActionResult GetTodos()
    {
        List<StoreItems> c = StoreItemsRepository.getInstance().GetStore();

        var d = JsonConvert.SerializeObject(c);

        return Ok(d);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]

    public IActionResult GetTodo(int id)
    {
        StoreItems store = StoreItemsRepository.getInstance().GetStore(id);

        if (store == null)
        {
            return NotFound();
        }
        else
        {
            return Ok(JsonConvert.SerializeObject(store));
        }
    }
    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public IActionResult CreateTodo([FromBody] StoreItems store)
    {
        if (store == null)
        {
            return BadRequest("Store is null");
        }
        bool result = StoreItemsRepository.getInstance().AddDataToFile(store);
        if (result)
        {
            return Ok("Successfully added");
        }
        else
        {
            return BadRequest("Store not added");
        }
    }
    [HttpPut("{id}")]
    [ProducesResponseType(400)]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]

    public IActionResult UpdateTodo(int id, [FromBody] StoreItems store)
    {
        if (store == null)
        {
            return BadRequest("Todo is null");
        }

        bool isUpdated = StoreItemsRepository.getInstance().UpdateLine(id, store);
        if (!isUpdated)
        {
            return NotFound("No matching Store");
        }
        else
        {
            return Ok("Successfully updated");
        }
    }
    [HttpDelete("{id}")]

    public IActionResult DeleteTodo(int id)
    {
        bool deleted = StoreItemsRepository.getInstance().DeleteLine(id);
        if (!deleted)
        {
            return NotFound("No matching id");
        }
        else
        {
            return Ok("Person deleted");
        }
    }
    [HttpGet("analyze/{type}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]

    public IActionResult GetAnalysis(string type)
    {
        string value = StoreItemsRepository.getInstance().Analyse(type);

        if (value == null)
        {
            return NotFound();
        }
        else
        {
            return Ok(value);
        }
    }
}