using Application.Homes;
using Application.Homes.RequestDTOs;
using Domain.ModelDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartSaver_API.Controller;

namespace SmartSaver_API.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class HomeController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<HomeDto>>> GetTheatresAsync()
        {
            return HandleResult(await Mediator.Send(new List.Query()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HomeDto>> GetTheatreAsync(Guid id)
        {
            return HandleResult(await Mediator.Send(new Details.Query { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> CreateTheatreAsync(CreateHomeRequestDto home)
        {
            return HandleResult(await Mediator.Send(new Create.Command { Home = home }));
        }

        [HttpGet("user/{id}")]
        public async Task<ActionResult<HomeDto>> GetTheatreAsync(string id)
        {
            return HandleResult(await Mediator.Send(new ListUserHomes.Query { AppUserId = id }));
        }
    }
}
