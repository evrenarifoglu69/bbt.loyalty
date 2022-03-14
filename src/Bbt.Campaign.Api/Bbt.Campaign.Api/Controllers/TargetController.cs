using Bbt.Campaign.Api.Base;
using Bbt.Campaign.Public.Models.Target;
using Bbt.Target.Services.Services.Target;
using Microsoft.AspNetCore.Mvc;

namespace Bbt.Target.Api.Controllers
{
    public class TargetController : BaseController<TargetController>
    {
        private readonly ITargetService _targetService;

        public TargetController(ITargetService targetService)
        {
            _targetService = targetService;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var adminSektor = await _targetService.GetTargetAsync(id);
            return Ok(adminSektor);
        }

        [HttpPost]
        public async Task<IActionResult> Add(TargetInsertRequest Target)
        {
            var createResult = await _targetService.AddAsync(Target);
            return Ok(createResult);
        }

        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> Update(TargetUpdateRequest Target)
        {
            var result = await _targetService.UpdateAsync(Target);
            return Ok(result);
        }

        [HttpGet]
        [Route("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _targetService.DeleteAsync(id);
            return Ok(result);
        }

        [HttpPost]
        [Route("get-by-filter")]
        public async Task<IActionResult> GetByFilter(TargetListFilterRequest request)
        {
            var result = await _targetService.GetByFilterAsync(request);
            return Ok(result);
        }
    }
}
