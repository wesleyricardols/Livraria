using Livraria.ApplicationCore.Models.Livros.DTOs.Requests;
using System;
using System.Collections.Generic;

namespace Livraria.ApplicationCore.Entity
{
    public partial class Livros
    {
        public Livros()
        {
            Exemplares = new HashSet<Exemplares>();
        }

        public int LivroId { get; set; }
        public string Titulo { get; set; }
        public string Editora { get; set; }
        public int AnoPublicacao { get; set; }
        public string Autor { get; set; }

        public virtual ICollection<Exemplares> Exemplares { get; set; }

        #region Constructor

        public Livros(LivroRequest request)
        {
            this.Titulo = request.Titulo;
            this.Editora = request.Editora;
            this.AnoPublicacao = request.AnoPublicacao;
            this.Autor = request.Autor;
        }
        #endregion
    }
}
