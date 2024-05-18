using GNIT.Application.Handlers.Contracts;
using GNIT.Domain.EntityBase;
using GNIT.Domain.User;
using GNIT.Infrastructure.Abstrations;

namespace GNIT.Application.Handlers.Handle
{
    public class CorporateCreateHandler(ICorporateRepository corporateRepository) : IHandler<Corporate, UserResponse>
    {
        private readonly ICorporateRepository _corporateRepository = corporateRepository;

        public async Task<UserResponse> Handle(Corporate requests)
        {
            var Data = await _corporateRepository.CreateCorporate(requests);
            return new UserResponse
            {
                Error = false,
                Message = "Corporate Created Successfully",
                Data = Data
            };
        }
    }

}
