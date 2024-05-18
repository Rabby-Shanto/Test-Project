using GNIT.Domain.Query;
using GNIT.Domain.User;

namespace GNIT.Infrastructure.Abstrations
{
    public interface IIndividualUserRepository
    {
        Task<Individual> CreateIndividualUser(Individual individualUser);
        Task<IEnumerable<Individual>> GetAllIndividualUsers(Query query);
    }
}
