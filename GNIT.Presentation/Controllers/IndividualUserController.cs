using GNIT.Application.Handlers.Contracts;
using GNIT.Domain.Query;
using GNIT.Domain.User;
using GNIT.Presentation.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace GNIT.Presentation.Controllers
{
    public class IndividualUserController(IIndividualUserHandler individualUserHandler) : BaseApiController
    {
        private readonly IIndividualUserHandler _individualUserHandler = individualUserHandler;

        [HttpPost]
        public async Task<IActionResult> CreateIndividualUser(Individual individual)
        {
            var result = await _individualUserHandler.CreateIndividualUser(individual);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetIndividualUser([FromQuery] Query query)
        {
            var result = await _individualUserHandler.GetAllIndividualUsers(query);
            return Ok(result);
        }
    }
}
