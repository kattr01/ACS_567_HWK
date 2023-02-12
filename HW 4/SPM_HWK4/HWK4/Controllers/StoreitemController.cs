using System;
using HWK4.Interfaces;
using HWK4.Models;
using HWK4.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HWK4.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class StoreitemController : ControllerBase
    {
        private readonly ILogger<StoreitemController> _logger;
        private readonly IStoreitemRepository _StoreitemRepository;
        public StoreitemController(ILogger<StoreitemController> logger, IStoreitemRepository StoreitemRepository)
        {
            _logger = logger;
            _StoreitemRepository = StoreitemRepository;
        }
        /// <summary>
        /// GetStoreitems is to get all the Storeitems in the expeditures .
        /// </summary>
        /// <returns>Storeitems list</returns>

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<Storeitems>))]

        public IActionResult GetStoreitem()
        {
            _logger.Log(LogLevel.Information, "Get Storeitems");
            return Ok(_StoreitemRepository.GetStoreitems());
        }

        /// <summary>
        /// GetStoreitem function gets Storeitem details of the ID given.It returns Storeitems of each ID if it is found else it returns Notfound.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>400(notfound) or Storeitem</returns>

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Storeitems))]
        [ProducesResponseType(400)]

        public IActionResult GetStoreitem(int id)
        {
            Storeitems Storeitem = _StoreitemRepository.GetStoreitem(id);
            if (Storeitem == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(Storeitem);
            }
        }

        
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult createStoreitem(Storeitems Storeitem)
        {

             _StoreitemRepository.CreateStoreitem(Storeitem);

            
                return Ok("Successfully updated");
            
        }





        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]

        public IActionResult UpdateStoreitem(Storeitems Storeitem)
        {
            if (Storeitem == null)
            {
                return BadRequest("Storeitem is null");
            }

            bool isUpdated = _StoreitemRepository.UpdateStoreitem(Storeitem);

            if (!isUpdated)
            {
                return NotFound("No matching ID");
            }
            else
            {
                return Ok("Successfully updated");
            }
        }

        
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult DeleteStoreitem(int id)
        {
            bool deleted = _StoreitemRepository.DeleteStoreitem( id);
            if (!deleted)
            {
                return NotFound("No matching ID");
            }

            else
            {
                return Ok("Storeitem deleted");
            }
        }

        [HttpGet("/Analysis/{name}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult GetAvgStoreitembyname(string name)
        {


            return Ok(_StoreitemRepository.GetStoreitems().Where(temp => temp.Name.ToLower() == name.ToLower()).Average(x=>x.Amount));
        }


    }
}

