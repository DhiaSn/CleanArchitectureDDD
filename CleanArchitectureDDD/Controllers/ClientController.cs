using CleanArchitectureDDD.App.DTOs.CarsDTOs;
using CleanArchitectureDDD.App.DTOs.ClientDTOs;
using CleanArchitectureDDD.App.Interfaces;
using CleanArchitectureDDD.App.Parameters;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureDDD.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController(IClientService clientService) : ControllerBase
    {
        private readonly IClientService _clientService = clientService;

        #region GetAll
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] RequestParameter parameter)
        {
            return Ok(await _clientService.GetAllAsync(parameter.PageNumber, parameter.PageSize));
        }
        #endregion

        #region GetById
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            if (id == default)
                return NoContent();
            return Ok(await _clientService.GetByIdAsync(id));
        }
        #endregion

        #region Post
        [HttpPost]
        public async Task<IActionResult> Post(PostClientRequest req)
        {
            if (req == null)
                return NoContent();
            return Ok(await _clientService.PostAsync(req));
        }
        #endregion

        #region Post
        [HttpPost("/car/{clientId}")]
        public async Task<IActionResult> PostCar(Guid clientId, PostCarRequest req)
        {
            if (clientId == default)
                return NoContent();
            if (req == null)
                return NoContent();
            if (clientId != req.ClientId)
                return BadRequest("Id paramater doesn't match with object id");

            return Ok(await _clientService.AddCarAsync(req));
        }
        #endregion

        #region Post
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, PutClientRequest req)
        {
            if (id == default)
                return NoContent();
            if (req == null)
                return NoContent();
            if (id != req.Id)
                return BadRequest("Id paramater doesn't match with object id");

            return Ok(await _clientService.PutAsync(req));
        }
        #endregion

        #region Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == default)
                return NoContent();
            return Ok(await _clientService.DeleteAsync(id));
        }
        #endregion

    }
}
