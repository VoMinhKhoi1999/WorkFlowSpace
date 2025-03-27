using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkFlowSpace.infrastructure.Data.DTO
{
    public class TasksDTO
    {
        [Required]
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public int AssignedTo { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Status { get; set; }
        [Required]
        public int CreateBy { get; set; }
        [Required]
        public int TabID { get; set; }
    }
}
