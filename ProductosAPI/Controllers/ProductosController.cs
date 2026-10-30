using Microsoft.AspNetCore.Mvc;
using ProductosAPI.DTOs;
using ProductosAPI.Services;

namespace ProductosAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        private readonly IProductoService _service;

        public ProductosController(IProductoService service)
        {
            _service = service;
        }


        [HttpGet]                                    // GET /api/productos
        public IActionResult ObtenerTodos()
        {
            return Ok(_service.ObtenerTodos());      // 200
        }

        [HttpGet("{id}")]                            // GET /api/productos/3
        public IActionResult ObtenerPorId(int id)
        {
            var producto = _service.ObtenerPorId(id);
            if (producto == null) return NotFound(); // 404
            return Ok(producto);                     // 200
        }

        [HttpPost]                                   // POST /api/productos
        public IActionResult Crear([FromBody] CreateProductoDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);   // 400
            var creado = _service.Crear(dto);
            return CreatedAtAction(nameof(ObtenerPorId), new { id = creado.Id }, creado);   // 201
        }

        [HttpPut("{id}")]                            // PUT /api/productos/3
        public IActionResult Actualizar(int id, [FromBody] CreateProductoDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);   // 400
            if (!_service.Actualizar(id, dto)) return NotFound();     // 404
            return NoContent();                                       // 204
        }

        [HttpDelete("{id}")]                         // DELETE /api/productos/3
        public IActionResult Eliminar(int id)
        {
            if (!_service.Eliminar(id)) return NotFound();            // 404
            return NoContent();                                       // 204
        }
    }
}
