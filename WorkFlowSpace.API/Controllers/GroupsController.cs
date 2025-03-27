using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using WorkFlowSpace.Core.Entities;
using WorkFlowSpace.Core.Interface;
using WorkFlowSpace.infrastructure.Data.DTO;

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

        #region get
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

                return BadRequest("Not found data.");
            }
            catch (Exception ex)
            {
                return BadRequest("Not found.\nError detail: " + ex.ToString());
            }
        }

        [HttpGet("get-by-id-groups/{id}")]
        public async Task<ActionResult> Get(int id)
        {
            try
            {
                var result = _uow.GroupsRepository.GetAsync(id);

                if (result != null)
                {
                    return Ok(result);
                }

                return BadRequest($"Not found this id = [{id}].");
            }
            catch (Exception ex)
            {
                return BadRequest("Not found.\nError detail: " + ex.ToString());
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
                    var result = new Groups();
                    result.Name = groups.Name;
                    result.CreateBy = groups.CreateBy;
                    result.CreateAt = DateTime.Now;
                    result.ModifiDate = DateTime.Now;

                    await _uow.GroupsRepository.AddAsync(result);
                    return Ok($"Group [{result.Name}] is created!");
                }

                return BadRequest("Not found");
            }
            catch(Exception ex)
            {
                return BadRequest("Not found.\nError detail: " + ex.ToString());
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
                    }

                    await _uow.GroupsRepository.UpdateAsync(id, result);
                    return Ok($"Group [{result.Id}] is updated!");
                }

                return BadRequest($"Group [{id}] is not found.");
            }
            catch (Exception ex)
            {
                return BadRequest("Not found.\nError detail: " + ex.ToString());
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
                        return Ok($"Group [{result.Name}] is deleted!");
                    }
                }

                return BadRequest($"Group [{id}] is not found.");
            }
            catch (Exception ex)
            {
                return BadRequest("Not found.\nError detail: " + ex.ToString());
            }
        }
        #endregion
    }
}
