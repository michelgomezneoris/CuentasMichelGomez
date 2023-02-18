using AutoWrapper.Wrappers;
using CuentasMichelGomez.Dtos.Cuentas;
using CuentasMichelGomez.Services.Cuentas;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CuentasMichelGomez.Controllers
{
    [ApiController]
    [Route("/cuentas")]

    public class CuentaController : ControllerBase
    {

        private readonly ICuentaService _service;

        public CuentaController(ICuentaService service)
        {
            _service = service;
        }

        [HttpPost()]
        public async Task<IActionResult> Create([FromBody] CreateCuenta createRequest)
        {
            ReadCuenta result = await _service.Create(createRequest);
            return Created("/cuenta/" + result.CuentaId, new ApiResponse("Cuenta created.", result, 201));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Read([FromRoute] long id)
        {
            ReadCuenta response = await _service.Read(id);

            if (response != null)
            {
                return Ok(new ApiResponse("Cuenta found.", response, 200));
            }
            else
            {
                return NotFound(new ApiResponse("Cuenta no found.", null, 404));
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] long id, [FromBody] UpdateCuenta updateRequest)
        {
            ReadCuenta response = await _service.Read(id);

            if (response == null)
            {
                return NotFound(new ApiResponse("Cuenta updated.", response, 404));
            }
            else
            {
                if (updateRequest.CuentaId != id)
                {
                    return BadRequest(new ApiResponse("Cuenta Id and id doesn't match", response, 404));
                }

                response = await _service.Update(updateRequest);
                return Ok(new ApiResponse("Cuenta updated.", response, 200));
            }
        }

        [HttpDelete("{id}")]
        public async Task<ApiResponse> Delete([FromRoute] long id)
        {
            await _service.Delete(id);
            return new ApiResponse("Cuenta deleted.", null, 204);
        }

        [HttpGet()]
        public async Task<IActionResult> GetAll()
        {
            ICollection<ReadCuenta> response = await _service.GetAll();
            return Ok(new ApiResponse("Query done!", response, 200));
        }
    }
}
