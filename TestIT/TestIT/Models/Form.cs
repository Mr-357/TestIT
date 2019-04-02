using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestIT.Models
{
    public class Form
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Data { get; set; }
    }

}
