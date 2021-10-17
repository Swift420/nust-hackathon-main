using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace schoolAdmin.Models
{ 
    public class Workloads
    {
        [Key]
        public int WorkloadID { get; set; }
        public string Description { get; set; }
    }
}
