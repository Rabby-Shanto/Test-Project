using GNIT.Domain.EntityBase;
using GNIT.Domain.Query;
using GNIT.Domain.User;

namespace GNIT.Application.Handlers.Contracts
{
    public interface IIndividualUserHandler
    {
        Task<UserResponse> CreateIndividualUser(Individual individualUser);
        Task<IEnumerable<Individual>> GetAllIndividualUsers(Query query);

    }
}
