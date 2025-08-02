using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueSystem.ML.Models
{
    public class Tarea
    {
            public int IdTarea { get; set; }
            public string Titulo { get; set; }
            public string Descripcion { get; set; }
            public string Prioridad { get; set; }
            public DateTime FechaCreacion { get; set; }
            public DateTime FechaInicio { get; set; }
            public string Estado { get; set; }
            public string Resultado { get; set; }
            public DateTime? FechaFinalizacion { get; set; }

            public ICollection<LogTarea> Logs { get; set; }
            public ICollection<Notificacion> Notificaciones { get; set; }

    }
}
