using Biblioteca.Dto.Livro;
using Biblioteca.Models;
using Biblioteca.Services.Livro;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        private readonly ILivroInterface _livroInterface;
        public LivroController(ILivroInterface livroInterface)
        {
            _livroInterface = livroInterface;
        }

        [HttpGet("ListarLivros")]
        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> ListarLivros()
        {
            var livros = await _livroInterface.ListarLivros();
            return Ok(livros);
        }

        [HttpGet("BuscarLivroPorId/{idLivro}")]
        public async Task<ActionResult<ResponseModel<LivroModel>>> ListarLivroPorId(int idLivro)
        {
            var livro = await _livroInterface.ListarLivroPorId(idLivro);
            return Ok(livro);
        }

        [HttpGet("BuscarLivroPorIdAutor/{idAutor}")]
        public async Task<ActionResult<ResponseModel<LivroModel>>> ListarLivroPorIdAutor(int idAutor)
        {
            var livro = await _livroInterface.ListarLivroPorIdAutor(idAutor);
            return Ok(livro);
        }

        [HttpPost("CriarLivro")]
        public async Task<ActionResult<List<LivroModel>>> CriarLivro(LivroCriacaoDto livroCriacaoDto)
        {
            var livros = await _livroInterface.CriarLivro(livroCriacaoDto);
            return Ok(livros);
        }

        [HttpPut("EditarLivro")]
        public async Task<ActionResult<List<LivroModel>>> EditarLivro(LivroEdicaoDto livroEdicaoDto)
        {
            var livros = await _livroInterface.EditarLivro(livroEdicaoDto);
            return Ok(livros);
        }

        [HttpDelete("ExcluirLivro")]
        public async Task<ActionResult<List<LivroModel>>> ExcluirLivro(int IdLivro)
        {
            var livros = await _livroInterface.ExcluirLivro(IdLivro);
            return Ok(livros);
        }
    }
}
