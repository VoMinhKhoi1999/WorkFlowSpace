using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorkFlowSpace.API.Sys;
using WorkFlowSpace.Core.Entities;
using WorkFlowSpace.Core.Interface;
using WorkFlowSpace.infrastructure.Data.DTO;

namespace WorkFlowSpace.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        #region connect interface
        private readonly IUnitOfWork _uow;

        public TasksController(IUnitOfWork uow)
        {
            this._uow = uow;
        }
        #endregion

        #region get
        [HttpPost("get-all-tasks")]
        public async Task<ActionResult> Get()
        {
            try
            {
                var result = await _uow.TasksRepository.GetAllAsync();

                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(SYS_Extensions.MessNotFound(ex));
            }
        }

        [HttpPost("get-by-id-tasks/{id}")]
        public async Task<ActionResult> Get(int id)
        {
            try
            {
                var result = await _uow.TasksRepository.GetAsync(id);

                if(result != null)
                {
                    return Ok(result);
                }

                return BadRequest(SYS_Extensions.MessNotFound(id.ToString()));
            }
            catch (Exception ex)
            {
                return BadRequest(SYS_Extensions.MessNotFound(ex));
            }
        }
        #endregion

        #region change data
        [HttpPut("add-tasks")]
        public async Task<ActionResult> Add(TasksDTO task)
        {
            try
            {
                var checkTab = await _uow.TabsRepository.GetAsync(task.TabId);

                if (checkTab != null)
                {
                    Tasks result = new Tasks();
                    result.Title = task.Title;
                    result.Description = task.Description;
                    result.BeginDate = task.BeginDate;
                    result.EndDate = task.EndDate;
                    result.Status = task.Status;
                    result.CreateBy = task.CreateBy;
                    result.TabId = task.TabId;
                    return Ok(result);
                }

                return BadRequest(SYS_Extensions.MessNotFound("tab " + task.TabId.ToString()));
            }
            catch (Exception ex)
            {
                return BadRequest(SYS_Extensions.MessNotFound(ex));
            }
        }
        #endregion
    }
}
