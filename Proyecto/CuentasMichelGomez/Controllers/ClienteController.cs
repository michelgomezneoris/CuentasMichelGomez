using AutoWrapper.Wrappers;
using CuentasMichelGomez.Dtos.Clientes;
using CuentasMichelGomez.Services.Clientes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CuentasMichelGomez.Controllers
{
    [ApiController]
    [Route("/clientes")]

    public class ClienteController : ControllerBase
    {

        private readonly IClienteService _service;

        public ClienteController(IClienteService service)
        {
            _service = service;
        }

        [HttpPost()]
        public async Task<IActionResult> Create([FromBody] CreateCliente createRequest)
        {
            ReadCliente result = await _service.Create(createRequest);
            return Created("/Cliente/" + result.ClienteId, new ApiResponse("Cliente created.", result, 201));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Read([FromRoute] long id)
        {
            ReadCliente response = await _service.Read(id);

            if (response != null)
            {
                return Ok(new ApiResponse("Cliente found.", response, 200));
            }
            else
            {
                return NotFound(new ApiResponse("Cliente no found.", null, 404));
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] long id, [FromBody] UpdateCliente updateRequest)
        {
            ReadCliente response = await _service.Read(id);

            if (response == null)
            {
                return NotFound(new ApiResponse("Cliente updated.", response, 404));
            }
            else
            {
                if (updateRequest.ClienteId != id)
                {
                    return BadRequest(new ApiResponse("Cliente Id and id doesn't match", response, 404));
                }

                response = await _service.Update(updateRequest);
                return Ok(new ApiResponse("Cliente updated.", response, 200));
            }
        }

        [HttpDelete("{id}")]
        public async Task<ApiResponse> Delete([FromRoute] long id)
        {
            await _service.Delete(id);
            return new ApiResponse("Cliente deleted.", null, 204);
        }

        [HttpGet()]
        public async Task<IActionResult> GetAll()
        {
            ICollection<ReadCliente> response = await _service.GetAll();
            return Ok(new ApiResponse("Query done!", response, 200));
        }
    }
}
