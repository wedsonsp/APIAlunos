using Desafio.Model;
using Microsoft.EntityFrameworkCore;
using System;

public class AlunoContext : DbContext
{
    public DbSet<Aluno> Alunos { get; set; }

    public AlunoContext(DbContextOptions<AlunoContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Aluno>().ToTable("Alunos");
    }
}
