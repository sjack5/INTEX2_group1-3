using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INTEX2_group1_3.Models.ViewModels
{
    public class FilterViewModel
    {
        public IEnumerable<string> Sex { get; set; }
        public IEnumerable<string> Depth { get; set; }
        public IEnumerable<string> Length { get; set; }
        public IEnumerable<string> Ageatdeath { get; set; }
        public IEnumerable<string> Headdirection { get; set; }
        public IEnumerable<long?> Burialid { get; set; }
        public IEnumerable<string> Haircolor { get; set; }
        public IEnumerable<string> Facebundles { get; set; }
    }
}
