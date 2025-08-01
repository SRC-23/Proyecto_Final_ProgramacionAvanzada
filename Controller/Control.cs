
using Microsoft.AspNetCore.Mvc;
using QueueSystem.Domain.Models;
using QueueSystem.BL.Services;

namespace QueueSystem.UI.Controllers
{
    public class TareasController : Controller
    {
        private readonly TareaServicio _tareaServicio;

        public TareasController(TareaServicio tareaServicio)
        {
            _tareaServicio = tareaServicio;
        }

        public IActionResult Index() => View(_tareaServicio.ObtenerTareas());

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TareaItem tarea)
        {
            if (ModelState.IsValid)
            {
                _tareaServicio.AgregarTarea(tarea);
                return RedirectToAction(nameof(Index));
            }
            return View(tarea);
        }

        public IActionResult Edit(int id)
        {
            var tarea = _tareaServicio.ObtenerTareaPorId(id);
            return tarea == null ? NotFound() : View(tarea);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, TareaItem tarea)
        {
            if (id != tarea.Id) return BadRequest();
            if (ModelState.IsValid)
            {
                _tareaServicio.ActualizarTarea(tarea);
                return RedirectToAction(nameof(Index));
            }
            return View(tarea);
        }

        public IActionResult Delete(int id)
        {
            var tarea = _tareaServicio.ObtenerTareaPorId(id);
            return tarea == null ? NotFound() : View(tarea);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _tareaServicio.EliminarTarea(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Panel() => View(_tareaServicio.ObtenerTareasPorPrioridad());
    }
}