using Prava_Allana1.Application.Livros;
using Prava_Allana1.Domain.Entities;

namespace Prava_Allana1.Infrastructure.Livros;

public sealed class InMemoryLivroRepository : ILivroRepository
{
    private readonly List<Livro> livros = [];
    private readonly Lock sincronizacao = new();

    public IReadOnlyCollection<Livro> Listar()
    {
        lock (sincronizacao)
        {
            return livros.OrderBy(livro => livro.Titulo).ToArray();
        }
    }

    public Livro? ObterPorIsbn(string isbn)
    {
        lock (sincronizacao)
        {
            return livros.FirstOrDefault(livro => livro.Isbn.Equals(isbn, StringComparison.OrdinalIgnoreCase));
        }
    }

    public void Adicionar(Livro livro)
    {
        lock (sincronizacao)
        {
            livros.Add(livro);
        }
    }
}
