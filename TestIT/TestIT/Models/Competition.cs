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
        [Display(Name="Ucesnici")]
        public IList<Participation> Participations { get; set; }
        [Display(Name="Kviz")]
        public Quiz Quiz { get; set; }
        [Display(Name="Naziv")]
        public String Name { get; set; }
        [Display(Name="Pocetak")]
        public DateTime StartDate { get; set; }
        [Display(Name="Rok")]
        public DateTime Deadline { get; set; }
        [Display(Name="Predmet")]
        public Course Course { get; set; }
        public Competition()
        {
            this.Participations = new List<Participation>();
        }
    }
}
