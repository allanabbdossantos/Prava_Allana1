using Microsoft.AspNetCore.Mvc;
using Prava_Allana1.Application.Livros;

namespace Prava_Allana1.Controllers;

[ApiController]
[Route("api/livros")]
public sealed class LivrosController(LivroService livroService) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyCollection<LivroResponse>), StatusCodes.Status200OK)]
    public ActionResult<IReadOnlyCollection<LivroResponse>> Listar()
    {
        return Ok(livroService.Listar());
    }

    [HttpPost]
    [ProducesResponseType(typeof(LivroResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public ActionResult<LivroResponse> Cadastrar([FromBody] CriarLivroRequest? request)
    {
        if (request is null)
        {
            return BadRequest(new { erro = "O corpo da requisição é obrigatório." });
        }

        try
        {
            var livro = livroService.Cadastrar(request);
            return Created("/api/livros", livro);
        }
        catch (IsbnDuplicadoException exception)
        {
            return Conflict(new { erro = exception.Message });
        }
        catch (ArgumentException exception)
        {
            return BadRequest(new { erro = exception.Message });
        }
    }
}
