using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceBL.Models.ViewModel
{
    public class EditRoleViewModel
    {
        public EditRoleViewModel()
        {
            Users = new List<string>();
        }
        public string? RoleId { get; set; }
        [Required(ErrorMessage = "Enter Role Name")]
        [MaxLength(25, ErrorMessage = "Max 25 ")]
        [MinLength(3, ErrorMessage = "Min Lentgh 3")]
        public string? RoleName { get; set; }
        public List<string> Users { get; set; }
    }
}
