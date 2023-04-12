using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INTEX2_group1_3.Models.ViewModels
{
    public class SearchViewModel
    {
        public List<Burialmain> Burials { get; set; }
        public string SearchQuery { get; set; }
        public PageInfo PageInfo { get; set; }
        public FilterViewModel Filters { get; set; }
    }
}
