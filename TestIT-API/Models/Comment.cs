using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestIT.Models
{
    public class Comment
    {
        [Key]
        public int ID { get; set; }

        public String Content { get; set;}

        public ApplicationUser ApplicationUser{ get; set; }
        public Course Course { get; set; }
    }
}