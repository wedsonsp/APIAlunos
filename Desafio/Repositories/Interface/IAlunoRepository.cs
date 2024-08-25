﻿using Desafio.Context;
using Desafio.Model;

namespace Desafio.Repositories.Interface
{
    public interface IAlunoRepository
    {

        Task<IEnumerable<Aluno>> Get();
        Task<Aluno> Get(int Id);
        Task<Aluno> Create(Aluno aluno);
        Task Update(Aluno aluno);
        Task Delete(int Id);
        
       
       
    }
}
