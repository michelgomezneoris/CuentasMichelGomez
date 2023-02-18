using AutoWrapper.Wrappers;
using CuentasMichelGomez.Dtos.Reportes;
using CuentasMichelGomez.Services.Reportes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CuentasMichelGomez.Controllers
{
    [ApiController]
    [Route("/reportes")]

    public class ReporteController : ControllerBase
    {

        private readonly IReporteService _service;

        public ReporteController(IReporteService service)
        {
            _service = service;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAll([FromQuery] GetAllReporte getAllRequest)
        {
            ICollection<ReadReporte> response = await _service.GetAll(getAllRequest);
            return Ok(new ApiResponse("Query done!", response, 200));
        }
    }
}
