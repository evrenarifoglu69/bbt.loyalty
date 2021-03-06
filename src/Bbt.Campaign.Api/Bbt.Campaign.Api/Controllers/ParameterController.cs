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
        /// <summary>
        /// Returns Action Option list.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("get-action-options")]
        public async Task<IActionResult> GetActionOptionList()
        {
            var result = await _parameterService.GetActionOptionListAsync();
            return Ok(result);
        }
        /// <summary>
        /// Returns Branch list.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("get-branchs")]
        public async Task<IActionResult> GetBranchList()
        {
            var result = await _parameterService.GetBranchListAsync();
            return Ok(result);
        }
        /// <summary>
        /// Returns Business Line list.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("get-business-lines")]
        public async Task<IActionResult> GetBusinessLineList()
        {
            var result = await _parameterService.GetBusinessLineListAsync();
            return Ok(result);
        }
        /// <summary>
        /// Returns Campaign Start Term list.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("get-campaign-startterms")]
        public async Task<IActionResult> GetCampaignStartTermList()
        {
            var result = await _parameterService.GetCampaignStartTermListAsync();
            return Ok(result);
        }
        /// <summary>
        /// Returns Customer Type list.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("get-customer-types")]
        public async Task<IActionResult> GetCustomerTypeList()
        {
            var result = await _parameterService.GetCustomerTypeListAsync();
            return Ok(result);
        }
        /// <summary>
        /// Returns Join Type list.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("get-join-types")]
        public async Task<IActionResult> GetJoinTypeList()
        {
            var result = await _parameterService.GetJoinTypeListAsync();
            return Ok(result);
        }
        /// <summary>
        /// Returns Language list.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("get-languages")]
        public async Task<IActionResult> GetLanguageList()
        {
            var result = await _parameterService.GetLanguageListAsync();
            return Ok(result);
        }
        /// <summary>
        /// Returns Sector list.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("get-sectors")]
        public async Task<IActionResult> GetSectorList()
        {
            var result = await _parameterService.GetSectorListAsync();
            return Ok(result);
        }
        /// <summary>
        /// Returns View Option list.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("get-view-options")]
        public async Task<IActionResult> GetViewOptionList()
        {
            var result = await _parameterService.GetViewOptionListAsync();
            return Ok(result);
        }
        /// <summary>
        /// Returns Program Type list.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("get-program-types")]
        public async Task<IActionResult> GetProgramTypeList()
        {
            var result = await _parameterService.GetProgramTypeListAsync();
            return Ok(result);
        }
        /// <summary>
        /// Returns Trigger Type list.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("get-trigger-times")]
        public async Task<IActionResult> GetTriggerTimeList()
        {
            var result = await _parameterService.GetTriggerTimeListAsync();
            return Ok(result);
        }
        /// <summary>
        /// Returns Verification Time list.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("get-verification-times")]
        public async Task<IActionResult> GetVerificationTimeList()
        {
            var result = await _parameterService.GetVerificationTimeListAsync();
            return Ok(result);
        }
        /// <summary>
        /// Returns Target Source list.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("get-target-sources")]
        public async Task<IActionResult> GetTargetSourceList()
        {
            var result = await _parameterService.GetTargetSourceListAsync();
            return Ok(result);
        }
        /// <summary>
        /// Returns Target View list.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("get-target-views")]
        public async Task<IActionResult> GetTargetViewTypeList()
        {
            var result = await _parameterService.GetTargetViewTypeListAsync();
            return Ok(result);
        }

    }
}
