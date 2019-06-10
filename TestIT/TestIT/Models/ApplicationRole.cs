using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestIT.Models
{

    //ovo je za sad useles i ne koristi se, zato sto ne znam kako da ga napravim da radi, al nek bude ovde cu ga napravim pre ili kasnije
    public class ApplicationRole : IdentityRole
    {

        public ApplicationRole() : base() { }
        public ApplicationRole(String roleName) : base(roleName) { }
    }
}
