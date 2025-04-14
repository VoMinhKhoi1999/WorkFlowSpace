using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkFlowSpace.Core.Entities
{
    public class Tabs
    {
        //Var
        public int Id { get; set; }

        public string Name { get; set; } = "";
        public int CreateBy { get; set; } //Sau này thêm class user
        public DateTime CreateAt { get; set; }

        public DateTime ModifiDate { get; set; }

        //FK
        public int GroupId { get; set; }
        public virtual Groups Group { get; set; }
        public virtual ICollection<Tasks> Tasks { get; set; } = new HashSet<Tasks>();
    }
}
