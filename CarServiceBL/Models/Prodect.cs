using CarServiceBL.Models.SherdPrrop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceBL.Models
{
    public class Prodect :CommonProp
    {
        public int ProdectId { get; set; }
        public string? ProdectName { get; set; }
        public string? ProdectDescription { get; set; }
        public string? Size { get; set; }
        public string? Price { get; set; }
        public string Type { get; set; } 
      
    }
}
