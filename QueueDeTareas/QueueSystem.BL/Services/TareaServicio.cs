using QueueSystem.DAL.Repositories;
using QueueSystem.ML.Interfaces;
using QueueSystem.ML.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QueueSystem.BL.Services
{
    public class TareaServicio
    {
        private readonly ITareaRepositorio _tareaRepositorio;

        public TareaServicio(ITareaRepositorio tareaRepositorio)
        {
            _tareaRepositorio = tareaRepositorio;
        }

        public async Task<List<Tarea>> ObtenerTodasTareasAsync()
        {
            
            return await _tareaRepositorio.ObtenerTodasAsync();
        }

        public async Task<Tarea> ObtenerTareaPorIdAsync(int id)
        {
            return await _tareaRepositorio.ObtenerPorIdAsync(id);
        }

        public async Task CrearTareaAsync(Tarea tarea)
        {
            
            await _tareaRepositorio.AgregarAsync(tarea);
        }

        public async Task ActualizarTareaAsync(Tarea tarea)
        {
            
            await _tareaRepositorio.ActualizarAsync(tarea);
        }

        public async Task EliminarTareaAsync(int id)
        {
            
            await _tareaRepositorio.EliminarAsync(id);
        }
        public Tarea ObtenerPorId(int id)
        {
            return _tareaRepositorio.ObtenerPorId(id);
        }

        public void Actualizar(Tarea tarea)
        {
            _tareaRepositorio.Actualizar(tarea);
        }

        public void Eliminar(int id)
        {
            _tareaRepositorio.Eliminar(id);
        }
        public async Task<List<Tarea>> ObtenerColaTareasAsync()
        {
            var todas = await _tareaRepositorio.ObtenerTodasAsync();

            var colaOrdenada = todas
                .Where(t => t.Estado == "Pendiente")
                .OrderBy(t => t.Prioridad)
                .ThenBy(t => t.FechaCreacion)
                .ToList();

            return colaOrdenada;
        }


    }
}

