using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INTEX2_group1_3.Models
{
    public class TwoFactorModel
    {
        public string SecretKey { get; set; }
        public string QrCodeImageUrl { get; set; }
    }
}
