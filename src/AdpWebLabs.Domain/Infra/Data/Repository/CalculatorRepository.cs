using AdpWebLabs.Domain.Domain.Entities;
using AdpWebLabs.Domain.Infra.Data.Repository.Base;
using AdpWebLabs.Domain.Infra.Data.Repository.Interfaces;

namespace AdpWebLabs.Domain.Infra.Data.Repository
{
    public class CalculatorRepository : BaseRepository<Calculator>, ICalculatorRepository
    {
        public CalculatorRepository(AdpWebLabsContext context)
            :base(context) { }
    }
}
