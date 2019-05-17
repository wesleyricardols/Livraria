using Livraria.ApplicationCore.Models.Exemplar.Repositories;
using Livraria.ApplicationCore.Models.Exemplar.Services.Interfaces;

namespace Livraria.ApplicationCore.Models.Exemplar.Services
{
    public class ExemplarService : IExemplarService
    {
        private readonly IExemplarRepository _exemplarRepository;

        #region Constructor

        public ExemplarService(IExemplarRepository exemplarRepository)
        {
            _exemplarRepository = exemplarRepository;
        }

        #endregion
    }
}
