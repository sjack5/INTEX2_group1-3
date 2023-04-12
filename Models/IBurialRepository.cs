using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INTEX2_group1_3.Models
{
    public interface IBurialRepository
    {
        IQueryable<Burialmain> Burials { get; }
    }
}
