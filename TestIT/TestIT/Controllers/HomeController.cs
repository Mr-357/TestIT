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
        private readonly SignInManager<ApplicationUser> signInManager;
        public HomeController(ApplicationDbContext context,UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public async Task<IActionResult> Enroll(string module)
        {
            var tmp = module;
            if (module != null)
            {
                if(signInManager.IsSignedIn(User))
                {
                    ApplicationUser user = await userManager.GetUserAsync(User);
                    user.Modul = module;
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Courses");
                }
                return RedirectToAction("Courses", new { module = tmp});
            }
            return Error();
        }
        public async Task<IActionResult> Courses(string module)
        {
            ApplicationUser user = null;
            String selectedmodule = null;
            if (signInManager.IsSignedIn(User))
            {
                user = await userManager.GetUserAsync(User);
                selectedmodule = (user).Modul;
            }
            else
            {
                selectedmodule = module;
            }

            CoursesViewModel c = new CoursesViewModel(await _context.Courses.Where(x=>x.Module.Contains(selectedmodule)).ToListAsync());
            List<String> names = c.getCourses()
                .Where(x=> x.Module.Contains(selectedmodule))
               .GroupBy(x => x.SchoolYear)
               .Select(x=> x.FirstOrDefault())
               .OrderBy(x=>x.ID)
               .Select(x=>x.SchoolYear)
               .ToList();
            List<String> modules = _context.Courses
                .GroupBy(x => x.Module)
                .Select(x => x.FirstOrDefault())
                .Select(x => x.Module)
                .ToList();
                
                
                //List<String> names = new List<string>();
            //if (courses != null)
            //{
            //    foreach (Course course in courses)
            //    {
            //        names.Add(course.SchoolYear);
            //    }
            //}
           // names.Reverse();
            c.addYears(names);
            c.addModules(modules);
            return View(c);
        }
        [HttpGet]
        public List<String> GetModules()
        {
            List<String> modules = _context.Courses
                .GroupBy(x => x.Module)
                .Select(x => x.FirstOrDefault())
                .Select(x => x.Module)
                .ToList();
            return modules;
        } 

        public async Task<IActionResult> Users()
        {
            var uvm = new UsersViewModel(await _context.Users.ToListAsync());
            List<ApplicationUser> users = _context.Users.ToList();
            uvm.AddUsers(users);
            return View(uvm);
        }

        public async Task<IActionResult> VS(string id)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }
        public async Task<IActionResult> UserInfo(string id)
        {
            var user = await _context.Users
                .Include(x => x.Quizzes)
                .Include(x => x.OnCours)
                .ThenInclude(x => x.Course)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        public async Task<IActionResult> Course(int id)
        {
            var course = await _context.Courses
                .Include(c => c.Users)
                .ThenInclude(c => c.User)
                .Include(y => y.Quizzes)
                .Include(z => z.Comments)
                .ThenInclude(w=>w.ApplicationUser)
               // .Where(c => c.Users.Where( u =>userManager.GetRolesAsync(u.User).ToAsyncEnumerable().ElementAt(0).Equals("Profesor"))
                .FirstOrDefaultAsync(m => m.ID == id);
                
            course.Quizzes = course.Quizzes
                        .Where(x=>x.Visibility == quizVisibility.Javni)
                        .ToList();


            if (course == null)
            {
                return NotFound();
            }
            return View(course);
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

        [HttpPost, ActionName("Subscribe")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SubscribeToCourse(int predmetId, ClaimsPrincipal korisnikId)
        {
            ApplicationUser user = await userManager.GetUserAsync(korisnikId);
            Course crs = await _context.Courses
                                .FirstOrDefaultAsync(m => m.ID == predmetId);
            onCours sub = new onCours();
            sub.User = user;
            sub.Course = crs;

            crs.Users.Add(sub);

            _context.SaveChanges();
            int id = predmetId;
            return RedirectToAction("Course","Home",id);
        }

        [HttpGet]
        public async Task<IActionResult> roleTestRun()
        {
            //kreiranje role-a
            IdentityRole newRole = new IdentityRole("Admin");
            await roleManager.CreateAsync(newRole);
            //privavljane trenutno ulogovanog korisnika
            string currentUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            ApplicationUser currentUser = _context.Users.Include(user => user.Quizzes).FirstOrDefault(x => x.Id == currentUserId);

            //dodavanje role korisniku, ovo je glavni deo
            await userManager.AddToRoleAsync(currentUser, "Admin");

            return View("Index");
        }
        [HttpGet]
        public async Task<IActionResult> roleProf()
        {

            //privavljane trenutno ulogovanog korisnika
            string currentUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            ApplicationUser currentUser = _context.Users.Include(user => user.Quizzes).FirstOrDefault(x => x.Id == currentUserId);

            //dodavanje role korisniku, ovo je glavni deo
            await userManager.AddToRoleAsync(currentUser, "Profesor");
            Course course = _context.Courses
               .Where(x => x.ID == 1)
               .FirstOrDefault();

            onCours onCours = new onCours();
            onCours.User = currentUser;
            onCours.Course = course;

            currentUser.OnCours.Add(onCours);
            course.Users.Add(onCours);

            _context.SaveChanges();

            return View("Index");
        }
    }
}
