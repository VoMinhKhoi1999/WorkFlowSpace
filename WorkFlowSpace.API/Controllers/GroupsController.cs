using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorkFlowSpace.Core.Interface;

namespace WorkFlowSpace.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public GroupsController(IUnitOfWork uow)
        {
            this._uow = uow;
        }

    }
}
