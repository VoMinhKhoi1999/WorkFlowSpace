using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using WorkFlowSpace.Core.Entities;
using WorkFlowSpace.Core.Interface;
using WorkFlowSpace.infrastructure.Data.DTO;
using WorkFlowSpace.API.Sys;

namespace WorkFlowSpace.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        #region connect interface
        private readonly IUnitOfWork _uow;

        public GroupsController(IUnitOfWork uow)
        {
            this._uow = uow;
        }
        #endregion

        #region get data
        [HttpGet("get-all-groups")]
        public async Task<ActionResult> Get()
        {
            try
            {
                var result = await _uow.GroupsRepository.GetAllAsync();

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

        [HttpGet("get-by-id-groups/{id}")]
        public async Task<ActionResult> Get(int id)
        {
            try
            {
                var result = await _uow.GroupsRepository.GetAsync(id);

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
        [HttpPost("add-groups")]
        public async Task<ActionResult> Add(GroupsDTO groups)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Groups result = new Groups();

                    result.Name = groups.Name;
                    result.CreateBy = groups.CreateBy;
                    result.CreateAt = DateTime.Now;

                    result.ModifiDate = DateTime.Now;

                    await _uow.GroupsRepository.AddAsync(result);

                    return Ok(SYS_Extensions.MessSuccess(result.Name, "Add"));
                }

                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(SYS_Extensions.MessNotFound(ex));
            }
        }

        [HttpPut("update-groups/{id}")]
        public async Task<ActionResult> Update(int id, GroupsDTO groups)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _uow.GroupsRepository.GetAsync(id);

                    if(result != null)
                    {
                        result.Name = groups.Name;
                        result.ModifiDate = DateTime.Now;

                        await _uow.GroupsRepository.UpdateAsync(id, result);

                        return Ok(SYS_Extensions.MessSuccess(result.Name, "Upd"));
                    }

                    return Ok(SYS_Extensions.MessNotFound("group " + id.ToString()));
                }

                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(SYS_Extensions.MessNotFound(ex));
            }
        }

        [HttpDelete("delete-groups/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _uow.GroupsRepository.GetAsync(id);

                    if (result != null)
                    {
                        await _uow.GroupsRepository.DeleteAsync(id);

                        return Ok(SYS_Extensions.MessSuccess(result.Name, "Del"));
                    }

                    return BadRequest(SYS_Extensions.MessNotFound("group " + id.ToString()));
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
