using Livraria.ApplicationCore.Interfaces;
using Livraria.ApplicationCore.Models.Livros.DTOs.Responses;
using System.Collections.Generic;

namespace Livraria.ApplicationCore.Models.Livros.Repositories
{
    public interface ILivroRepository : IRepository<Entity.Livros>
    {
        Entity.Livros GetLivroByTitle(string title);
        IEnumerable<LivroResponse> GetAllWithExemplares();
    }
}
