using Bbt.Campaign.Api.Base;
using Bbt.Campaign.Services.Services.Parameter;
using Microsoft.AspNetCore.Mvc;
namespace Bbt.Campaign.Api.Controllers
{
    public class ParameterController : BaseController<ParameterController>
    {
        private readonly IParameterService _parameterService;

        public ParameterController(IParameterService parameterService)
        {
            _parameterService = parameterService;
        }

        [HttpGet]
        [Route("get-action-options")]
        public async Task<IActionResult> GetActionOptionList()
        {
            var result = await _parameterService.GetActionOptionListAsync();
            return Ok(result);
        }
        [HttpGet]
        [Route("get-branchs")]
        public async Task<IActionResult> GetBranchList()
        {
            var result = await _parameterService.GetBranchListAsync();
            return Ok(result);
        }
        [HttpGet]
        [Route("get-business-lines")]
        public async Task<IActionResult> GetBusinessLineList()
        {
            var result = await _parameterService.GetBusinessLineListAsync();
            return Ok(result);
        }
        [HttpGet]
        [Route("get-campaign-startterms")]
        public async Task<IActionResult> GetCampaignStartTermList()
        {
            var result = await _parameterService.GetCampaignStartTermListAsync();
            return Ok(result);
        }
        [HttpGet]
        [Route("get-customer-types")]
        public async Task<IActionResult> GetCustomerTypeList()
        {
            var result = await _parameterService.GetCustomerTypeListAsync();
            return Ok(result);
        }
        [HttpGet]
        [Route("get-join-types")]
        public async Task<IActionResult> GetJoinTypeList()
        {
            var result = await _parameterService.GetJoinTypeListAsync();
            return Ok(result);
        }
        [HttpGet]
        [Route("get-languages")]
        public async Task<IActionResult> GetLanguageList()
        {
            var result = await _parameterService.GetLanguageListAsync();
            return Ok(result);
        }
        [HttpGet]
        [Route("get-sectors")]
        public async Task<IActionResult> GetSectorList()
        {
            var result = await _parameterService.GetSectorListAsync();
            return Ok(result);
        }
        [HttpGet]
        [Route("get-view-options")]
        public async Task<IActionResult> GetViewOptionList()
        {
            var result = await _parameterService.GetViewOptionListAsync();
            return Ok(result);
        }
        [HttpGet]
        [Route("get-program-types")]
        public async Task<IActionResult> GetProgramTypeList()
        {
            var result = await _parameterService.GetProgramTypeListAsync();
            return Ok(result);
        }
        [HttpGet]
        [Route("get-trigger-times")]
        public async Task<IActionResult> GetTriggerTimeList()
        {
            var result = await _parameterService.GetTriggerTimeListAsync();
            return Ok(result);
        }
        [HttpGet]
        [Route("get-verification-times")]
        public async Task<IActionResult> GetVerificationTimeList()
        {
            var result = await _parameterService.GetVerificationTimeListAsync();
            return Ok(result);
        }
        [HttpGet]
        [Route("get-target-sources")]
        public async Task<IActionResult> GetTargetSourceList()
        {
            var result = await _parameterService.GetTargetSourceListAsync();
            return Ok(result);
        }
        [HttpGet]
        [Route("get-target-views")]
        public async Task<IActionResult> GetTargetViewTypeList()
        {
            var result = await _parameterService.GetTargetViewTypeListAsync();
            return Ok(result);
        }

    }
}
