using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QueueSystem.Domain.Interfaces
{
    public interface ITareaRepositorio
    {
        Task<List<TareaItem>> ObtenerTodasAsync();
        Task<TareaItem> ObtenerPorIdAsync(int id);
        Task AgregarAsync(TareaItem tarea);
        Task ActualizarAsync(TareaItem tarea);
        Task EliminarAsync(int id);
    }

}
