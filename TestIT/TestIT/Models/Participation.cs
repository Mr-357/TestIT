using System.ComponentModel.DataAnnotations;

namespace TestIT.Models
{
    public class Participation
    {
        [Key]
        public int ID { get; set; }
        public ApplicationUser User { get; set; }
        public Competition Competition { get; set; }
        public double Score { get; set; }
    }
}