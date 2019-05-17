using Livraria.ApplicationCore.Entity;
using Livraria.ApplicationCore.Models.Exemplar.Repositories;
using Livraria.ApplicationCore.Models.Exemplar.Services.Interfaces;
using Livraria.ApplicationCore.Models.Livros.DTOs.Requests;
using Livraria.ApplicationCore.Models.Livros.DTOs.Responses;
using Livraria.ApplicationCore.Models.Livros.Exception;
using Livraria.ApplicationCore.Models.Livros.Repositories;
using Livraria.ApplicationCore.Models.Livros.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Livraria.ApplicationCore.Models.Livros.Services
{
    public class LivroService : ILivroService
    {
        private readonly ILivroRepository _livroRepository;
        private readonly IExemplarRepository _exemplarRepository;

        #region Constructor

        public LivroService(ILivroRepository livroRepository, IExemplarRepository exemplarRepository)
        {
            _livroRepository = livroRepository;
            _exemplarRepository = exemplarRepository;
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Retorna todos os livros cadastrados ordenados ascendentemente pelo título
        /// </summary>
        /// <returns></returns>
        public IEnumerable<LivroResponse> GetAllWithExemplares()
        {
            return _livroRepository.GetAllWithExemplares()
                .OrderBy(__livro => __livro.Titulo);
        }

        /// <summary>
        /// Adiciona um novo Livro
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public LivroResponse Add(LivroRequest request)
        {
            List<Exemplares> exemplares = new List<Exemplares>();

            if (TitleAlreadyExists(request.Titulo))
                throw new LivroException("Não é possível cadastrar o livro desejado pois já existe um com o mesmo Título");

            Entity.Livros dbLivro = new Entity.Livros(request);
            _livroRepository.Add(dbLivro);

            // cadastra exemplares
            for (int i = 0; i < request.QtdeExemplares; i++)
            {
                Exemplares dbExemplares = new Exemplares()
                {
                    Livro = dbLivro
                };

                exemplares.Add(dbExemplares);
            }
            _exemplarRepository.AddRange(exemplares);

            _livroRepository.SaveChanges();
            _exemplarRepository.SaveChanges();

            return new LivroResponse(dbLivro, exemplares);
        }

        /// <summary>
        /// Altera um livro já existente
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public LivroResponse Update(LivroRequest request)
        {
            Entity.Livros dbLivros = _livroRepository.GetById(request.Id);

            if (dbLivros == null)
                throw new LivroException("O Livro informado para edição não existe");

            if (request.Titulo != request.CurrentTitle)
            {
                if (TitleAlreadyExists(request.Titulo))
                    throw new LivroException("Não é possível alterar o livro desejado pois já existe um com o mesmo Título");
            }

            dbLivros.Titulo = request.Titulo;
            dbLivros.Editora = request.Editora;
            dbLivros.AnoPublicacao = request.AnoPublicacao;
            dbLivros.Autor = request.Autor;

            int currentQtyExemplares = _exemplarRepository.GetExemplarByBookId(request.Id).Count();

            int countDifference = 0;

            if (currentQtyExemplares < request.QtdeExemplares)
            {
                List<Exemplares> exemplares = new List<Exemplares>();
                countDifference = (request.QtdeExemplares - currentQtyExemplares);

                for (int i = 0; i < countDifference; i++)
                {
                    Exemplares dbExemplar = new Exemplares()
                    {
                        LivroId = request.Id
                    };
                    exemplares.Add(dbExemplar);
                }
                _exemplarRepository.AddRange(exemplares);
            }
            else
            {
                countDifference = (currentQtyExemplares - request.QtdeExemplares);

                List<Exemplares> exemplares = _exemplarRepository.GetExemplarByBookId(request.Id)
                    .OrderByDescending(__exemplar => __exemplar.Codigo)
                    .Take(countDifference)
                    .ToList();
                _exemplarRepository.RemoveRange(exemplares);
            }

            _livroRepository.Update(dbLivros);
            _livroRepository.SaveChanges();
            _exemplarRepository.SaveChanges();

            return new LivroResponse(dbLivros);
        }

        /// <summary>
        /// Exclui um livro
        /// </summary>
        /// <param name="request"></param>
        public void Delete(LivroRequest request)
        {
            _exemplarRepository.RemoveRange(_exemplarRepository.GetExemplarByBookId(request.Id));
            _livroRepository.Remove(request.Id);

            _exemplarRepository.SaveChanges();
            _livroRepository.SaveChanges();
        }

        #endregion

        #region Private methods

        private bool TitleAlreadyExists(string title)
        {
            Entity.Livros dbLivro = _livroRepository.GetLivroByTitle(title);

            return (dbLivro != null);
        }
        
        #endregion
    }
}
