using Microsoft.EntityFrameworkCore;
using RegistroDisco.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegistroDisco.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Discos> Discos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source= DATA\Disco.db");
        }
    }
}
