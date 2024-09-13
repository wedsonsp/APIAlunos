

using Desafio.Model;
using Microsoft.EntityFrameworkCore;

namespace Desafio.Repositories
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly AlunoContext _context;

        public AlunoRepository(AlunoContext context)
        {
            _context = context;
        }

        public async Task<Aluno> Create(Aluno aluno)
        {
            _context.Alunos.Add(aluno);
            await _context.SaveChangesAsync();
            return aluno;
        }


        public async Task Delete(long id) // Usando long
        {
            var alunoToDelete = await _context.Alunos.FindAsync(id);
            if (alunoToDelete != null)
            {
                _context.Alunos.Remove(alunoToDelete);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException("Aluno não encontrado.");
            }
        }

        public async Task<IEnumerable<Aluno>> Get()
        {
            return await _context.Alunos.ToListAsync();
        }

        public async Task<Aluno> Get(long id) // Usando long
        {
            return await _context.Alunos.FindAsync(id);
        }

        public async Task Update(Aluno aluno)
        {
            // Verificar se o aluno existe antes de atualizar
            var existingAluno = await _context.Alunos.FindAsync(aluno.Id);
            if (existingAluno == null)
            {
                throw new KeyNotFoundException("Aluno não encontrado.");
            }

            // Atualizar as propriedades do aluno existente
            existingAluno.Nome = aluno.Nome;
            existingAluno.Idade = aluno.Idade;
            existingAluno.N1 = aluno.N1;
            existingAluno.N2 = aluno.N2;
            existingAluno.Professor = aluno.Professor;
            existingAluno.Sala = aluno.Sala;

            // Atualizar a entidade no contexto
            _context.Entry(existingAluno).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
