using QueueSystem.DAL.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using QueueSystem.ML.Interfaces;
using QueueSystem.ML.Models;


namespace QueueSystem.DAL.Repositories
{
    public class TareaRepositorio : ITareaRepositorio
    {
        private readonly GestionTareasDbContext _context;

        public TareaRepositorio(GestionTareasDbContext context)
        {
            _context = context;
        }

        public async Task<List<Tarea>> ObtenerTodasAsync() =>
            await _context.Tareas.ToListAsync();

        public async Task<Tarea> ObtenerPorIdAsync(int id) =>
            await _context.Tareas.FindAsync(id);

        public async Task AgregarAsync(Tarea tarea)
        {
            _context.Tareas.Add(tarea);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarAsync(Tarea tarea)
        {
            _context.Tareas.Update(tarea);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarAsync(int id)
        {
            var tarea = await _context.Tareas.FindAsync(id);
            if (tarea != null)
            {
                _context.Tareas.Remove(tarea);
                await _context.SaveChangesAsync();
            }
        }
    }

}
