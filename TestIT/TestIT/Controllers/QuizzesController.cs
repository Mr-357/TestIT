using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestIT.Data;
using TestIT.Models;
using TestIT.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;



namespace TestIT.Controllers
{
    public class QuizzesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private Quiz tempQuiz;

        public QuizzesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Quizs
        /*public async Task<IActionResult> Index()
        {
            string currentUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            ApplicationUser currentUser = _context.Users.FirstOrDefault(x => x.Id == currentUserId);
            return View(await _context.Quiz.ToListAsync());
            // return View(await _context.Quiz.ToListAsync());
        }*/
        public IActionResult Index()
        {
            string currentUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            ApplicationUser currentUser = _context.Users.Include(user => user.Quizzes).FirstOrDefault(x => x.Id == currentUserId);
            return View(currentUser.Quizzes);
            // return View(await _context.Quiz.ToListAsync());
        }

        // GET: Quizs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quiz = await _context.Quiz
                .FirstOrDefaultAsync(m => m.ID == id);
            if (quiz == null)
            {
                return NotFound();
            }

            return View(quiz);
        }

        // GET: Quizs/Create
        public IActionResult Create()
        {
            this.tempQuiz = new Quiz();
            return View();
        }

        // POST: Quizs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateQuizViewModel model, string command)
        {
            if(command.Equals("Napravi"))
            {
                if (ModelState.IsValid)
                {
                    string currentUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                    ApplicationUser currentUser = _context.Users.FirstOrDefault(x => x.Id == currentUserId);
                    currentUser.addQuiz(model.Quiz);
                    _context.Add(model.Quiz);
                    await _context.SaveChangesAsync();
                    this.tempQuiz = null;
                    return RedirectToAction(nameof(Index));
                }
                return View(model);
            }
            if(command.Equals("Dodaj pitanje"))
            {
                if (ModelState.IsValid)
                {
                    model.Quiz.Questions.Add(model.TempQuestion);
                    return View(model);
                }
            }
            return View(model);
        }

        // GET: Quizs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quiz = await _context.Quiz.FindAsync(id);
            if (quiz == null)
            {
                return NotFound();
            }
            return View(quiz);
        }

        // POST: Quizs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,numberOfQustionsPerTry,time,Visibility")] Quiz quiz)
        {
            if (id != quiz.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(quiz);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuizExists(quiz.ID))
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
            return View(quiz);
        }

        // GET: Quizs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quiz = await _context.Quiz
                .FirstOrDefaultAsync(m => m.ID == id);
            if (quiz == null)
            {
                return NotFound();
            }

            return View(quiz);
        }

        // POST: Quizs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var quiz = await _context.Quiz.FindAsync(id);
            _context.Quiz.Remove(quiz);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuizExists(int id)
        {
            return _context.Quiz.Any(e => e.ID == id);
        }
    }
}
