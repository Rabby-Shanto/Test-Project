using GNIT.Application.Handlers.Contracts;
using GNIT.Domain.EntityBase;
using GNIT.Domain.Query;
using GNIT.Domain.User;

namespace GNIT.Application.Handlers
{


    public class CorporateHandler : ICorporateHandler
    {
        private readonly IHandler<Corporate, UserResponse> _corporatecreate;
        private readonly IHandler<Query, IEnumerable<Corporate>> _corporateread;
        public CorporateHandler(IHandler<Corporate, UserResponse> corporatecreate, IHandler<Query, IEnumerable<Corporate>> corporateread)
        {
            _corporatecreate = corporatecreate;
            _corporateread = corporateread;
        }
        public Task<UserResponse> CreateCorporate(Corporate corporate)
        {
            return _corporatecreate.Handle(corporate);
        }

        public Task<IEnumerable<Corporate>> GetAllCorporates( Query query)
        {
            return _corporateread.Handle(query);
        }
    }
}
