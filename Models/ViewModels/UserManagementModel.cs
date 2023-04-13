using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INTEX2_group1_3.Models.ViewModels
{
    public class UserManagementModel : Controller
    {
        public List<AspNetUsers> Persons { get; set; }
    }
}
