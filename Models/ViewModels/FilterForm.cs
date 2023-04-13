using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INTEX2_group1_3.Models.ViewModels
{
    public class FilterForm
    {
        public List<Burialmain> Burials { get; set; }
        public List<string> BurialDirections { get; set; }
        public List<string> Burialnumbers { get; set; }
        public List<string> Depths { get; set; }
        public List<string> Headdirections { get; set; }
        public List<string> Ageatdeaths { get; set; }
        public List<string> Lengths { get; set; }
        public List<string> Sexs { get; set; }
        public List<string> Haircolors { get; set; }
    }
}