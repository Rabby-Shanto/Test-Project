using GNIT.Application.Handlers.Contracts;
using GNIT.Domain.Query;
using GNIT.Domain.User;
using GNIT.Infrastructure.Abstrations;

namespace GNIT.Application.Handlers.Handle
{
    public class GetAllCorporateHandler(ICorporateRepository corporateRepository) : IHandler<Query, IEnumerable<Corporate>>
    {
        private readonly ICorporateRepository _corporateRepository = corporateRepository;

        public async Task<IEnumerable<Corporate>> Handle(Query requests)
        {
            var data = await _corporateRepository.GetAllCorporates(requests);
            return data;

        }
    }
}
