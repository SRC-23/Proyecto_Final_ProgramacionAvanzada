using Microsoft.AspNetCore.Mvc;
using QueueSystem.BL.Services;
using QueueSystem.ML.Models;
using System.Threading;
using System.Threading.Tasks;

namespace QueueSystem.UI.Controllers
{
    public class TareaController : Controller
    {
        private readonly TareaServicio _tareaServicio;

        public TareaController(TareaServicio tareaServicio)
        {
            _tareaServicio = tareaServicio;
        }


        public async Task<IActionResult> Index()
        {
            var tareas = await _tareaServicio.ObtenerTodasTareasAsync();
            return View(tareas);
        }

        public IActionResult Crear()
        {
            return View();
        }

 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(Tarea tarea)
        {
            if (!ModelState.IsValid)
                return View(tarea);

            await _tareaServicio.CrearTareaAsync(tarea);
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Editar(int id)
        {
            var tarea = await _tareaServicio.ObtenerTareaPorIdAsync(id);
            if (tarea == null)
                return NotFound();

            return View(tarea);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(Tarea tarea)
        {
            if (!ModelState.IsValid)
                return View(tarea);

            await _tareaServicio.ActualizarTareaAsync(tarea);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Eliminar(int id)
        {
            var tarea = await _tareaServicio.ObtenerTareaPorIdAsync(id);
            if (tarea == null)
                return NotFound();

            return View(tarea);
        }

        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmarEliminar(int id)
        {
            await _tareaServicio.EliminarTareaAsync(id);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Cola()
        {
            var cola = await _tareaServicio.ObtenerColaTareasAsync();
            return View(cola);
        }

    }
}

