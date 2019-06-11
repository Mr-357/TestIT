using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestIT.Data;
using TestIT.Data.Managers;
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
        private readonly EmailSender emailSender;
        public HomeController(IEmailSender emailSender, ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.signInManager = signInManager;
            this.emailSender = (EmailSender)emailSender;
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
            if (module != null && module!="")
            {
                if (signInManager.IsSignedIn(User))
                {
                    ApplicationUser user = await userManager.GetUserAsync(User);
                    user.Modul = module;
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Courses");
                }
                return RedirectToAction("Courses", new { module = tmp });
            }
            return BadRequest();
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

            CoursesViewModel c = new CoursesViewModel(await _context.Courses.Where(x => x.Module.Contains(selectedmodule)).ToListAsync());
            List<String> names = c.getCourses()
                .Where(x => x.Module.Contains(selectedmodule))
               .GroupBy(x => x.SchoolYear)
               .Select(x => x.FirstOrDefault())
               .OrderBy(x => x.ID)
               .Select(x => x.SchoolYear)
               .ToList();
            List<String> modules = _context.Courses
                .GroupBy(x => x.Module)
                .Select(x => x.FirstOrDefault())
                .Select(x => x.Module)
                .ToList();

            
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
            if (id == null || id == "")
                return BadRequest();
            var user = await _context.Users
                .Include(x => x.OnCours)
                .ThenInclude(x => x.Course)
                .ThenInclude(x => x.Quizzes)
                .FirstOrDefaultAsync(x => x.Id == id);

            var loggedInUserId = userManager.GetUserId(User);

            var loggedInUser = await _context.Users
                                .Include(x => x.OnCours)
                                .ThenInclude(x => x.Course)
                                .ThenInclude(x => x.Quizzes)
                                .FirstOrDefaultAsync(x => x.Id == loggedInUserId);



            var zajednicki = new List<Course>();
            for (int i = 0; i < loggedInUser.OnCours.Count; i++)
                for (int j = 0; j < user.OnCours.Count; j++)
                    if (user.OnCours[j].Course.Name == loggedInUser.OnCours[i].Course.Name)
                        zajednicki.Add(user.OnCours[j].Course);


            if (zajednicki.Count != 0)
                ViewBag.Message = zajednicki;

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

        public async Task<IActionResult> Course(int? id)
        {
            if (id == null)
                return NotFound();
            var course = await _context.Courses
                .Include(c => c.Users)
                .ThenInclude(c => c.User)
                .Include(y => y.Quizzes)
                .Include(z => z.Comments)
                .ThenInclude(w => w.ApplicationUser)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (course == null)
            {
                return NotFound();
            }
            course.Quizzes = course.Quizzes
                        .Where(x => x.Visibility == quizVisibility.Javni)
                        .ToList();
            if (signInManager.IsSignedIn(User))
            {
                ApplicationUser user = await userManager.GetUserAsync(User);
                foreach (var p in user.OnCours)
                {
                    if (p.Course.ID == course.ID)
                        ViewBag.Message = "prijavljen";
                    else
                        ViewBag.Message = "nije";
                }
            }
            else
            {
                ViewBag.Message = "nije";
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
        public async Task<IActionResult> DeleteComment(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            if (User.IsInRole("Student"))
            {
                return Unauthorized();
            }
            Comment toremove = _context.Courses.Include(x=>x.Comments).Select(x=>x.Comments).FirstOrDefault().Where(x=>x.ID==id).FirstOrDefault();
            _context.Courses.Include(x => x.Comments).Select(x => x.Comments).FirstOrDefault().Remove(toremove);
           
            _context.Remove(toremove);
            _context.SaveChanges();

            return Ok();
        }
        [HttpGet]//ove sve akcije nadole bi trebalo da izbrisemo 
        public async Task<IActionResult> testRun()
        {
            Course course = await _context.Courses
                .Where(x => x.ID == 1)
                .FirstOrDefaultAsync();
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
            IdentityRole newRole = new IdentityRole("Admin");
            await roleManager.CreateAsync(newRole);
            //privavljane trenutno ulogovanog korisnika
            string currentUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            ApplicationUser currentUser = _context.Users.Include(user => user.Quizzes).FirstOrDefault(x => x.Id == currentUserId);

            //dodavanje role korisniku, ovo je glavni deo
            await userManager.AddToRoleAsync(currentUser, "Admin");

            return View("Index");
        }
        [HttpPost]
        public async Task<IActionResult> roleProf(string id)
        {

            //privavljane trenutno ulogovanog korisnika
            var currentUser = await _context.Users
                            .Include( x=> x.Quizzes)
                            .FirstOrDefaultAsync(x => x.Id == id);

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

        public IActionResult AboutUs()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> promoteUser([FromForm]string userID, [FromForm]string newRole)
        {
            ApplicationUser user = userManager.Users.Where(u => u.Id.Equals(userID)).FirstOrDefault();
            var roles = userManager.GetRolesAsync(user);
            var role = roles.Result.FirstOrDefault();
            await userManager.RemoveFromRoleAsync(user, role);
            await userManager.AddToRoleAsync(user, newRole);

            return View("index");
        }

        [HttpPost]
        public IActionResult warnUser([FromForm]string userID,[FromForm]string username,[FromForm]string warningText)
        {
            if(username != null)
            {
                ViewBag.userID = userID;
                ViewBag.username = username;
                return View();
            }
            ApplicationUser user = userManager.Users.Where(u => u.Id.Equals(userID)).FirstOrDefault();
            if(user != null)
            {
                emailSender.SendEmailAsync(user.Email, "upozoreni ste", warningText != null ? warningText : "upozoreni ste od strane jednog od aministratora TestIT platforme");
            }
            return View("index");

        }

        [HttpPost]
        public IActionResult deleteUser([FromForm]string userID, [FromForm]string username)
        {
            ViewBag.userID = userID;
            ViewBag.username = username;
            return View();
        }

    }
}
