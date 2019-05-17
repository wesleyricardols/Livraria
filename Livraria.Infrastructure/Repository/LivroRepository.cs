using Livraria.ApplicationCore.Entity;
using Livraria.ApplicationCore.Models.Livros.DTOs.Responses;
using Livraria.ApplicationCore.Models.Livros.Repositories;
using Livraria.Infrastructure.Repository.Base;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Livraria.Infrastructure.Repository
{
    public class LivroRepository : Repository<Livros>, ILivroRepository
    {
        private readonly LivrariaContext _context;

        #region Constructor

        public LivroRepository(LivrariaContext context) : base(context)
        {
            _context = context;
        }

        #endregion

        public Livros GetLivroByTitle(string title)
        {
            return _context.Livros.FirstOrDefault(__livro => __livro.Titulo.Equals(title));
        }

        public IEnumerable<LivroResponse> GetAllWithExemplares()
        {
            return _context.Livros
                .Include(__livro => __livro.Exemplares)
                .Select(__livro => new LivroResponse(__livro));
        }
    }
}
