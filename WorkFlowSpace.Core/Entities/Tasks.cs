using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkFlowSpace.Core.Entities
{
    public class Tasks
    {
        public int Id { get; set; }

        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public int AssignedTo { get; set; }

        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Status { get; set; }

        public int CreateBy { get; set; } //Sau này thêm class user
        public DateTime CreateAt { get; set; }
        public DateTime ModifiDate { get; set; }

        //FK
        public int TabId { get; set; }
        public virtual Tabs Tab { get; set; }
    }
}
