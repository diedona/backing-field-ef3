using DDona.BackingFieldEF3.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDona.BackingFieldEF3.Infra.DbContexts
{
    public class SistemaContext : DbContext
    {
        public DbSet<Produto> Produto { get; set; }

        public SistemaContext() : base() { }

        public SistemaContext(DbContextOptions<SistemaContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // todas as configurações normais de entidade viriam aqui

            modelBuilder.Entity<Produto>().HasKey(x => x.Id);

            // código abreviado por claridade
        }
    }
}
