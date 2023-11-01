using CarServiceBL.Models.SherdPrrop;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceBL.Models
{
    public class Service :CommonProp
    {
      
        public int ServiceId { get; set; }
        public string? ServiecName { get; set; }
        public string? ServiceDescription { get; set; } 

    }
}
