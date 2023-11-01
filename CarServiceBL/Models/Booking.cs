using CarServiceBL.Models.SherdPrrop;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceBL.Models
{
    public class Booking : CommonProp

    {
        public int BookingId { get; set; }

        [Required(ErrorMessage = "Please Enter Your Name")]

        public string? Name { get; set; }
        [EmailAddress(ErrorMessage = "Example user@hotmail.com")]
        [Required(ErrorMessage = "Enter Your Email")]
        [MaxLength(40, ErrorMessage = "Max Char 40 Latter")]
        public String? Email { get; set; }
        [Required(ErrorMessage = "Enter Your Mobile Number 07..")]
        public string? MobileNumber { get; set; }
        [Required(ErrorMessage = "Please Choose Your Visit Time")]
        public DateTime VistTime { get; set; }

        public string? City { get; set; }

        // [Required(ErrorMessage = "Please Choose Your Service")]
        [ForeignKey("Service")]
        public int ServiceId { get; set; }
        public Service? Service { get; set; }

    }
}
