CREATE DATABASE livraria;
USE DATABASE livraria;

CREATE TABLE Livros (
	LivroId INT NOT NULL IDENTITY(1,1),
	Titulo VARCHAR(200) NOT NULL,
	Editora VARCHAR(200) NOT NULL,
	AnoPublicacao INT NOT NULL,
	Autor VARCHAR(200) NOT NULL

	CONSTRAINT [PkLivros] PRIMARY KEY(LivroId),
	CONSTRAINT [UkTitulo] UNIQUE (Titulo) -- Garante que não será permitido cadastrar Livros com o mesmo Título
);

CREATE TABLE Exemplares (
	Codigo INT NOT NULL IDENTITY(1,1),
	LivroId INT NOT NULL,

	Constraint [PkExemplares] PRIMARY KEY(Codigo),
	CONSTRAINT [FkExemplaresLivrosLivroId]
		FOREIGN KEY (LivroId) REFERENCES Livros(LivroId)
);