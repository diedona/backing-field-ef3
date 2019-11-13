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
            // todas as configurações normais de entidade do seu projeto

            #region [ PRODUTO ]

            modelBuilder.Entity<Produto>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Produto>()
                .Property(x => x.Nome)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Produto>()
                .Property(x => x.DataCriado)
                .IsRequired();

            modelBuilder.Entity<Produto>()
                .Property(x => x.PrecoUnidade)
                .IsRequired(false); 

            #endregion
        }
    }
}
