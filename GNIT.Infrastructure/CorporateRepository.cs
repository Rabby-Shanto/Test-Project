using GNIT.Domain.Query;
using GNIT.Domain.User;
using GNIT.Infrastructure.Abstrations;
using GNIT.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace GNIT.Infrastructure
{
    public class CorporateRepository(ApplicationDbContext db) : ICorporateRepository
    {
        private readonly ApplicationDbContext _db = db;

        public async Task<Corporate> CreateCorporate(Corporate corporate)
        {
            try
            {
                var data = new Corporate
                {
                    CustomerName = corporate.CustomerName,
                    MeetingTime = corporate.MeetingTime,
                    MeetingPlace = corporate.MeetingPlace,
                    Attend = corporate.Attend,
                    MeetingAgenda = corporate.MeetingAgenda,
                    MeetingDiscussion = corporate.MeetingDiscussion,
                    MeetingDecision = corporate.MeetingDecision,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now

                };

                var result = _db.CorporateUsers.AddAsync(data);
                await _db.SaveChangesAsync();
                return result.Result.Entity;

            }
            catch
            {
                throw;
            }
            

        }

        public async Task<IEnumerable<Corporate>> GetAllCorporates(Query query)
        {
            try
            {
                var data = await _db.CorporateUsers
                    .Skip((query.PageNo - 1) * query.PageSize)
                    .Take(query.PageSize)
                    .ToListAsync();
                return data;
            }
            catch
            {
                throw;
            }
        }
    }
}
