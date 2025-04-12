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

        #region get
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

                    if(checkGroup != null)
                    {
                        var result = new Tabs();
                        result.Name = tab.Name;
                        result.GroupId = tab.GroupId;
                        result.CreateBy = tab.CreateBy;

                        await _uow.TabsRepository.AddAsync(result);

                        return Ok(SYS_Extensions.MessSuccess(result.Name, "Add"));
                    }

                    return BadRequest(SYS_Extensions.MessNotFound("group " + tab.GroupId));
                }

                return BadRequest(SYS_Extensions.MessNotFound());
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
                    var checkTab = await _uow.TabsRepository.GetAsync(id);

                    if (checkTab != null)
                    {
                        if (checkTab.GroupId != tab.GroupId)
                        {
                            var checkGroup = await _uow.GroupsRepository.GetAsync(tab.GroupId);

                            if (checkGroup == null)
                            {
                                return BadRequest(SYS_Extensions.MessNotFound("group " + tab.GroupId));
                            }
                        }

                        var result = new Tabs();
                        result.Name = tab.Name;
                        result.GroupId = tab.GroupId;
                        result.CreateBy = tab.CreateBy;

                        await _uow.TabsRepository.AddAsync(result);

                        return Ok(SYS_Extensions.MessSuccess(id.ToString(), "Upd"));
                    }

                    return BadRequest(SYS_Extensions.MessNotFound("tab " + id));
                }

                return BadRequest(SYS_Extensions.MessNotFound());
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

                    return BadRequest(SYS_Extensions.MessNotFound("tab " + result.Name));
                }

                return BadRequest(SYS_Extensions.MessNotFound());
            }
            catch (Exception ex)
            {
                return BadRequest(SYS_Extensions.MessNotFound(ex));
            }
        }
        #endregion
    }
}
