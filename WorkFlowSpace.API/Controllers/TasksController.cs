using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
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

        #region get data
        [HttpGet("get-all-tasks")]
        public async Task<ActionResult> Get()
        {
            try
            {
                var result = await _uow.TasksRepository.GetAllAsync();

                if (result != null)
                {
                    return Ok(result);
                }

                return BadRequest(SYS_Extensions.MessNotFound());
            }
            catch (Exception ex)
            {
                return BadRequest(SYS_Extensions.MessNotFound(ex));
            }
        }

        [HttpGet("get-by-id-tasks/{id}")]
        public async Task<ActionResult> Get(int id)
        {
            try
            {
                var result = await _uow.TasksRepository.GetAsync(id);

                if (result != null)
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
        [HttpPost("add-tasks")]
        public async Task<ActionResult> Add(TasksDTO task)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var checkTab = await _uow.TabsRepository.GetAsync(task.TabId);

                    if (checkTab != null)
                    {
                        Tasks result = new Tasks();

                        result.Title = task.Title;
                        result.Description = task.Description;
                        result.AssignedTo = task.AssignedTo;

                        result.BeginDate = task.BeginDate;
                        result.EndDate = task.EndDate;
                        result.Status = task.Status;

                        result.CreateBy = task.CreateBy;
                        result.CreateAt = DateTime.Now;
                        result.ModifiDate = DateTime.Now;

                        result.TabId = task.TabId;

                        await _uow.TasksRepository.AddAsync(result);

                        return Ok(SYS_Extensions.MessSuccess(result.Title, "Add"));
                    }

                    return BadRequest(SYS_Extensions.MessNotFound("tab " + task.TabId.ToString()));
                }

                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(SYS_Extensions.MessNotFound(ex));
            }
        }

        [HttpPut("update-tasks/{id}")]
        public async Task<ActionResult> Update(int id, TasksDTO task)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _uow.TasksRepository.GetAsync(id);

                    if (result != null)
                    {
                        if (result.TabId != task.TabId)
                        {
                            var checkTab = await _uow.TabsRepository.GetAsync(task.TabId);

                            if (checkTab == null)
                            {
                                return BadRequest(SYS_Extensions.MessNotFound("tab " + task.TabId.ToString()));
                            }
                        }

                        result.Title = task.Title;
                        result.Description = task.Description;
                        result.AssignedTo = task.AssignedTo;

                        result.BeginDate = task.BeginDate;
                        result.EndDate = task.EndDate;
                        result.Status = task.Status;

                        result.ModifiDate = DateTime.Now;
                        result.TabId = task.TabId;

                        await _uow.TasksRepository.UpdateAsync(id, result);

                        return Ok(SYS_Extensions.MessSuccess(result.Title, "Upd"));
                    }

                    return BadRequest(SYS_Extensions.MessNotFound("task " + id.ToString()));
                }

                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(SYS_Extensions.MessNotFound(ex));
            }
        }

        [HttpDelete("delete-tasks/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _uow.TasksRepository.GetAsync(id);

                    if (result != null)
                    {
                        await _uow.TasksRepository.DeleteAsync(id);

                        return Ok(SYS_Extensions.MessSuccess(result.Title, "Del"));
                    }

                    return BadRequest(SYS_Extensions.MessNotFound("task " + id.ToString()));
                }

                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(SYS_Extensions.MessNotFound(ex));
            }
        }
        #endregion
    }
}
