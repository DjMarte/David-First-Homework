using Microsoft.EntityFrameworkCore;
using Primera_Tarea.Models;

namespace Primera_Tarea.DAL
{
	public class Contexto : DbContext
	{
        public Contexto(DbContextOptions<Contexto> options) : base(options) 
        {
            
        }

        public DbSet<Productos> Productos { get; set; }
    }
}
