using GNIT.Application.Handlers.Contracts;
using GNIT.Domain.Query;
using GNIT.Domain.User;
using GNIT.Presentation.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace GNIT.Presentation.Controllers
{
    public class CorporateApiController(ICorporateHandler corporateHandler) : BaseApiController
    {
        private readonly ICorporateHandler _corporateHandler = corporateHandler;

        [HttpPost]
        public async Task<IActionResult> CreateCorporate([FromBody] Corporate corporate)
        {
            var result = await _corporateHandler.CreateCorporate(corporate);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCorporates([FromQuery] Query query)
        {
            var result = await _corporateHandler.GetAllCorporates(query);
            return Ok(result);
        }
    }
}
