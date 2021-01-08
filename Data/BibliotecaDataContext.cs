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
                .HasColumnName("id_Cargo");

                entity.Property(e => e.Nome)
                .IsRequired();
                entity.HasMany(f => f.Funcionarios);
            });


            modelBuilder.Entity<Emprestimo>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id)
                .HasColumnName("id_Emprestimo");

                entity.Property(e => e.IdFuncionario)
                .HasColumnName("id_Funcionario")
                .IsRequired();

                entity.Property(e => e.DataDevolucao)
                .IsRequired();
                entity.Property(e => e.Situacao)
                .IsRequired();
                entity.Property(e => e.IdLivro)
                .HasColumnName("id_Livro")
                .IsRequired();
                entity.Property(e => e.IdPessoa)
                .HasColumnName("id_Pessoa")
                .IsRequired();
                entity.HasOne(e => e.Livro)
                .WithMany(l => l.Emprestimos)
                .HasForeignKey(e => e.IdLivro)
                .HasPrincipalKey(l => l.Id);

                entity.HasOne(e => e.Funcionario)
                .WithMany(f => f.Emprestimos)
                .HasForeignKey(e => e.IdFuncionario)
                .HasPrincipalKey(f => f.Id);

                entity.HasOne(e => e.Pessoa)
                .WithMany(p => p.Emprestimos)
                .HasForeignKey(e => e.IdPessoa)
                .HasPrincipalKey(p => p.Id);

                entity.HasMany(e => e.RenovacoesEmp);
            });

            modelBuilder.Entity<UF>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id)
                .HasColumnName("id_UF");

                entity.Property(e => e.Nome)
                .IsRequired();

                entity.Property(e => e.Sigla)
                .IsRequired();
            });


            modelBuilder.Entity<Cidade>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id)
                .HasColumnName("id_Cidade");

                entity.Property(e => e.Nome)
                .IsRequired();

                entity.Property(e => e.IdUF)
                .HasColumnName("id_UF");

                entity.HasOne(c => c.UF)
                .WithMany(u => u.Cidades)
                .HasForeignKey(c => c.IdUF)
                .HasPrincipalKey(u => u.Id);
            });

            modelBuilder.Entity<Endereco>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                .HasColumnName("id_Endereco");

                entity.Property(e => e.Logradouro);
                entity.Property(e => e.Numero)
                .IsRequired();
                entity.Property(e => e.Complemento)
                .IsRequired();
                entity.Property(e => e.Bairro)
                .IsRequired();
                entity.Property(e => e.Cep);

                entity.HasOne(e => e.Cidade)
                .WithMany(c => c.Enderecos)
                .HasForeignKey(e => e.IdCidade)
                .HasPrincipalKey(c => c.Id);

            });

            modelBuilder.Entity<Pessoa>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id)
                .HasColumnName("id_Pessoa");

                entity.Property(e => e.Nome)
                .IsRequired();
                entity.Property(e => e.Telefone);
                entity.Property(e => e.Celular)
                .IsRequired();
                entity.Property(e => e.NumeroRg)
                .IsRequired();
                entity.Property(e => e.DataNascimento)
                .IsRequired();

                entity.HasOne(pessoa => pessoa.Endereco)
                .WithMany(endereco => endereco.Pessoas)
                .HasForeignKey(pessoa => pessoa.IdEndereco)
                .HasPrincipalKey(endereco => endereco.Id);

                entity.HasMany(e => e.Emprestimos);
            });
            modelBuilder.Entity<Funcionario>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id)
                .HasColumnName("id_Funcionario");

                entity.Property(e => e.Salario)
                .IsRequired();
                entity.Property(e => e.NumeroCTPS)
                .IsRequired();
                entity.Property(e => e.DataAdmissao)
                .IsRequired();
                entity.Property(e => e.CargaHoraria)
                .IsRequired();

                entity.HasOne(funcionario => funcionario.Cargo)
                .WithMany(cargo => cargo.Funcionarios)
                .HasForeignKey(funcionario => funcionario.IdCargo)
                .HasPrincipalKey(cargo => cargo.Id);

                entity.HasMany(e => e.Emprestimos);

                entity.HasOne(funcionario => funcionario.Pessoa)
                .WithOne(pessoa => pessoa.Funcionario)
                .HasForeignKey<Funcionario>(f => f.IdPessoa)
                .HasPrincipalKey<Pessoa>(p => p.Id);
            });

            modelBuilder.Entity<RenovacaoEmp>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id)
                .HasColumnName("id_RenovacaoEmp");

                entity.Property(e => e.DataDevolucao)
                .IsRequired();

                entity.HasOne(renovacao => renovacao.Emprestimo)
                .WithMany(emprestimo => emprestimo.RenovacoesEmp)
                .HasForeignKey(renovacao => renovacao.IdEmprestimo)
                .HasPrincipalKey(emprestimo => emprestimo.Id);

            });

            modelBuilder.Entity<Livro>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id)
                .HasColumnName("id_Livro");

                entity.Property(e => e.Nome)
                .IsRequired();
                entity.Property(e => e.Editora)
                .IsRequired();
                entity.Property(e => e.NomeAutor)
                .IsRequired();
                entity.Property(e => e.Ano)
                .IsRequired();
                entity.Property(e => e.Descricao)
                .IsRequired();
                entity.Property(e => e.DataEntrada)
                .IsRequired();
                entity.Property(e => e.QtdCopias)
                .IsRequired();
                entity.Property(e => e.CodigoNacional)
                .IsRequired();
                entity.Property(e => e.CodigoInternacional)
                .IsRequired();

                entity.HasMany(e => e.Emprestimos);
            });
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
