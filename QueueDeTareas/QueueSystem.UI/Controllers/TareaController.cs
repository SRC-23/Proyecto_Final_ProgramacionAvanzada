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
        public async Task<IActionResult> Crear(Tarea tarea)
        {
            if (!ModelState.IsValid)
                return View(tarea);

            await _tareaServicio.CrearTareaAsync(tarea);
            return RedirectToAction(nameof(Index));
        }

    }
}

