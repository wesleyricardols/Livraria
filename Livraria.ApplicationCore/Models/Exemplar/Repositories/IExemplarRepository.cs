using Livraria.ApplicationCore.Entity;
using Livraria.ApplicationCore.Interfaces;
using System.Collections.Generic;

namespace Livraria.ApplicationCore.Models.Exemplar.Repositories
{
    public interface IExemplarRepository : IRepository<Entity.Exemplares>
    {
        IEnumerable<Exemplares> GetExemplarByBookId(int bookId);
    }
}
