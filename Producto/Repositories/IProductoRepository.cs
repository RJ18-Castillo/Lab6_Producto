using System.Collections.Generic;
using Producto.Models;

namespace Producto.Repositories
{
    public interface IProductoRepository
    {
        IEnumerable<global::Producto.Models.Producto> ObtenerTodos();
        global::Producto.Models.Producto ObtenerPorId(int id);
        void Agregar(global::Producto.Models.Producto p);
        void Actualizar(global::Producto.Models.Producto p);
        void Eliminar(int id);
    }
}