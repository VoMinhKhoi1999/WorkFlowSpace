using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkFlowSpace.Core.Entities;
using WorkFlowSpace.Core.Interface;
using WorkFlowSpace.infrastructure.Data;

namespace WorkFlowSpace.infrastructure.Repository
{
    public class GroupsRepository : GenericRepository<Groups>, IGroupsRepository
    {
        public GroupsRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
