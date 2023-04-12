using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INTEX2_group1_3.Models
{
    public class EFBurialRepository : IBurialRepository
    {
        private BurialContext context { get; set; }
        public EFBurialRepository(BurialContext temp)
        {
            context = temp;
        }
       
        public IQueryable<Burialmain> Burials => context.Burials;
    }
}
