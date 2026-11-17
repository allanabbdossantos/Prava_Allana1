const form = document.querySelector('#livro-form');
const bookList = document.querySelector('#book-list');
const emptyState = document.querySelector('#empty-state');
const loading = document.querySelector('#loading');
const bookCount = document.querySelector('#book-count');
const formMessage = document.querySelector('#form-message');
const submitButton = document.querySelector('#submit-button');
const refreshButton = document.querySelector('#refresh-button');

form.addEventListener('submit', cadastrarLivro);
refreshButton.addEventListener('click', carregarLivros);

carregarLivros();

async function carregarLivros() {
    setLoading(true);

    try {
        const resposta = await fetch('/api/livros');
        if (!resposta.ok) {
            throw new Error('Não foi possível carregar o catálogo.');
        }

        const livros = await resposta.json();
        renderizarLivros(livros);
    } catch (erro) {
        renderizarErroCatalogo(erro.message);
    } finally {
        setLoading(false);
    }
}

async function cadastrarLivro(evento) {
    evento.preventDefault();
    limparMensagem();

    const dados = new FormData(form);
    const livro = {
        titulo: dados.get('titulo'),
        autor: dados.get('autor'),
        anoPublicacao: Number(dados.get('anoPublicacao')),
        isbn: dados.get('isbn')
    };

    setSubmitting(true);

    try {
        const resposta = await fetch('/api/livros', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(livro)
        });

        if (!resposta.ok) {
            const erro = await obterMensagemErro(resposta);
            throw new Error(erro);
        }

        form.reset();
        mostrarMensagem('Livro cadastrado com sucesso.', 'success');
        await carregarLivros();
    } catch (erro) {
        mostrarMensagem(erro.message, 'error');
    } finally {
        setSubmitting(false);
    }
}

function renderizarLivros(livros) {
    bookList.replaceChildren();
    bookCount.textContent = livros.length;
    emptyState.hidden = livros.length > 0;

    livros.forEach((livro) => {
        const item = document.createElement('article');
        item.className = 'book-item';

        const capa = document.createElement('span');
        capa.className = 'book-cover';
        capa.textContent = livro.titulo.charAt(0).toUpperCase();
        capa.setAttribute('aria-hidden', 'true');

        const informacoes = document.createElement('div');
        informacoes.className = 'book-info';

        const titulo = document.createElement('p');
        titulo.className = 'book-title';
        titulo.textContent = livro.titulo;
        titulo.title = livro.titulo;

        const autor = document.createElement('p');
        autor.className = 'book-meta';
        autor.textContent = `${livro.autor} · ISBN ${livro.isbn}`;
        autor.title = `${livro.autor} · ISBN ${livro.isbn}`;

        const ano = document.createElement('span');
        ano.className = 'book-year';
        ano.textContent = livro.anoPublicacao;

        informacoes.append(titulo, autor);
        item.append(capa, informacoes, ano);
        bookList.append(item);
    });
}

function renderizarErroCatalogo(mensagem) {
    bookList.replaceChildren();
    bookCount.textContent = '—';
    emptyState.hidden = false;
    emptyState.querySelector('h3').textContent = 'Não foi possível carregar';
    emptyState.querySelector('p').textContent = mensagem;
}

async function obterMensagemErro(resposta) {
    try {
        const corpo = await resposta.json();
        return corpo.erro || corpo.title || 'Verifique os dados informados e tente novamente.';
    } catch {
        return 'Verifique os dados informados e tente novamente.';
    }
}

function setLoading(ativo) {
    loading.hidden = !ativo;
    if (ativo) {
        emptyState.hidden = true;
    }
}

function setSubmitting(ativo) {
    submitButton.disabled = ativo;
    submitButton.querySelector('span').textContent = ativo ? 'Salvando...' : 'Adicionar ao catálogo';
}

function mostrarMensagem(texto, tipo) {
    formMessage.textContent = texto;
    formMessage.className = `message ${tipo}`;
}

function limparMensagem() {
    formMessage.textContent = '';
    formMessage.className = 'message';
}
