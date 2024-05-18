using GNIT.Domain.EntityBase;
using GNIT.Domain.Query;
using GNIT.Domain.User;

namespace GNIT.Application.Handlers.Contracts
{
    public interface ICorporateHandler
    {
        Task<UserResponse> CreateCorporate(Corporate corporate);
        Task<IEnumerable<Corporate>> GetAllCorporates(Query query);
    }
}
