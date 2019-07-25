using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestIT.Models
{
    public class onCours
    {
        [Key]
        public int ID { get; set; }
        [Column("userID")]
        public ApplicationUser User { get; set; }
        [Column("courseID")]
        public Course Course { get; set; }
    }
}
