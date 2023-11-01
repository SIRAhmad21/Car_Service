using CarServiceBL.Models.SherdPrrop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceBL.Models
{
    public class Comment:CommonProp
    {
        public int Commentid { get; set; }
        public string? CommentTitle { get; set; }
        public string? CommentText { get; set; }

    }
}
