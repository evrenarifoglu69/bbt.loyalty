using Bbt.Campaign.Api.Base;
using Bbt.Campaign.Public.Dtos.CampaignTarget;
using Bbt.Campaign.Services.Services.CampaignTarget;
using Microsoft.AspNetCore.Mvc;

namespace Bbt.Campaign.Api.Controllers
{
    public class CampaignTargetController : BaseController<CampaignTargetController>
    {
        private readonly ICampaignTargetService _campaignTargetService;

        public CampaignTargetController(ICampaignTargetService campaignTargetService)
        {
            _campaignTargetService = campaignTargetService;
        }
        /// <summary>
        /// Returns the campaign target information by Id
        /// </summary>
        /// <param name="id">Campaign target Id</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var adminSektor = await _campaignTargetService.GetCampaignTargetAsync(id);
            return Ok(adminSektor);
        }
        /// <summary>
        /// Adds new campaign target
        /// </summary>
        /// <param name="campaign"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add(CampaignTargetDto campaignTarget)
        {
            var createResult = await _campaignTargetService.AddAsync(campaignTarget);
            return Ok(createResult);
        }
        /// <summary>
        /// Updates campaign target by Id
        /// </summary>
        /// <param name="campaign"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> Update(CampaignTargetDto campaignTarget)
        {
            var result = await _campaignTargetService.UpdateAsync(campaignTarget);
            return Ok(result);
        }
        /// <summary>
        /// Removes the campaign target by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _campaignTargetService.DeleteAsync(id);
            return Ok(result);
        }
        /// <summary>
        /// Returns the campaign target list
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("getall")]
        public async Task<IActionResult> GetList()
        {
            var result = await _campaignTargetService.GetListAsync();
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
            var result = await _campaignTargetService.GetInsertForm();
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
            var result = await _campaignTargetService.GetUpdateForm(id);
            return Ok(result);
        }
    }
}
