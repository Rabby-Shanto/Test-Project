using GNIT.Domain.Query;
using GNIT.Domain.User;
using GNIT.Infrastructure.Abstrations;
using GNIT.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GNIT.Infrastructure
{
    public class IndividualRepository(ApplicationDbContext db) : IIndividualUserRepository
    {
        private readonly ApplicationDbContext _db = db;

        public async Task<Individual> CreateIndividualUser(Individual individualUser)
        {
            try
            {
                var data = new Individual
                {
                    CustomerName = individualUser.CustomerName,
                    MeetingTime = individualUser.MeetingTime,
                    MeetingPlace = individualUser.MeetingPlace,
                    Attend = individualUser.Attend,
                    MeetingAgenda = individualUser.MeetingAgenda,
                    MeetingDiscussion = individualUser.MeetingDiscussion,
                    MeetingDecision = individualUser.MeetingDecision,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now

                };
                var result = await _db.IndividualUsers.AddAsync(data);
                await _db.SaveChangesAsync();
                return result.Entity;

            }
            catch
            {
                throw;
            }

        }

        public async Task<IEnumerable<Individual>> GetAllIndividualUsers( Query query)
        {
            try
            {
                var data = await  _db.IndividualUsers
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
