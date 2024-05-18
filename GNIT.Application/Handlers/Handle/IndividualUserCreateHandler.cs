using GNIT.Application.Handlers.Contracts;
using GNIT.Domain.EntityBase;
using GNIT.Domain.User;
using GNIT.Infrastructure.Abstrations;

namespace GNIT.Application.Handlers.Handle
{
    public class IndividualUserCreateHandler(IIndividualUserRepository individualUserRepository) : IHandler<Individual, UserResponse>
    {
        private readonly IIndividualUserRepository _individualUserRepository = individualUserRepository;

        public async Task<UserResponse> Handle(Individual requests)
        {
            var data = await _individualUserRepository.CreateIndividualUser(requests);

            return new UserResponse
            {
                Error = false,
                Message = "Individual User Created Successfully",
                Data = data
            };
        }
    }
}
