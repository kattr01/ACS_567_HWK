using Microsoft.AspNetCore.Mvc;
using HWK4.Interfaces;
using HWK4.Models;

namespace ItemController.Controllers
{
    [ApiController]
    [Route("car")]
    public class ItemController : ControllerBase
    {
        private readonly ILogger<ItemController> _logger;
        private readonly ICarRepository _CarRepository;

        public ItemController(ILogger<ItemController> logger, ICarRepository CarRepository)
        {
            _logger = logger;
            _CarRepository = CarRepository;
        }
        /// <summary>
        /// Get all Cars
        /// </summary>
        /// <returns></returns>
     
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<Car>))]
        public IActionResult ReadAllCarsData()
        {
            _logger.Log(LogLevel.Information, "Get Cars");
            return Ok(_CarRepository.ReadAllCarsData());
        }
        
        /// <summary>
        /// Get an individual Car by IndexNo
        /// </summary>
        /// <param name="IndexNo"></param>
        /// <returns></returns>

        [HttpGet("{IndexNo}")]
        [ProducesResponseType(200, Type = typeof(Car))]
        public Car GetCarName(int IndexNo)
        {
            return _CarRepository.GetCarName(IndexNo);
        }
        /// <summary>
        /// Using HTTP Post method to 
        /// </summary>
        /// <param name="AddData"></param>
        /// <returns></returns>
        [HttpPost]
        //[ProducesResponseType(200, Type = typeof(List<Car>))]
        public Car AddCarData(Car AddData)
        {

            return _CarRepository.AddCarData(AddData);
        }

        /// <summary>
        /// Edit the data item form the type Car
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>

        [HttpPut]
        //[ProducesResponseType(200, Type = typeof(Car))]
        public Car ModifyCarData([FromBody] Car editCar)
        {

            return _CarRepository.ModifyCarData(editCar);
        }

        /// <summary>
        /// Remove an item from the databasse by the IndexNo
        /// </summary>
        /// <param name="IndexNo"></param>
        /// <returns></returns>
        [HttpDelete("{IndexNo}")]
        public Car RemoveCarData(int IndexNo)
        {
            return _CarRepository.RemoveCarData(IndexNo);
        }

        /// <summary>
        /// Analyse the data
        /// </summary>
        /// <returns></returns>
        [HttpGet("AnalyzeCarData")]
        [ProducesResponseType(200, Type = typeof(List<Car>))]
        public string AnalyzeCarData()
        {
            return _CarRepository.AnalyzeCarData();
        }
    }

}