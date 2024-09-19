using ApiCrud.Controllers;
using ApiCrud.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCrud.Data
{
    public class SistemaTarefasDbContext : DbContext
    {

        public SistemaTarefasDbContext(DbContextOptions<SistemaTarefasDbContext> options) :base(options) { }

        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<TarefaModel> Tarefas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); 
        }

    }
}
