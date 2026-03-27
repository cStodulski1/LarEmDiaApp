using LarEmDia.Domain.Categorias;
using LarEmDia.Domain.Pessoas;
using LarEmDia.Domain.Transacoes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LarEmDia.Infrastructure.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Transacao> Transacoes { get; set; }

        //aqui eu defini as configurações necessárias para o mapeamento das entidades com o banco de dados,
        //como chaves primárias, tipos de dados e relacionamentos

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Pessoa>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nome).IsRequired().HasMaxLength(200);
            });

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Descricao).IsRequired().HasMaxLength(400);
                entity.Property(e => e.Finalidade).IsRequired();
            });

            modelBuilder.Entity<Transacao>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Valor).HasPrecision(18, 2);
                entity.Property(e => e.Descricao).HasMaxLength(400);
                entity.Property(e => e.Finalidade);

                entity.HasOne<Pessoa>()
                      .WithMany()
                      .HasForeignKey(nameof(Transacao.PessoaId))
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne<Categoria>()
                      .WithMany()
                      .HasForeignKey(nameof(Transacao.CategoriaId))
                      .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
