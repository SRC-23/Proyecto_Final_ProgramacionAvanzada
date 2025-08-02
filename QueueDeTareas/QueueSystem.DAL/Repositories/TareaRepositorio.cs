using Microsoft.Data.SqlClient;
using QueueSystem.DAL.DbContexts;
using QueueSystem.ML.Interfaces;
using QueueSystem.ML.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


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
        public Tarea ObtenerPorId(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Tarea WHERE IdTarea = @Id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return new Tarea
                    {
                        IdTarea = (int)reader["IdTarea"],
                        NombreTarea = reader["NombreTarea"].ToString(),
                        Prioridad = Convert.ToInt32(reader["Prioridad"]),
                        FechaEjecucion = Convert.ToDateTime(reader["FechaEjecucion"]),
                        Estado = reader["Estado"].ToString()
                    };
                }
                return null;
            }
        }

        public void Actualizar(Tarea tarea)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"UPDATE Tarea SET 
                            NombreTarea = @NombreTarea, 
                            Prioridad = @Prioridad, 
                            FechaEjecucion = @FechaEjecucion, 
                            Estado = @Estado 
                         WHERE IdTarea = @IdTarea";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@NombreTarea", tarea.NombreTarea);
                command.Parameters.AddWithValue("@Prioridad", tarea.Prioridad);
                command.Parameters.AddWithValue("@FechaEjecucion", tarea.FechaEjecucion);
                command.Parameters.AddWithValue("@Estado", tarea.Estado);
                command.Parameters.AddWithValue("@IdTarea", tarea.IdTarea);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Eliminar(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Tarea WHERE IdTarea = @Id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

    }

}
