using AutoWrapper.Wrappers;
using CuentasMichelGomez.Dtos.Movimientos;
using CuentasMichelGomez.Services.Movimientos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CuentasMichelGomez.Controllers
{
    [ApiController]
    [Route("/movimientos")]

    public class MovimientoController : ControllerBase
    {

        private readonly IMovimientoService _service;

        public MovimientoController(IMovimientoService service)
        {
            _service = service;
        }

        [HttpPost()]
        public async Task<IActionResult> Create([FromBody] CreateMovimiento createRequest)
        {
            bool tieneSaldo = await _service.HasSaldo(createRequest);

            if(!tieneSaldo)
            {
                return BadRequest(new ApiResponse("Saldo insuficiente", null, 400));
            }

            ReadMovimiento result = await _service.Create(createRequest);

            return Created("/Movimiento/" + result.MovimientoId, new ApiResponse("Movimiento created.", result, 201));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Read([FromRoute] long id)
        {
            ReadMovimiento response = await _service.Read(id);

            if (response != null)
            {
                return Ok(new ApiResponse("Movimiento found.", response, 200));
            }
            else
            {
                return NotFound(new ApiResponse("Movimiento no found.", null, 404));
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] long id, [FromBody] UpdateMovimiento updateRequest)
        {
            ReadMovimiento response = await _service.Read(id);

            if (response == null)
            {
                return NotFound(new ApiResponse("Movimiento updated.", response, 404));
            }
            else
            {
                if (updateRequest.MovimientoId != id)
                {
                    return BadRequest(new ApiResponse("Movimiento Id and id doesn't match", response, 404));
                }

                response = await _service.Update(updateRequest);
                return Ok(new ApiResponse("Movimiento updated.", response, 200));
            }
        }

        [HttpDelete("{id}")]
        public async Task<ApiResponse> Delete([FromRoute] long id)
        {
            await _service.Delete(id);
            return new ApiResponse("Movimiento deleted.", null, 204);
        }

        [HttpGet()]
        public async Task<IActionResult> GetAll()
        {
            ICollection<ReadMovimiento> response = await _service.GetAll();
            return Ok(new ApiResponse("Query done!", response, 200));
        }
    }
}
