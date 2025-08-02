using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QueueSystem.ML.Models
{
    public class Notificacion
    {
        public int IdNotificacion { get; set; }
        public int IdTarea { get; set; }
        public DateTime FechaEnvio { get; set; }
        public string Tipo { get; set; }
        public string Destinatario { get; set; }
        public string Descripcion { get; set; }
        public Tarea Tarea { get; set; }
    }
}
