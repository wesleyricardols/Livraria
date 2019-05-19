function ViewModel() {
    var self = this;

    self.booksList = ko.observableArray([]);

    self.id = ko.observable();
    self.titulo = ko.observable();
    self.tituloAtual = ko.observable();
    self.editora = ko.observable();
    self.anoPublicacao = ko.observable();
    self.autor = ko.observable();
    self.qtdeExemplares = ko.observable();

    self.btnCreateBook = function () {
        $("#divListBook").hide();
        $("#divEditBook").hide();
        $("#divCreateBook").show();
    };

    self.createBook = function () {
        var request = {
            "Titulo": self.titulo(),
            "Editora": self.editora(),
            "AnoPublicacao": self.anoPublicacao(),
            "Autor": self.autor(),
            "QtdeExemplares": self.qtdeExemplares()
        };

        PostLivro(request);
    };

    self.saveEditBook = function () {
        var request = {
            "Id": self.id(),
            "Titulo": self.titulo(),
            "CurrentTitle": self.tituloAtual(),
            "Editora": self.editora(),
            "AnoPublicacao": self.anoPublicacao(),
            "Autor": self.autor(),
            "QtdeExemplares": self.qtdeExemplares()
        };

        PutLivro(request);
    };

    self.loadData = function () {
        GetLivros();
    };
}

function Livro(item) {
    var self = this;

    self.id = ko.observable(item.id);
    self.titulo = ko.observable(item.titulo);
    self.editora = ko.observable(item.editora);
    self.anoPublicacao = ko.observable(item.anoPublicacao);
    self.autor = ko.observable(item.autor);
    self.exemplares = ko.observableArray(item.exemplares);

    self.editBook = function (item) {
        viewModel.id(item.id());
        viewModel.titulo(item.titulo());
        viewModel.tituloAtual(item.titulo());
        viewModel.editora(item.editora());
        viewModel.anoPublicacao(item.anoPublicacao());
        viewModel.autor(item.autor());
        viewModel.qtdeExemplares(item.exemplares().length);

        $("#divEditBook").show();
        $("#divCreateBook").hide();
        $("#divListBook").hide();
    };

    self.deleteBook = function (item) {
        var deleteConfirm = confirm("Ao excluir este Livro todos os seus Exemplares também serão excluídos. Confirmar exclusão?");

        if (deleteConfirm === false)
            return;

        var request = {
            "Id": self.id(),
            "Titulo": self.titulo(),
            "Editora": self.editora(),
            "AnoPublicacao": self.anoPublicacao(),
            "Autor": self.autor(),
            "QtdeExemplares": 0
        };

        DeleteLivro(request);
    };
}

$(document).ready(function () {
    viewModel = new ViewModel();

    ko.applyBindings(viewModel);
    viewModel.loadData();
});