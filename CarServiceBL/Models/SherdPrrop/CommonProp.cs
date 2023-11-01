using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceBL.Models.SherdPrrop
{
    public class CommonProp
    {
        public DateTime CreationData { get; set; }
        [NotMapped]
        public IFormFile Image { get; set; }
        public string? ImagePath { get; set; } 
        public bool IsDeleted { get; set; }
        //public bool IsPublised { get; set; }
    }
}
