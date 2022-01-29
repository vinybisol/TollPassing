using Microsoft.AspNetCore.Mvc;
using TollPassing.Models;
using TollPassing.Models.InputModel;
using TollPassing.Services;

namespace TollPassing.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PassingController : ControllerBase
    {
        private readonly IPassingService _passingServices;

        public PassingController(IPassingService passingServices)
        {
            _passingServices = passingServices;
        }

        [HttpPost(Name = "AddPassing")]
        public async Task<ActionResult> AddPassing([FromBody]InputTollPassingModel passing)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(await _passingServices.AddPassing(passing));
        }
    }
}
