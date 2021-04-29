using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiRestCurso.Modelo;
using Microsoft.Extensions.Configuration;


namespace ApiRestCurso.Context
{
    public class AppDbContext: DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options)
            :base(options)
        {}

        public DbSet<Produtos> produtos { get; set; }
        public DbSet<Categoria> categorias { get; set; }

        
    }
}
