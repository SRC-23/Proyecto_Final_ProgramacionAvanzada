using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QueueSystem.Domain.Models
{
    public class LogTarea
    {
        public int IdLog { get; set; }
        public int IdTarea { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public string Estado { get; set; }
        public string Mensaje { get; set; }
        public TareaItem Tarea { get; set; }
    }

}
