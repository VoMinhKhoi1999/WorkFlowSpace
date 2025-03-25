using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkFlowSpace.Core.Interface
{
    public interface IUnitOfWork
    {
        public IGroupsRepository GroupsRepository { get; }
        public ITabsRepository TabsRepository { get; }
        public ITasksRepository TasksRepository { get; }
    }
}
