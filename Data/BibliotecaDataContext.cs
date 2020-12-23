using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BibliotecaWeb.Models;

namespace BibliotecaWeb.Data
{
    public class BibliotecaDataContext : DbContext
    {
        public BibliotecaDataContext(DbContextOptions<BibliotecaDataContext> options) : base(options) { }

        public DbSet<Cidade> Cidade { get; set; }
        public DbSet<UF> UF { get; set; }
        public DbSet<Cargo> Cargo { get; set; }
        public DbSet<Emprestimo> Emprestimo { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Funcionario> Funcionario { get; set; }
        public DbSet<Livro> Livro { get; set; }
        public DbSet<Pessoa> Pessoa { get; set; }
        public DbSet<RenovacaoEmp> RenovacaoEmp { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Cargo>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id)
                .HasColumnName("Id_Cargo");

                entity.Property(e => e.Nome)
                .IsRequired();
                entity.HasMany(f => f.Funcionarios);
            });


            // Tem que finalizar esse ainda, provavelmente é o maior q tem!
            modelBuilder.Entity<Emprestimo>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id)
                .HasColumnName("Id_Emprestimo");

                entity.Property(e => e.IdFuncionario)
                .IsRequired();
            });

            modelBuilder.Entity<UF>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id)
                .HasColumnName("Id_UF");

                entity.Property(e => e.Nome)
                .IsRequired();

                entity.Property(e => e.Sigla)
                .IsRequired();

                entity.HasMany(u => u.Cidades);
            });


            modelBuilder.Entity<Cidade>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                .HasColumnName("Id_City");

                entity.Property(e => e.Nome)
                .IsRequired();

                entity.HasOne(c => c.UF)
                .WithMany(u => u.Cidades)
                .HasForeignKey(c => c.IdUF)
                .HasPrincipalKey(u => u.Id);
            });
        }
    }
}
