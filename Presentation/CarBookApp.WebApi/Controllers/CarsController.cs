using Application.Features.Commands.CarCommands;
using Application.Features.Handlers.CarHandlers;
using Application.Features.Queries.CarQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBookApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly RemoveCarCommandHandler _removeCarCommandHandler;
        private readonly CreateCarCommandHandler _addCarCommandHandler;
        private readonly UpdateCarCommandHandler _updateCarCommandHandler;
        private readonly GetCarByIdQueryHandler _getCarByIdQueryHandler;
        private readonly GetCarQueryHandler _getCarQueryHandler;
        private readonly GetCarWithBrandQueryHandler _getCarWithBrandQueryHandler;
        public CarsController(RemoveCarCommandHandler removeCarCommandHandler, CreateCarCommandHandler addCarCommandHandler, GetCarByIdQueryHandler getCarByIdQueryHandler, GetCarQueryHandler getCarQueryHandler, UpdateCarCommandHandler updateCarCommandHandler, GetCarWithBrandQueryHandler getCarWithBrandQueryHandler)
        {
            _removeCarCommandHandler = removeCarCommandHandler;
            _addCarCommandHandler = addCarCommandHandler;
            _getCarByIdQueryHandler = getCarByIdQueryHandler;
            _getCarQueryHandler = getCarQueryHandler;
            _updateCarCommandHandler = updateCarCommandHandler;
            _getCarWithBrandQueryHandler = getCarWithBrandQueryHandler;
        }
        [HttpGet]
        public async Task<IActionResult> GetCars()
        {
            var result = await _getCarQueryHandler.Handle();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarById(int id)
        {
            var result = await _getCarByIdQueryHandler.Handle(new GetCarByIdQuery(id));
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> AddCar([FromBody] CreateCarCommand command)
        {
            if (command == null)
            {
                return BadRequest("Invalid car data.");
            }
            await _addCarCommandHandler.Handle(command);
            return Ok("Car added successfully.");
            
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCar([FromBody] UpdateCarCommand command)
        {
            if (command == null)
            {
                return BadRequest("Invalid car data.");
            }
            await _updateCarCommandHandler.Handle(command);
            return Ok("Car updated successfully.");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveCar(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid car ID.");
            }
            await _removeCarCommandHandler.Handle(new RemoveCarCommand(id));
            return Ok("Car removed successfully.");
        }
        [HttpGet("with-brand")]
        public async Task<IActionResult> GetCarsWithBrand()
        {
            var result = await _getCarWithBrandQueryHandler.Handle();
            if (result == null || !result.Any())
            {
                return NotFound("No cars found.");
            }
            return Ok(result);
        }
    }
}
