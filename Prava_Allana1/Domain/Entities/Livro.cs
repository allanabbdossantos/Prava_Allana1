namespace Prava_Allana1.Domain.Entities;

public sealed class Livro
{
    private Livro(Guid id, string titulo, string autor, int anoPublicacao, string isbn)
    {
        Id = id;
        Titulo = titulo;
        Autor = autor;
        AnoPublicacao = anoPublicacao;
        Isbn = isbn;
    }

    public Guid Id { get; }

    public string Titulo { get; }

    public string Autor { get; }

    public int AnoPublicacao { get; }

    public string Isbn { get; }

    public static Livro Criar(string? titulo, string? autor, int anoPublicacao, string? isbn)
    {
        var tituloNormalizado = titulo?.Trim();
        if (string.IsNullOrWhiteSpace(tituloNormalizado))
        {
            throw new ArgumentException("O título é obrigatório.", nameof(titulo));
        }

        var autorNormalizado = autor?.Trim();
        if (string.IsNullOrWhiteSpace(autorNormalizado))
        {
            throw new ArgumentException("O autor é obrigatório.", nameof(autor));
        }

        var anoAtual = DateTime.UtcNow.Year;
        if (anoPublicacao < 1 || anoPublicacao > anoAtual)
        {
            throw new ArgumentOutOfRangeException(nameof(anoPublicacao), $"O ano de publicação deve estar entre 1 e {anoAtual}.");
        }

        var isbnNormalizado = NormalizarIsbn(isbn);
        if (!IsbnValido(isbnNormalizado))
        {
            throw new ArgumentException("O ISBN deve ser um ISBN-10 ou ISBN-13 válido.", nameof(isbn));
        }

        return new Livro(Guid.NewGuid(), tituloNormalizado, autorNormalizado, anoPublicacao, isbnNormalizado);
    }

    private static string NormalizarIsbn(string? isbn)
    {
        return string.IsNullOrWhiteSpace(isbn)
            ? string.Empty
            : new string(isbn.Where(caractere => !char.IsWhiteSpace(caractere) && caractere != '-').ToArray()).ToUpperInvariant();
    }

    private static bool IsbnValido(string isbn)
    {
        return isbn.Length switch
        {
            10 => Isbn10Valido(isbn),
            13 => Isbn13Valido(isbn),
            _ => false
        };
    }

    private static bool Isbn10Valido(string isbn)
    {
        if (isbn.Take(9).Any(caractere => !char.IsDigit(caractere)) ||
            (isbn[9] != 'X' && !char.IsDigit(isbn[9])))
        {
            return false;
        }

        var soma = isbn.Take(9).Select((caractere, indice) => (10 - indice) * (caractere - '0')).Sum();
        soma += isbn[9] == 'X' ? 10 : isbn[9] - '0';

        return soma % 11 == 0;
    }

    private static bool Isbn13Valido(string isbn)
    {
        if (isbn.Any(caractere => !char.IsDigit(caractere)))
        {
            return false;
        }

        var soma = isbn.Take(12).Select((caractere, indice) => (indice % 2 == 0 ? 1 : 3) * (caractere - '0')).Sum();
        var digitoVerificador = (10 - soma % 10) % 10;

        return digitoVerificador == isbn[12] - '0';
    }
}
