namespace Prava_Allana1.Application.Livros;

public sealed class IsbnDuplicadoException(string isbn)
    : Exception($"Já existe um livro cadastrado com o ISBN '{isbn}'.");
