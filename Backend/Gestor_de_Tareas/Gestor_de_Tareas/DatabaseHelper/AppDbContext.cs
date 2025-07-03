using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Gestor_de_Tareas.Model;

namespace Gestor_de_Tareas.DatabaseHelper
{
    public class AppDbContext : DbContext

    {

        public AppDbContext(DbContextOptions<AppDbContext> options)

            : base(options) { }

        public DbSet<Tareas> Tareas { get; set; }

    }


}
