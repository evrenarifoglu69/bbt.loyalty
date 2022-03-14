using Bbt.Campaign.Api.Base;
using Bbt.Campaign.Public.Models.Target.Detail;
using Bbt.Campaign.Services.Services.Target.Detail;
using Microsoft.AspNetCore.Mvc;

namespace Bbt.Campaign.Api.Controllers
{
    public class TargetDetailController : BaseController<TargetDetailController>
    {
        private readonly ITargetDetailService _targetDetailService;

        public TargetDetailController(ITargetDetailService targetDetailService)
        {
            _targetDetailService = targetDetailService;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var adminSektor = await _targetDetailService.GetTargetDetailAsync(id);
            return Ok(adminSektor);
        }

        [HttpPost]
        public async Task<IActionResult> Add(TargetDetailInsertRequest TargetDetail)
        {
            var createResult = await _targetDetailService.AddAsync(TargetDetail);
            return Ok(createResult);
        }

        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> Update(TargetDetailUpdateRequest TargetDetail)
        {
            var result = await _targetDetailService.UpdateAsync(TargetDetail);
            return Ok(result);
        }

        [HttpGet]
        [Route("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _targetDetailService.DeleteAsync(id);
            return Ok(result);
        }

        [HttpPost]
        [Route("get-by-filter")]
        public async Task<IActionResult> GetByFilter(TargetDetailListFilterRequest request)
        {
            var result = await _targetDetailService.GetByFilterAsync(request);
            return Ok(result);
        }
    }
}
