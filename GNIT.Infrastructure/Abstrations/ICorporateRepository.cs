using GNIT.Domain.Query;
using GNIT.Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GNIT.Infrastructure.Abstrations
{
    public interface ICorporateRepository
    {
        Task<Corporate> CreateCorporate(Corporate corporate);
        Task<IEnumerable<Corporate>> GetAllCorporates(Query query);
    }
}
