using Desafio.Context;
using Desafio.Model;
using Desafio.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace Desafio.Repositories
{
    public class AlunoRepository : IAlunoRepository
    {
        public readonly AlunoContext _context;

        public AlunoRepository(AlunoContext context)
        {
            _context = context;
        }

        public async Task<Aluno> Create(Aluno aluno) { 

           _context.Alunos.Add(aluno);
            await _context.SaveChangesAsync();
            return aluno;
        }

        public async Task Delete(int Id)
        {
            var alunoDelete = await _context.Alunos.FindAsync(Id);
            _context.Alunos.Remove(alunoDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Aluno>> Get()
        {

            return await _context.Alunos.ToListAsync();
        }

        public async Task<Aluno> Get(int Id)
        {

            return await _context.Alunos.FindAsync(Id);
        }

        public async Task Update(Aluno aluno)
        {

            _context.Entry(aluno).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

    }
}
