using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestIT.Data;
using TestIT.Models;
using TestIT.Models.ViewModels;

namespace TestIT.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public CoursesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Courses
        public async Task<IActionResult> Index()
        {
            return View(await _context.Courses.ToListAsync());
        }

        // GET: Courses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Courses
                .FirstOrDefaultAsync(m => m.ID == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // GET: Courses/Validate/ID
        public async Task<IActionResult> Validate(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            // Optimizacija
            var course = await _context.Courses
                                .Include(x => x.Quizzes)
                                .FirstOrDefaultAsync(x => x.ID == id);

            IList<Quiz> tmp = course.Quizzes
                                .Where(x => x.Visibility == quizVisibility.Ceka).ToList();

            if (tmp == null)
            {
                return NotFound();
            }

            return View(tmp);
        }

        // GET: Courses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,SchoolYear,Name,Description,Short,Module")] Course course)
        {
            if (ModelState.IsValid)
            {
                _context.Add(course);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }

        // GET: Courses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Courses.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,SchoolYear,Name,Description,Short,Module")] Course course)
        {
            if (id != course.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(course);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseExists(course.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }
 
        // GET: Courses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Courses
                .FirstOrDefaultAsync(m => m.ID == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public List<String> getCourses(String year)
        {
            IList<Course> courses = _context.Courses
                .Where(x => x.SchoolYear == year && x.Module == "RII")
                .ToList();
            List<String> names = new List<string>();
            if (courses != null)
            {
                foreach (Course course in courses)
                {
                    names.Add(course.Name);
                }
            }
            return names;
        }
        [HttpGet]
        public List<String> getYears()
        {
            List<String> names = _context.Courses
                     .GroupBy(x => x.SchoolYear)
               .Select(x => x.FirstOrDefault())
               .OrderBy(x => x.ID)
               .Select(x => x.SchoolYear)
               .ToList();
     
   
            return names;
        }
        private bool CourseExists(int id)
        {
            return _context.Courses.Any(e => e.ID == id);
        }
        [HttpPost]
        public async Task<IActionResult> Comment([FromForm] CreateCommentViewModel comment)
        {
            CreateCommentViewModel com = comment;
            Comment save = com.Create();
            ApplicationUser user = await _userManager.GetUserAsync(User);
            save.ApplicationUser = user;
          
             Course course = _context.Courses.Include(x=>x.Comments).FirstOrDefault(x => x.ID == com.CourseID);
            course.Comments.Add(save);
            _context.SaveChanges();
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> Subscribe(int course, string user)
        {
            ApplicationUser u = await _context.Users.FirstOrDefaultAsync(x => x.Id == user);
            Course crs = await _context.Courses
                                .FirstOrDefaultAsync(m => m.ID == course);
            onCours sub = new onCours();
            sub.User = u;
            sub.Course = crs;

            crs.Users.Add(sub);

            _context.SaveChanges();
            int idc = course;
            return RedirectToAction("Course", "Home", new { id = idc  });
        }

        [HttpPost]
        public async Task<IActionResult> Unsubscribe(int course, string user)
        {
            ApplicationUser u = await _context.Users.Include(us=>us.OnCours).ThenInclude(c=>c.Course).FirstOrDefaultAsync(x => x.Id == user);
            Course crs = await _context.Courses.Include(c=>c.Users)
                                .FirstOrDefaultAsync(m => m.ID == course);
            
            for(int i=0;i<u.OnCours.Count;i++)
            {
                if (u.OnCours[i].Course.ID== crs.ID)
                {
                    u.OnCours.RemoveAt(i);
                }
            }
            for (int i = 0;i<crs.Users.Count;i++)
                if(crs.Users[i].User.Id == u.Id)
                    crs.Users.RemoveAt(i);
       
            _context.SaveChanges();
            int idc = course;
            return RedirectToAction("Course", "Home", new { id = idc  });
        }
    }
}
