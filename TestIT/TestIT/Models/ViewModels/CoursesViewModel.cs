using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestIT.Models.ViewModels
{
    public class CoursesViewModel
    {
        private List<Course> courses = new List<Course>();
        private List<String> years;
        private List<String> modules;
        public List<String> getYears()
        {
            return years;
        }
        public List<Course> getCourses()
        {
            return courses;
        }
        public void addYears(List<String> years)
        {
            this.years = years;
        }
        public CoursesViewModel(List<Course> courses)
        {
            this.courses = courses;
        }
        public void addModules(List<String> modules)
        {
            this.modules = modules;
        }
        public List<String> getModules()
        {
            return this.modules;
        }
    }
}
