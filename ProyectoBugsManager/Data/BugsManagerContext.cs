using Microsoft.EntityFrameworkCore;
using ProyectoBugsManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;




namespace ProyectoBugsManager.Data
{
    public class BugsManagerContext : DbContext
    {
        public BugsManagerContext(DbContextOptions<BugsManagerContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Proyecto> Proyectos { get; set; }
        public DbSet<Error> Errores { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<Proyecto>()
        .HasMany(p => p.Errores)
        .WithOne(e => e.Proyecto)
        .HasForeignKey(e => e.ProjectId);

        modelBuilder.Entity<Usuario>()
        .HasMany(u => u.Errores)
        .WithOne(e => e.User)
        .HasForeignKey(e => e.UserId);
                }
            }
}
