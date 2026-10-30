using ProductosAPI.DTOs;

namespace ProductosAPI.Services
{
    public interface IProductoService
    {
        List<ProductoDTO> ObtenerTodos();
        ProductoDTO? ObtenerPorId(int id);
        ProductoDTO Crear(CreateProductoDTO dto);
        bool Actualizar(int id, CreateProductoDTO dto);
        bool Eliminar(int id);
    }
}
