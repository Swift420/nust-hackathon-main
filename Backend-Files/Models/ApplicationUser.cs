using Microsoft.AspNetCore.Identity;
using schoolAdmin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace schoolAdmin.Models
{
    public class ApplicationUser : IdentityUser
    {
            [PersonalData]
            [Display(Name = "First Name")]
            public string FirstName { get; set; }
            [PersonalData]
            [Display(Name = "Last Name")]
            public string LastName { get; set; }
            public AccessLevels Access { get; set; }
            public Workloads Workload { get; set; }
    }
        
}
