﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkFlowSpace.infrastructure.Data.DTO
{
    public class GroupsDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int CreateBy { get; set; }
    }
}
