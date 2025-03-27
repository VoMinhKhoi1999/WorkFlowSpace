using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorkFlowSpace.Core.Interface;

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

                return BadRequest("Not found data.");
            }
            catch (Exception ex)
            {
                return BadRequest("Not found.\nError detail: " + ex.ToString());
            }
        }

        //[HttpGet("get-by-id-tabs{/id}")]
        //public Task<ActionResult> Get(int id)
        //{
        //    return Ok();
        //}
        #endregion

        #region change data
        #endregion
    }
}
