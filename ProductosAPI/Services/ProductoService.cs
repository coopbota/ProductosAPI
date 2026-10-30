using ProductosAPI.DTOs;
using ProductosAPI.Models;
using ProductosAPI.Repositories;

namespace ProductosAPI.Services
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _repository;

        public ProductoService(IProductoRepository repository)   // .NET le pasa el repositorio solo
        {
            _repository = repository;
        }
        public bool Actualizar(int id, CreateProductoDTO dto)
        {
            var producto = _repository.ObtenerPorId(id);
            if (producto == null) {
                return false;
            }
            return _repository.Actualizar(producto);
        }

        public ProductoDTO Crear(CreateProductoDTO dto)
        {
            var producto = new Producto              // DTO → entidad
            {
                Nombre = dto.Nombre,
                Precio = dto.Precio,
                Categoria = dto.Categoria,
                Activo = true
            };
            _repository.Agregar(producto);
            return ADto(producto);
        }

        public bool Eliminar(int id)
        {
            return _repository.Eliminar(id);
        }

        public ProductoDTO? ObtenerPorId(int id)
        {
            var producto = _repository.ObtenerPorId(id);
            return producto != null ? ADto(producto) : null;
        }

        public List<ProductoDTO> ObtenerTodos()
        {
            return _repository.ObtenerTodos().Select(ADto).ToList();
        }
        private static ProductoDTO ADto(Producto p)  // la "caja": copia los datos al DTO
        {
            return new ProductoDTO { Id = p.Id, Nombre = p.Nombre, Precio = p.Precio, Categoria = p.Categoria, Activo = p.Activo };
        }
    }
}
