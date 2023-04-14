using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INTEX2_group1_3.Models.ViewModels
{
    public class BurialViewModel
    {
        public FilterForm FilterForm { get; set; }
        public List<Burialmain>? Burials { get; set; }
        public PageInfo? PageInfo { get; set; }

    }
}