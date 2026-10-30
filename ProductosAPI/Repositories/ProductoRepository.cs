using ProductosAPI.Models;

namespace ProductosAPI.Repositories
{
    public class ProductoRepository : IProductoRepository
    {
        private static readonly List<Producto> _productos = new()
        {
            new Producto { Id = 1, Nombre = "Torta de chocolate", Precio = 15000m, Categoria = "Tortas", Activo = true },
            new Producto { Id = 2, Nombre = "Medialuna", Precio = 800m, Categoria = "Facturas", Activo = true },
            new Producto { Id = 3, Nombre = "Cheesecake", Precio = 18000m, Categoria = "Tortas", Activo = true }
        };

        public bool Actualizar(Producto producto)
        {
            var index = _productos.FindIndex(p => p.Id == producto.Id);
            if (index == -1)
            {
                return false;
            }
            _productos[index] = producto;
            return true;
        }

        public void Agregar(Producto producto)
        {
            producto.Id = _productos.Count == 0 ? 1 : _productos.Max(p => p.Id) + 1;   // el Id lo pone el repositorio
            _productos.Add(producto);
            
        }

        public bool Eliminar(int id)
        {
            var producto = ObtenerPorId(id);
            if (producto == null) {
                return false;
            }
            _productos.Remove(producto);
            return true;    
        }

        public Producto? ObtenerPorId(int id)
        {
            return _productos.FirstOrDefault(p => p.Id == id);
        }

        public List<Producto> ObtenerTodos()
        {
            return _productos;
        }
    }
}
