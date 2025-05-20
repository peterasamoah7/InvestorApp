using Investors.BL.Interfaces;
using Investors.BL.Models;
using Microsoft.AspNetCore.Mvc;

namespace Investors.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InvestorController(IInvestorService investorService) : ControllerBase
    {
        private readonly IInvestorService investorService = investorService;

        [HttpGet("GetInvestors")]
        public async Task<IActionResult> Get(
            [FromQuery] string name,
            [FromQuery]PagedRequest request)
        {
            var response = await investorService.GetAllInvestorsAsync(name, request);

            return Ok(response);
        }

        [HttpGet("GetSummary")]
        public async Task<IActionResult> GetCommitmentSummary([FromQuery] int id)
        {
            var response = await investorService.GetCommitmentSummariesAsync(id);

            return Ok(response);
        }

        [HttpGet("GetCommitment")]
        public async Task<IActionResult> GetCommitment(
            [FromQuery] int id,
            [FromQuery] string aID,
            [FromQuery] PagedRequest pagedRequest)
        {
            int? assetClassID = !string.Equals(aID, "All", StringComparison.OrdinalIgnoreCase) ? 
                int.Parse(aID) : null;

            var response = await investorService.GetInvestorCommitment(id, assetClassID, pagedRequest);

            return Ok(response);
        }
    }
}
