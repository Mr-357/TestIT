using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestIT.Data;
using TestIT.Models;
using TestIT.Models.ViewModels;

namespace TestIT.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        public HomeController(ApplicationDbContext context,UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> Courses()
        {
           CoursesViewModel c = new CoursesViewModel(await _context.Courses.ToListAsync());
            IList<Course> courses = _context.Courses
               .GroupBy(x => x.SchoolYear)
               .Select(x => x.FirstOrDefault())
               .OrderBy(x=>x.ID)
               .ToList();
            List<String> names = new List<string>();
            if (courses != null)
            {
                foreach (Course course in courses)
                {
                    names.Add(course.SchoolYear);
                }
            }
           // names.Reverse();
            c.addYears(names);
            return View(c);
        }

        public IActionResult Users()
        {
            return View();
        }

        public IActionResult Course(int id)
        {
            return View();
        }

        public IActionResult VS()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult AdminUser()
        {
            return View();
        }

        [HttpGet]//ovo je primer za povezivanje kursa sas coveka,i ne treba koristiti ovu akciju direktno
        public async Task<IActionResult> testRun()
        {
            Course course = _context.Courses
                .Where(x => x.ID == 1)
                .FirstOrDefault();
            string currentUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            ApplicationUser currentUser = _context.Users.Include(user => user.Quizzes).FirstOrDefault(x => x.Id == currentUserId);

            onCours onCours = new onCours();
            onCours.User = currentUser;
            onCours.Course = course;

            currentUser.OnCours.Add(onCours);
            course.Users.Add(onCours);

            _context.SaveChanges();

            return View("Index");
        }

        [HttpGet]
        public async Task<IActionResult> roleTestRun()
        {
            //kreiranje role-a
            IdentityRole newRole = new IdentityRole("Student");
            await roleManager.CreateAsync(newRole);
            //privavljane trenutno ulogovanog korisnika
            string currentUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            ApplicationUser currentUser = _context.Users.Include(user => user.Quizzes).FirstOrDefault(x => x.Id == currentUserId);

            //dodavanje role korisniku, ovo je glavni deo
            await userManager.AddToRoleAsync(currentUser, "Student");

            return View("Index");
        }
    }
}
