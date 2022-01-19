using Microsoft.EntityFrameworkCore;
using XD.UI.Site.Models;

namespace XD.UI.Site.Data
{
    public class MeuDbContext : DbContext
    {
        public MeuDbContext(DbContextOptions options)
        : base(options) 
        {

        }
        public DbSet<Aluno> Alunos { get; set; }
    }
}
