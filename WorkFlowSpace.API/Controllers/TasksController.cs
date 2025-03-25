using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorkFlowSpace.Core.Interface;

namespace WorkFlowSpace.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public TasksController(IUnitOfWork uow)
        {
            this._uow = uow;
        }

    }
}
