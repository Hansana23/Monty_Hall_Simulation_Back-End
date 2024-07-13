using Microsoft.AspNetCore.Mvc;
using MontyHallSimulationTask.Models;
using MontyHallSimulationTask.Services;

namespace MontyHallSimulationTask.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SimulationController : ControllerBase
    {
        private readonly IMontyHallService _service;

        public SimulationController(IMontyHallService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<SimulationResult> Simulate(int numberOfGames, bool changeDoor)
        {
            return _service.Simulate(new SimulationRequest
            {
                NumberOfGames = numberOfGames,
                ChangeDoor = changeDoor
            });
        }

        [HttpPost]
        public ActionResult<SimulationResult> Simulate([FromBody] SimulationRequest request)
        {
            if (request == null)
            {
                return BadRequest("Invalid request."); // Handle null requests
            }

            var result = _service.Simulate(request);

            return Ok(result); // Ensure you're returning a response
        }

        [HttpDelete]
        public IActionResult ClearSimulations()
        {
            _service.ClearSimulations();
            return NoContent();
        }
    }
}
