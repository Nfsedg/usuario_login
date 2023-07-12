using System;
using System.Collections.Generic;
using System.Linq;
using Proyecto_Final_23AM.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Final_23AM.Context
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseMySQL("server=localhost; database=ProyectoDb23am; user=root; password=");
        }
        public DbSet<Usuario> Usuarios {get; set;}
        public DbSet<Rol> Roles { get; set; }
    }
}
