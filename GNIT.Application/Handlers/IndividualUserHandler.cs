using GNIT.Application.Handlers.Contracts;
using GNIT.Domain.EntityBase;
using GNIT.Domain.Query;
using GNIT.Domain.User;

namespace GNIT.Application.Handlers
{
    public class IndividualUserhandler : IIndividualUserHandler
    {
        private readonly IHandler<Individual, UserResponse> _createhandler;
        private readonly IHandler<Query, IEnumerable<Individual>> _getallhandler;
        public IndividualUserhandler(IHandler<Individual, UserResponse> createhandler, IHandler<Query, IEnumerable<Individual>> getallhandler)
        {
            _createhandler = createhandler;
            _getallhandler = getallhandler;
        }
        public async Task<UserResponse> CreateIndividualUser(Individual individualUser)
        {
            return await _createhandler.Handle(individualUser);
        }

        public async Task<IEnumerable<Individual>> GetAllIndividualUsers(Query query)
        {
            return await _getallhandler.Handle(query);
        }
    }
}
