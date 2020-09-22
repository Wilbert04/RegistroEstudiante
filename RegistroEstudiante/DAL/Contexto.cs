using Microsoft.EntityFrameworkCore;
using RegistroEstudiante.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroEstudiante.DAL
{
    
        public class Contexto : DbContext
        {

        public DbSet<Estudiantes> estudiantes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source= Data\Registro.db");
        }


        // public Contexto(DbContextOptions options) : base(options) { }

        //   public DbSet<Estudiantes> estudiantes { get; set; }
    }
    
}
