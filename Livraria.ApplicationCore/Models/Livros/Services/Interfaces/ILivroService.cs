using Livraria.ApplicationCore.Models.Exemplar.Services.Interfaces;
using Livraria.ApplicationCore.Models.Livros.DTOs.Requests;
using Livraria.ApplicationCore.Models.Livros.DTOs.Responses;
using System.Collections.Generic;

namespace Livraria.ApplicationCore.Models.Livros.Services.Interfaces
{
    public interface ILivroService
    {
        IEnumerable<LivroResponse> GetAllWithExemplares();
        LivroResponse Add(LivroRequest request);
        LivroResponse Update(LivroRequest request);
        void Delete(LivroRequest request);
    }
}
