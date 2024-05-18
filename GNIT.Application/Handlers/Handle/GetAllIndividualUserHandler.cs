using GNIT.Application.Handlers.Contracts;
using GNIT.Domain.Query;
using GNIT.Domain.User;
using GNIT.Infrastructure.Abstrations;

namespace GNIT.Application.Handlers.Handle
{
    public class GetAllIndividualUserHandler(IIndividualUserRepository individualUserRepository) : IHandler<Query, IEnumerable<Individual>>
    {
        private readonly IIndividualUserRepository _individualUserRepository = individualUserRepository;

        public async Task<IEnumerable<Individual>> Handle(Query requests)
        {
            try
            {
                var data = await _individualUserRepository.GetAllIndividualUsers(requests);
                return data;

            }
            catch
            {
                throw;
            }
        }
    }
}
