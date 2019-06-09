using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestIT.Models
{
    public class Competition
    {
        [Key]
        public int ID { get; set; }
        public IList<Participation> Participations { get; set; }
        public Quiz Quiz { get; set; }
        public String Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime Deadline { get; set; }

        public Competition()
        {
            this.Participations = new List<Participation>();
        }
    }
}
