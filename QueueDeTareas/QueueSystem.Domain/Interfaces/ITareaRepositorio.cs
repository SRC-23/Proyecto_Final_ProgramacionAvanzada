using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using QueueSystem.ML.Models;


namespace QueueSystem.ML.Interfaces
{
    public interface ITareaRepositorio
    {
        Task<List<Tarea>> ObtenerTodasAsync();
        Task<Tarea> ObtenerPorIdAsync(int id);
        Task AgregarAsync(Tarea tarea);
        Task ActualizarAsync(Tarea tarea);
        Task EliminarAsync(int id);

        Tarea ObtenerPorId(int id);
        void Actualizar(Tarea tarea);
        void Eliminar(int id);
    }

}
