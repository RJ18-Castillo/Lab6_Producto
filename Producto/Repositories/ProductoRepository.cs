using System.Collections.Generic;
using System.Linq;
using Producto.Data;
using Producto.Models;

namespace Producto.Repositories
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly AppDbContext _context;

        public ProductoRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Producto.Models.Producto> ObtenerTodos()
        {
            return _context.Productos.ToList();
        }

        public Producto.Models.Producto ObtenerPorId(int id)
        {
            return _context.Productos.Find(id);
        }

        public void Agregar(Producto.Models.Producto p)
        {
            _context.Productos.Add(p);
            _context.SaveChanges();
        }

        public void Actualizar(Producto.Models.Producto p)
        {
            _context.Productos.Update(p);
            _context.SaveChanges();
        }

        public void Eliminar(int id)
        {
            var producto = _context.Productos.Find(id);
            if (producto != null)
            {
                _context.Productos.Remove(producto);
                _context.SaveChanges();
            }
        }
    }
}