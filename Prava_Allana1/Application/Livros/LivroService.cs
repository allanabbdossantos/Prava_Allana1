using Prava_Allana1.Domain.Entities;

namespace Prava_Allana1.Application.Livros;

public sealed class LivroService(ILivroRepository repository)
{
    public LivroResponse Cadastrar(CriarLivroRequest request)
    {
        var livro = Livro.Criar(request.Titulo, request.Autor, request.AnoPublicacao, request.Isbn);

        if (repository.ObterPorIsbn(livro.Isbn) is not null)
        {
            throw new IsbnDuplicadoException(livro.Isbn);
        }

        repository.Adicionar(livro);
        return Mapear(livro);
    }

    public IReadOnlyCollection<LivroResponse> Listar()
    {
        return repository.Listar().Select(Mapear).ToArray();
    }

    private static LivroResponse Mapear(Livro livro)
    {
        return new LivroResponse(
            livro.Id,
            livro.Titulo,
            livro.Autor,
            livro.AnoPublicacao,
            livro.Isbn);
    }
}
