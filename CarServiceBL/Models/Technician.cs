using CarServiceBL.Models.SherdPrrop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceBL.Models
{
    public class Technician : CommonProp
    {
        public int TechnicianId { get; set; }
        public string? TechnicianName { get; set; }
        public string? TechnicianDescription { get; set; }
    }
}
