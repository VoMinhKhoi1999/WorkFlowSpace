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
    public class TabsController : ControllerBase
    {
        #region connect interface
        private readonly IUnitOfWork _uow;

        public TabsController(IUnitOfWork uow)
        {
            this._uow = uow;
        }
        #endregion

        #region get data
        [HttpGet("get-all-tabs")]
        public async Task<ActionResult> Get()
        {
            try
            {
                var result = await _uow.TabsRepository.GetAllAsync();

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

        [HttpGet("get-by-id-tabs/{id}")]
        public async Task<ActionResult> Get(int id)
        {
            try
            {
                var result = await _uow.TabsRepository.GetAsync(id);

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
        [HttpPost("add-tabs")]
        public async Task<ActionResult> Add(TabsDTO tab)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var checkGroup = await _uow.GroupsRepository.GetAsync(tab.GroupId);

                    if (checkGroup != null)
                    {
                        Tabs result = new Tabs();

                        result.Name = tab.Name;
                        result.CreateBy = tab.CreateBy;
                        result.CreateAt = DateTime.Now;

                        result.ModifiDate = DateTime.Now;
                        result.GroupId = tab.GroupId;

                        await _uow.TabsRepository.AddAsync(result);

                        return Ok(SYS_Extensions.MessSuccess(result.Name, "Add"));
                    }

                    return BadRequest(SYS_Extensions.MessNotFound("group " + tab.GroupId.ToString()));
                }

                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(SYS_Extensions.MessNotFound(ex));
            }
        }

        [HttpPut("update-tabs/{id}")]
        public async Task<ActionResult> Update(int id, TabsDTO tab)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _uow.TabsRepository.GetAsync(id);

                    if (result != null)
                    {
                        if (result.GroupId != tab.GroupId)
                        {
                            var checkGroup = await _uow.GroupsRepository.GetAsync(tab.GroupId);

                            if (checkGroup == null)
                            {
                                return BadRequest(SYS_Extensions.MessNotFound("group " + tab.GroupId.ToString()));
                            }
                        }

                        result.Name = tab.Name;
                        result.ModifiDate = DateTime.Now;
                        result.GroupId = tab.GroupId;

                        await _uow.TabsRepository.UpdateAsync(id, result);

                        return Ok(SYS_Extensions.MessSuccess(result.Name, "Upd"));
                    }

                    return BadRequest(SYS_Extensions.MessNotFound("tab " + id.ToString()));
                }

                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(SYS_Extensions.MessNotFound(ex));
            }
        }

        [HttpDelete("delete-tabs/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _uow.TabsRepository.GetAsync(id);

                    if (result != null)
                    {
                        await _uow.TabsRepository.DeleteAsync(result.Id);

                        return Ok(SYS_Extensions.MessSuccess(result.Name, "Del"));
                    }

                    return BadRequest(SYS_Extensions.MessNotFound("tab " + id.ToString()));
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
