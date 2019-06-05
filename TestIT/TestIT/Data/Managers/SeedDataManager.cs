using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TestIT.Models;
namespace TestIT.Data.Managers
{
    public class SeedDataManager
    {
        public static List<Course> getCoursSeedData()
        {
            List<Course> predmeti = new List<Course>();
            using (var sr = new StreamReader("Data/Managers/CourseSeedData.tsd"))
            {
                int i = 1;
                while (!sr.EndOfStream)
                {
                    string tmpNaziv = sr.ReadLine();
                    string tmpGodina = sr.ReadLine();
                    string tmpModule = sr.ReadLine();
                    string tmpSkracenica = sr.ReadLine();

                    string tmp = sr.ReadLine();
                    string tmpOpis = "";
                    do
                    {
                        tmpOpis += tmp;
                        tmp = sr.ReadLine();
                    }
                    while (tmp != "###");

                    predmeti.Add(new Course() { ID = i++, SchoolYear = tmpGodina, Short = tmpSkracenica, Name = tmpNaziv, Description = tmpOpis , Module = tmpModule });
                }

                
            }
            return predmeti;
        }
        public static List<IdentityRole> getRoleSeedData()
        {
            String[] rolesData = { "Admin", "Moderator", "Student" , "Profesor" };
            List<IdentityRole> roles = new List<IdentityRole>();
            IdentityRole newRole;
            foreach(String data in rolesData)
            {
                newRole = new IdentityRole(data);
                newRole.NormalizedName = data.ToUpper();
                roles.Add(newRole);
            }
            return roles;
        }
    }
}
