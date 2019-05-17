using Livraria.ApplicationCore.Entity;
using Livraria.ApplicationCore.Models.Exemplar.Repositories;
using Livraria.Infrastructure.Repository.Base;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Livraria.Infrastructure.Repository
{
    public class ExemplarRepository : Repository<Exemplares>, IExemplarRepository
    {
        private readonly LivrariaContext _context;

        #region Constructor

        public ExemplarRepository(LivrariaContext context) : base(context)
        {
            _context = context;
        }

        #endregion

        public IEnumerable<Exemplares> GetExemplarByBookId(int bookId)
        {
            return _context.Exemplares.Where(__exemplar => __exemplar.LivroId == bookId);
        }
    }
}
