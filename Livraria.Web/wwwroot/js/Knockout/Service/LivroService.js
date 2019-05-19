var Urls = {
    getBooks: '/Livro/GetBooks',
    postBooks: '/Livro/PostBook',
    deleteBook: '/Livro/DeleteBook',
    putBook: '/Livro/PutBook'
};

function GetLivros() {
    try {
        $.ajax({
            url: Urls.getBooks,
            type: "GET",
            success: function (data) {
                viewModel.booksList([]);
                if (data !== undefined) {
                    data.forEach(function (item) {
                        viewModel.booksList.push(new Livro(item));
                    });
                }
            },
            error: function (error) {
                console.log('Ocorreu um problema ao recuperar os registros do banco de dados. Erro: ' + error);
            }
        });
    }
    catch (ex) {
        console.log('Ocorreu um problema ao recuperar os registros do banco de dados. Erro: ' + error);
    }
}

function PostLivro(request) {
    try {
        $.ajax({
            url: Urls.postBooks,
            type: "POST",
            data: {
                request: request
            },
            success: function (data) {
                alert(data.message);

                if (data.status === true) {
                    location.reload();
                }
            },
            error: function (error) {
                console.log('Ocorreu um problema ao salvar o registro no banco de dados. Erro: ' + error);
            }
        });
    }
    catch (ex) {
        console.log('Ocorreu um problema ao salvar os registros no banco de dados. Erro: ' + error);
    }
}

function PutLivro(request) {
    try {
        $.ajax({
            url: Urls.putBook,
            type: "PUT",
            data: {
                request: request
            },
            success: function (data) {
                alert(data.message);

                if (data.status === true) {
                    location.reload();
                }
            },
            error: function (error) {
                console.log('Ocorreu um problema ao salvar o registro no banco de dados. Erro: ' + error);
            }
        });
    }
    catch (ex) {
        console.log('Ocorreu um problema ao salvar os registros no banco de dados. Erro: ' + error);
    }
}

function DeleteLivro(request) {
    try {
        $.ajax({
            url: Urls.deleteBook,
            type: "DELETE",
            data: {
                request: request
            },
            success: function (data) {
                alert(data.message);

                if (data.status === true) {
                    location.reload();
                }
            },
            error: function (error) {
                console.log('Ocorreu um problema ao salvar o registro no banco de dados. Erro: ' + error);
            }
        });
    }
    catch (ex) {
        console.log('Ocorreu um problema ao salvar os registros no banco de dados. Erro: ' + error);
    }
}