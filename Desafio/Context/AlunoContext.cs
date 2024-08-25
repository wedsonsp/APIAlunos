using Desafio.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace Desafio.Context
{
    public class AlunoContext : DbContext
    {
        public AlunoContext(DbContextOptions<AlunoContext> options) : base(options)
        {
            
        }

        public DbSet<Aluno> Alunos { get; set; }
    }
}
