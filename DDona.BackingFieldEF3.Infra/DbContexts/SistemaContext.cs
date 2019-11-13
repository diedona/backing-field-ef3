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
                .ToTable("Produto")
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

            modelBuilder.Entity<Produto>()
                .HasMany(x => x.Precos)
                .WithOne(x => x.Produto)
                .Metadata.PrincipalToDependent.SetField("_precos");

            #endregion

            #region [ PREÇO X PRODUTO ]

            modelBuilder.Entity<PrecoProduto>()
                .ToTable("PrecoProduto")
                .HasKey(x => x.Id);

            modelBuilder.Entity<PrecoProduto>()
                .Property(x => x.Preco)
                .HasField("_preco");

            modelBuilder.Entity<PrecoProduto>()
                .HasOne(x => x.Produto)
                .WithMany(x => x.Precos)
                .HasForeignKey(x => x.IdProduto);

            #endregion
        }
    }
}
