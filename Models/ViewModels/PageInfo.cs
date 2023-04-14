using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INTEX2_group1_3.Models.ViewModels
{
    public class PageInfo
    {
        public int TotalBurials { get; set; }          //Helps us style the sheet for pagination
        public int BurialsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int PageIndex { get; set; }
        public bool HasPreviousPage { get; set; }
        public bool HasNextPage { get; set; }
        public int TotalNumBurials { get; set; }
        public int TotalPages => (int)Math.Ceiling((decimal)TotalNumBurials / BurialsPerPage);
    }

}
