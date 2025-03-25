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
    public class TabsRepository : GenericRepository<Tabs>, ITabsRepository
    {
        public TabsRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
