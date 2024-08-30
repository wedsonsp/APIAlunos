using Desafio.Model;
using Desafio.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Desafio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoRepository _alunoRepository;

        public AlunoController(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aluno>>> GetAlunos()
        
        {
            var alunos = await _alunoRepository.Get();
            return Ok(alunos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Aluno>> GetAluno(int id)
        {
            var aluno = await _alunoRepository.Get(id);
            if (aluno == null)
                return NotFound();
            return Ok(aluno);
        }

        [HttpPost]
        public async Task<ActionResult<Aluno>> PostAluno([FromBody] Aluno aluno)
        {
            // Log para depuração
            Console.WriteLine("PostAluno chamado");

            if (!ModelState.IsValid)
            {
                // Log para verificar ModelState
                foreach (var error in ModelState)
                {
                    Console.WriteLine($"Key: {error.Key}, Value: {error.Value}");
                }

                return BadRequest(ModelState);
            }

            // Log para verificar o objeto aluno recebido
            Console.WriteLine($"Aluno recebido : {aluno.Nome}, {aluno.Idade}");

            var newAluno = await _alunoRepository.Create(aluno);
            return CreatedAtAction(nameof(GetAluno), new { id = newAluno.Id }, newAluno);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var alunoToDelete = await _alunoRepository.Get(id);
            if (alunoToDelete == null)
                return NotFound();

            await _alunoRepository.Delete(alunoToDelete.Id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutAluno(int id, [FromBody] Aluno aluno)
        {
            // Verificar se o ID do corpo da requisição corresponde ao ID na URL
            if (id != aluno.Id)
                return BadRequest("O ID do corpo da requisição não corresponde ao ID na URL.");

            // Buscar o aluno existente no banco de dados
            var existingAluno = await _alunoRepository.Get(id);
            if (existingAluno == null)
                return NotFound();

            // Atualizar as propriedades do aluno existente com os novos valores
            existingAluno.Nome = aluno.Nome;
            existingAluno.Idade = aluno.Idade;
            existingAluno.N1 = aluno.N1;
            existingAluno.N2 = aluno.N2;
            existingAluno.Professor = aluno.Professor;
            existingAluno.Sala = aluno.Sala;

            // Atualizar a entidade existente no banco de dados
            try
            {
                await _alunoRepository.Update(existingAluno);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                // Tratar exceção de concorrência
                return StatusCode(StatusCodes.Status409Conflict, "Ocorreu um erro de concorrência ao tentar atualizar o aluno.");
            }
            catch (Exception ex)
            {
                // Tratar outras exceções
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro ao atualizar o aluno.");
            }

            return NoContent();
        }

    }

}