
using Desafio.Model;

public interface IAlunoRepository
{
    Task<IEnumerable<Aluno>> Get();
    Task<Aluno> Get(long id); // Alterado para long
    Task<Aluno> Create(Aluno aluno);
    Task Update(Aluno aluno);
    Task Delete(long id); // Alterado para long
}
