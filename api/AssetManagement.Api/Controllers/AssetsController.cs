using AssetManagement.Application.Abstractions;
using AssetManagement.Application.Models.Assets.Queries;
using AssetManagement.Application.Generics;
using AssetManagement.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AssetManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AssetsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            QueryResult<List<AssetRequestResult>> assets = await _mediator.Send(new AssetRequestQuery());
            return Ok(assets);
        }


        //[HttpGet("{id}")]
        //public async Task<Asset> Get(int id)
        //{
        //    Asset assets = await _mediator.Send(id);
        //    return null;
        //}


        [HttpPost]
        public void Post([FromBody] string value)
        {
        }


        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }


        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
