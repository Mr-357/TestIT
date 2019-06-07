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
using System.IO;

namespace TestIT.Controllers
{
    public class QuizzesController : Controller
    {
        private readonly ApplicationDbContext _context;

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
        
        public IActionResult ChooseQuiz()
        {
            return View();
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
            return View();
        }
        public class FetchQuiz
        {
            public int ID { get; set; }
            public String Name { get; set; }
        }
        //TLDR kako koristiti fetch i controller
        //ovaj httppost tag znaci da fja podrzava post metodu
        //fromform tag znaci da pravi objekat iz forme oblika u post-u,postoji i frombody koji to radi iz json-a (mada meni nije uspelo)
        //iznad ovoga sam napravio pomocnu klasu fetchquiz cisto da vidim kako i da li ovo radi, trebalo bi da radi i sa nasim modelima
        //fja vraca Ok() zbog one provere u js-u (response.ok) , moguce je da vrati npr json objekat sa nekim informacijama ili url za redirekciju
        //redirecttoaction() NE RADI preko fetch-a
        //ostatak objasnjena u site.js
        
        [HttpPost]
        public async Task<IActionResult> FetchCreate([FromForm]QuizViewModel model)
        {
            string currentUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            ApplicationUser current = _context.Users.FirstOrDefault(x => x.Id == currentUserId);

            Quiz temp = new Quiz(model);
            current.addQuiz(new Quiz(model));
            await _context.SaveChangesAsync();
            
           // return Redirect("/Quizzes/Index");
            return Ok();
        }
       
        // POST: Quizs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
       /* [HttpPost]
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
        }*/

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

        public async Task<IActionResult> AttemptQuiz(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var quiz = await _context.Quiz
                .Include(q => q.Questions)
                .ThenInclude(q => q.Answers)
                .FirstOrDefaultAsync(e => e.ID == id);
            if (quiz == null)
            {
                return NotFound();
            }
            string quizData = Newtonsoft.Json.JsonConvert.SerializeObject(quiz, new Newtonsoft.Json.JsonSerializerSettings()
            {
                PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects,
                Formatting = Newtonsoft.Json.Formatting.Indented
            });
            ViewBag.jsonQuiz = (quizData);
            return View();
        }
        //GET: 
        public async Task<IActionResult> AttemptQuiz2(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var quiz = await _context.Quiz
                .Include(q => q.Questions)
                .ThenInclude(q => q.Answers)
                .FirstOrDefaultAsync(e => e.ID == id);
            if (quiz == null)
            {
                return NotFound();
            }
            AttemptQuizViewModel viewModel = new AttemptQuizViewModel();
            viewModel.fillFromQuiz(quiz);
            return View(viewModel);
        }

        //POST:
        [HttpPost]
        public async Task<IActionResult> Results([FromForm]QuizViewModel quizAttempt)
        {
            int? id = quizAttempt.ID;
            if (id == null)//i ako mi kaze warning ovde da id nikad ne moze da bude null, mislim da ipak treda ba odtane ova provera
            {
                return NotFound();
            }
            var quiz = await _context.Quiz
                .Include(q => q.Questions)
                .ThenInclude(q => q.Answers)
                .FirstOrDefaultAsync(e => e.ID == id);
            if (quiz == null)
            {
                return NotFound();
            }
            ResultsViewModel result = validate(quiz, quizAttempt); //tek treba da se implementira

            return View(result);
        }

        private ResultsViewModel validate(Quiz quiz, QuizViewModel viewModel)
        {
            ResultsViewModel results = new ResultsViewModel();
            results.copyInfo(quiz);
            for (int i = 0; i < quiz.Questions.Count; i++)
            {
                ResultQuestion resultQuestion = new ResultQuestion(quiz.Questions[i],viewModel.Questions[i]);
                results.Questions.Add(resultQuestion);
            }
            results.countRightAnswers();
            return results;
        }
        /*[HttpGet]
        public IActionResult Results()
        {
            return View();
        }*/

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

        // GET: Quizs/Publish/5
        public async Task<IActionResult> Publish(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var tmp = _context.Quiz
                        .FirstOrDefault(x => x.ID == id);

            tmp.Visibility = quizVisibility.Ceka;
            _context.SaveChanges();
            return RedirectToAction("Index","Quizzes");
        }

        // POST: Quizs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var quiz = await _context.Quiz
                .Include(q=> q.Questions)
                .ThenInclude(q => q.Answers)
                .FirstOrDefaultAsync(e => e.ID == id);

            _context.Quiz.Remove(quiz);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuizExists(int id)
        {
            return _context.Quiz.Any(e => e.ID == id);
        }



        [HttpGet]
        public IActionResult CreateTournament()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AdminQuiz()
        {
            return View();
        }
    }
}
