using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestIT.Models.ViewModels
{
    public class CreateQuizViewModel
    {
        public Quiz Quiz { get; set; }
        public Question TempQuestion { get; set; }
        public Answer TempAnswer { get; set; }

    }
}
