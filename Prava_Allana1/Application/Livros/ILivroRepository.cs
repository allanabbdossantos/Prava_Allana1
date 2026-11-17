using Prava_Allana1.Domain.Entities;

namespace Prava_Allana1.Application.Livros;

public interface ILivroRepository
{
    IReadOnlyCollection<Livro> Listar();

    Livro? ObterPorIsbn(string isbn);

    void Adicionar(Livro livro);
}
