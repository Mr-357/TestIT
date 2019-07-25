using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestIT.Models.ViewModels
{
    public class UsersViewModel
    {
        private List<ApplicationUser> users = new List<ApplicationUser>();
        public List<ApplicationUser> GetUsers()
        {
            return users;
        }
        public void AddUsers(List<ApplicationUser> users)
        {
            this.users = users;
        }
        public UsersViewModel(List<ApplicationUser> users)
        {
            this.users = users;
        }
    }
}
