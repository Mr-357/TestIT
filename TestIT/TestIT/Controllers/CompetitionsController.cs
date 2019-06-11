using System;
using System.Collections.Generic;
using System.Linq;
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
    public class CompetitionsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public CompetitionsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        [HttpPost]
        public async Task<IActionResult> Start(int? id)
        {
            if (id == null)
                return BadRequest();
            ApplicationUser user = await _userManager.GetUserAsync(User);
            var comp = await _context.Competitions.FirstOrDefaultAsync(x => x.ID == id);
            if (_context.Competitions.Include(l=>l.Participations).FirstOrDefault(x => x.ID == id).Participations.Any(y => y.User.Id == user.Id))
            {
                return Unauthorized();
            }
            Participation p = new Participation();
            p.Competition = comp;
            p.User = user;
            comp.Participations.Add(p);
            _context.SaveChanges();
            return Ok();
        }
        [HttpGet]
        public async Task<List<string>> GetCourses()
        {
            onCours search = new onCours();
            ApplicationUser user = await _userManager.GetUserAsync(User);
            search.User = user;
            
            List<String> courses = _context.Courses
                .Where(x=>x.Users.Any(y=>y.User.Id==user.Id))
                .Select(x=>x.Name)
                .ToList();
            return courses;
        }
        [HttpGet]
        public List<Quiz> GetQuizzes(string name)
        {
            if (name != null && name != "")
            {
                List<Quiz> quizzes = _context.Courses
                .Where(x => x.Name.Equals(name))
                .SelectMany(x => x.Quizzes)
                .ToList();
                return quizzes;
            }
            return null;

        }
        // GET: Competitions
        public async Task<IActionResult> IndexUser()
        {
            var user = await _userManager.GetUserAsync(User);
            return View(await _context.Competitions
                        .Include(x => x.Course)
                        .Include(x=> x.Quiz)
                        .Where(x=>x.Course.Users.Any(u=>u.User.Id.Equals(user.Id))).ToListAsync());
        }
        public async Task<IActionResult> IndexProf()
        {
            var competition = await _context.Competitions
                        .Include(x => x.Course)
                        .Include(x=> x.Quiz)
                        .ToListAsync();
                        
            return View(competition);
        }
        // GET: Competitions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var competition = await _context.Competitions
                .Include(x => x.Course)
                .Include(x=> x.Quiz)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (competition == null)
            {
                return NotFound();
            }

            return View(competition);
        }

        // GET: Competitions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Competitions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CompetitionViewModel competition)
        {
           
            if (ModelState.IsValid)
            {
                Competition comp = new Competition();
                comp.Name = competition.Name;
                comp.StartDate = competition.StartDate;
                comp.Deadline = competition.Deadline;
                comp.Course = _context.Courses.FirstOrDefault(x => x.ID == competition.CourseID);
                comp.Quiz = _context.Quiz.FirstOrDefault(x => x.ID == competition.QuizID);
                _context.Add(comp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(IndexProf));
            }
            return View(competition);
        }

        // GET: Competitions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var competition = await _context.Competitions
                        .Include(x => x.Quiz)
                        .Include(x => x.Course)
                        .FirstOrDefaultAsync(x=> x.ID == id);

            if (competition == null)
            {
                return NotFound();
            }
            return View(competition);
        }

        // POST: Competitions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,StartDate,Deadline")] Competition competition)
        {
            if (id != competition.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(competition);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompetitionExists(competition.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(IndexProf));
            }
            return View(competition);
        }

        // GET: Competitions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var competition = await _context.Competitions
                .Include(x => x.Quiz)
                .Include(x => x.Course)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (competition == null)
            {
                return NotFound();
            }

            return View(competition);
        }

        // POST: Competitions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var competition = await _context.Competitions.FindAsync(id);
            _context.Competitions.Remove(competition);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(IndexProf));
        }

        private bool CompetitionExists(int id)
        {
            return _context.Competitions.Any(e => e.ID == id);
        }
    }
}
