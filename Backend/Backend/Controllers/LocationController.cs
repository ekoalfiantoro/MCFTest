using Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class locationController : Controller
    {
        private readonly ILocationService _LocationService;
        public locationController(ILocationService _LocationService)
        {
            this._LocationService = _LocationService;
        }

        [HttpGet]
        [Route("GetLocation")]
        [Produces("application/json")]
        public async Task<IActionResult> GetLocation()
        {
            try
            {
                var listLocation = await _LocationService.GetLocation();
                return Ok(listLocation);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
