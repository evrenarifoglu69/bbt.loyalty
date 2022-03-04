using Bbt.Campaign.Api.Base;
using Bbt.Campaign.Public.Models.Campaign;
using Bbt.Campaign.Services.Services.Campaign;
using Microsoft.AspNetCore.Mvc;

namespace Bbt.Campaign.Api.Controllers
{
    public class CampaignController : BaseController<CampaignController>
    {
        private readonly ICampaignService _campaignService;

        public CampaignController(ICampaignService campaignService)
        {
            _campaignService = campaignService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var adminSektor = await _campaignService.GetCampaignAsync(id);
            return Ok(adminSektor);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CampaignInsertRequest campaign)
        {
            var createResult = await _campaignService.AddAsync(campaign);
            return Ok(createResult);
        }

        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> Update(CampaignUpdateRequest campaign)
        {
            var result = await _campaignService.UpdateAsync(campaign);
            return Ok(result);
        }

        [HttpGet]
        [Route("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _campaignService.DeleteAsync(id);
            return Ok(result);
        }

        [HttpGet]
        [Route("getall")]
        public async Task<IActionResult> GetList()
        {
            var result = await _campaignService.GetListAsync();
            return Ok(result);
        }
        [HttpGet]
        [Route("get-insert-form")]
        public async Task<IActionResult> GetInsertForm()
        {
            var result = await _campaignService.GetInsertFormAsync();
            return Ok(result);
        }
        [HttpGet]
        [Route("get-update-form")]
        public async Task<IActionResult> GetUpdateForm(int id)
        {
            var result = await _campaignService.GetUpdateFormAsync(id);
            return Ok(result);
        }

        [HttpPost]
        [Route("get-by-filter")]
        public async Task<IActionResult> GetByFilter(CampaignListFilterRequest request)
        {
            var result = await _campaignService.GetByFilterAsync(request);
            return Ok(result);
        }
    }
}
