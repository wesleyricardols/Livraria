using System;
using System.Collections.Generic;

namespace Livraria.ApplicationCore.Entity
{
    public partial class Exemplares
    {
        public int Codigo { get; set; }
        public int LivroId { get; set; }

        public virtual Livros Livro { get; set; }
    }
}
