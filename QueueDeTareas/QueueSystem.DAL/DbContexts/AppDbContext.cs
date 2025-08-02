using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using QueueSystem.ML.Models;

namespace QueueSystem.DAL.DbContexts
{
    public class GestionTareasDbContext : DbContext
    {
        public GestionTareasDbContext(DbContextOptions<GestionTareasDbContext> options) : base(options) { }

        public DbSet<Tarea> Tareas { get; set; }
        public DbSet<LogTarea> LogsTareas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Notificacion> Notificaciones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tarea>()
                .HasMany(t => t.Logs)
                .WithOne(l => l.Tarea)
                .HasForeignKey(l => l.IdTarea);

            modelBuilder.Entity<Tarea>()
                .HasMany(t => t.Notificaciones)
                .WithOne(n => n.Tarea)
                .HasForeignKey(n => n.IdTarea);
        }
    }

}