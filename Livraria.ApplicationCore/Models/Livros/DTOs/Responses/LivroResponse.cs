using System.Collections.Generic;
using System.Linq;

namespace Livraria.ApplicationCore.Models.Livros.DTOs.Responses
{
    public class LivroResponse
    {
        public int Id { get; private set; }
        public string Titulo { get; private set; }
        public string Editora { get; private set; }
        public int AnoPublicacao { get; private set; }
        public string Autor { get; private set; }
        public string[] Exemplares { get; set; }

        #region Constructor

        public LivroResponse(Entity.Livros dbLivro)
        {
            this.Id = dbLivro.LivroId;
            this.Titulo = dbLivro.Titulo;
            this.Editora = dbLivro.Editora;
            this.AnoPublicacao = dbLivro.AnoPublicacao;
            this.Autor = dbLivro.Autor;
            this.Exemplares = dbLivro.Exemplares
                .Select(__exemplar => __exemplar.Codigo.ToString("0000"))
                .ToArray();
        }
        public LivroResponse(Entity.Livros dbLivro, List<Entity.Exemplares> exemplares)
        {
            this.Id = dbLivro.LivroId;
            this.Titulo = dbLivro.Titulo;
            this.Editora = dbLivro.Editora;
            this.AnoPublicacao = dbLivro.AnoPublicacao;
            this.Autor = dbLivro.Autor;
            this.Exemplares = exemplares
                .Select(__exemplar => __exemplar.Codigo.ToString("0000"))
                .ToArray();
        }

        #endregion
    }
}
