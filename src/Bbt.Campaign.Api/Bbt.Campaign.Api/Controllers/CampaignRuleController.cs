using Bbt.Campaign.Api.Base;
using Bbt.Campaign.Public.Dtos.CampaignRule;
using Bbt.Campaign.Public.Models.CampaignRule;
using Bbt.Campaign.Services.Services.CampaignRule;
using Microsoft.AspNetCore.Mvc;

namespace Bbt.Campaign.Api.Controllers
{
    public class CampaignRuleController : BaseController<CampaignRuleController>
    {
        private readonly ICampaignRuleService _campaignRuleService;

        public CampaignRuleController(ICampaignRuleService campaignRuleService)
        {
            _campaignRuleService = campaignRuleService;
        }
        /// <summary>
        /// Returns the campaign rule information by Id
        /// </summary>
        /// <param name="id">Campaign Id</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var adminSektor = await _campaignRuleService.GetCampaignRuleAsync(id);
            return Ok(adminSektor);
        }
        /// <summary>
        /// Adds new campaign rule
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("add")]
        [RequestFormLimits(MultipartBodyLengthLimit = int.MaxValue)]
        public async Task<IActionResult> Add([FromForm] AddCampaignRuleRequest campaignRule)
        {
            var createResult = await _campaignRuleService.AddAsync(campaignRule);
            return Ok(createResult);
        }
        /// <summary>
        /// Updates campaign rule by Id
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("update")]
        [RequestFormLimits(MultipartBodyLengthLimit = int.MaxValue)]
        public async Task<IActionResult> Update([FromForm] UpdateCampaignRuleRequest campaignRule)
        {
            var result = await _campaignRuleService.UpdateAsync(campaignRule);
            return Ok(result);
        }
        /// <summary>
        /// Removes the campaign rule by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _campaignRuleService.DeleteAsync(id);
            return Ok(result);
        }
        /// <summary>
        /// Returns the campaign rule list
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("getall")]
        public async Task<IActionResult> GetList()
        {
            var result = await _campaignRuleService.GetListAsync();
            return Ok(result);
        }
        /// <summary>
        /// Returns the form data for insert page
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("get-insert-form")]
        public async Task<IActionResult> GetInsertForm()
        {
            var result = await _campaignRuleService.GetInsertForm();
            return Ok(result);
        }
        /// <summary>
        /// Returns the form data for update page
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("get-update-form")]
        public async Task<IActionResult> GetUpdateForm(int id)
        {
            var result = await _campaignRuleService.GetUpdateForm(id);
            return Ok(result);
        }
    }
}
