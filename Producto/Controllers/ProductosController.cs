using Microsoft.AspNetCore.Mvc;
using Producto.Models;
using Producto.Repositories;

namespace Producto.Controllers
{
    public class ProductosController : Controller
    {
        private readonly IProductoRepository _repo;

        public ProductosController(IProductoRepository repo)
        {
            _repo = repo;
        }

        // GET: Productos
        public IActionResult Index()
        {
            var productos = _repo.ObtenerTodos();
            return View(productos);
        }

        // GET: Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Producto.Models.Producto p)
        {
            if (ModelState.IsValid)
            {
                _repo.Agregar(p);
                return RedirectToAction(nameof(Index));
            }
            return View(p);
        }

        // GET: Edit
        public IActionResult Edit(int id)
        {
            var producto = _repo.ObtenerPorId(id);
            if (producto == null)
                return NotFound();

            return View(producto);
        }

        // POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Producto.Models.Producto p)
        {
            if (ModelState.IsValid)
            {
                _repo.Actualizar(p);
                return RedirectToAction(nameof(Index));
            }
            return View(p);
        }

        // GET: Delete
        public IActionResult Delete(int id)
        {
            var producto = _repo.ObtenerPorId(id);
            if (producto == null)
                return NotFound();

            return View(producto);
        }

        // POST: Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _repo.Eliminar(id);
            return RedirectToAction(nameof(Index));
        }
    }
}