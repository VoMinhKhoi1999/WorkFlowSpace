using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkFlowSpace.Core.Entities
{
    public class Groups
    {
        //Var
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public int CreateBy { get; set; } //Sau này thêm class user
        public DateTime CreateAt { get; set; }

        public virtual ICollection<Tabs> Tabs { get; set; } = new HashSet<Tabs>();
    }
}
