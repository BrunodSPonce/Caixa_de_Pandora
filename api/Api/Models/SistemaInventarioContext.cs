using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models
{
    public class SistemaInventarioContext : DbContext
    {
        public SistemaInventarioContext(DbContextOptions<SistemaInventarioContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Servidor> Servidores { get; set; }
    }
}
