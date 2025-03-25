using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkFlowSpace.Core.Interface;
using WorkFlowSpace.infrastructure.Data;

namespace WorkFlowSpace.infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IGroupsRepository GroupsRepository { get; }
        public ITabsRepository TabsRepository { get; }
        public ITasksRepository TasksRepository { get; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            GroupsRepository = new GroupsRepository(_context);
            TabsRepository = new TabsRepository(_context);
            TasksRepository = new TasksRepository(_context);
        }
    }
}
