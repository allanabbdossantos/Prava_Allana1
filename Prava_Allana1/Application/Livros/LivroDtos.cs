namespace Prava_Allana1.Application.Livros;

public sealed record CriarLivroRequest(
    string? Titulo,
    string? Autor,
    int AnoPublicacao,
    string? Isbn);

public sealed record LivroResponse(
    Guid Id,
    string Titulo,
    string Autor,
    int AnoPublicacao,
    string Isbn);
