using Application.Devices;
using Domain.ModelDTOs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartSaver_API.Controller;

namespace SmartSaver_API.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class DeviceController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<DeviceDto>>> GetTheatresAsync()
        {
            return HandleResult(await Mediator.Send(new List.Query()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DeviceDto>> GetTheatreAsync(Guid id)
        {
            return HandleResult(await Mediator.Send(new Details.Query { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> CreateTheatreAsync(DeviceDto device)
        {
            return HandleResult(await Mediator.Send(new Create.Command { Device = device }));
        }
    }
}
