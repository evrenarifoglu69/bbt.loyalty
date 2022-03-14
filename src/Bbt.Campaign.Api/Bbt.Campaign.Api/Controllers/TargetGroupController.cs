using Bbt.Campaign.Api.Base;
using Bbt.Campaign.Public.Models.Target.Group;
using Bbt.Campaign.Services.Services.Target;
using Microsoft.AspNetCore.Mvc;

namespace Bbt.Campaign.Api.Controllers
{
    public class TargetGroupController : BaseController<TargetGroupController>
    {
        private readonly ITargetGroupService _targetGroupService;

        public TargetGroupController(ITargetGroupService targetGroupService)
        {
            _targetGroupService = targetGroupService;
        }

        /// <summary>
        /// Returns the target information by Id
        /// </summary>
        /// <param name="id">Campaign Id</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var adminSektor = await _targetGroupService.GetTargetGroupAsync(id);
            return Ok(adminSektor);
        }

        /// <summary>
        /// Returns the target list
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("getall")]
        public async Task<IActionResult> GetList()
        {
            var result = await _targetGroupService.GetListAsync();
            return Ok(result);
        }

        ///////////////
        ///
        /// <summary>
        /// Adds new target group
        /// </summary>
        /// <param name="targetGroup"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(TargetGroupInsertRequest targetGroup)
        {
            var createResult = await _targetGroupService.AddAsync(targetGroup);
            return Ok(createResult);
        }
        /// <summary>
        /// Updates target by Id
        /// </summary>
        /// <param name="targetGroup"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> Update(TargetGroupUpdateRequest targetGroup)
        {
            var result = await _targetGroupService.UpdateAsync(targetGroup);
            return Ok(result);
        }

        /// <summary>
        /// Removes the target by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _targetGroupService.DeleteAsync(id);
            return Ok(result);
        }

        /// <summary>
        /// Removes line from the target group by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("delete-line")]
        public async Task<IActionResult> DeleteLine(int id)
        {
            var result = await _targetGroupService.DeleteLineAsync(id);
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
            var result = await _targetGroupService.GetInsertForm();
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
            var result = await _targetGroupService.GetUpdateForm(id);
            return Ok(result);
        }
    }
}
