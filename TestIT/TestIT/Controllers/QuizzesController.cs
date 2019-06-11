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
using Microsoft.AspNetCore.Http;

namespace TestIT.Controllers
{
    public class QuizzesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public QuizzesController(ApplicationDbContext context)
        {
            _context = context;
        }

        
        public IActionResult Index()
        {
            string currentUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            ApplicationUser currentUser = _context.Users.Include(user => user.Quizzes).FirstOrDefault(x => x.Id == currentUserId);
            return View(currentUser.Quizzes);
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
                .Include(x => x.Questions)
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
        
        [HttpPost]
        public async Task<IActionResult> FetchCreate([FromForm]QuizViewModel model)
        {
            
            string currentUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            ApplicationUser current = _context.Users.FirstOrDefault(x => x.Id == currentUserId);

            Course course = _context.Courses
                .Where(x => x.Name == model.Course)
                .FirstOrDefault();

            Quiz temp = new Quiz(model);
            current.addQuiz(new Quiz(model));
            course.Quizzes.Add(temp);
            await _context.SaveChangesAsync();
            
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> FetchImagePost([FromForm]List<IFormFile> images)
        {
            long size = images.Sum(f => f.Length);

            // full path to file in temp location
            List<String> filePaths = new List<string>();

            foreach (var formFile in images)
            {
                var filePath = Path.GetTempFileName();
                filePath = filePath.Replace(".tmp", ".jpg");
                if (formFile.Length > 0)
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                }
                filePaths.Add(filePath);
            }

            // process uploaded files
            // Don't rely on or trust the FileName property without validation.
            return Ok( Json(new { count = images.Count, size, filePaths }));
        }
        

        // GET: Quizs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quiz = await _context.Quiz
                    .Include(x=> x.Questions)
                    .FirstOrDefaultAsync(x => x.ID == id);
            if (quiz == null)
            {
                return NotFound();
            }
            return View(quiz);
        }

        //public async Task<IActionResult> AttemptQuiz(int? id,int? comp) fuck off
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    var quiz = await _context.Quiz
        //        .Include(q => q.Questions)
        //        .ThenInclude(q => q.Answers)
        //        .FirstOrDefaultAsync(e => e.ID == id);
        //    if (quiz == null)
        //    {
        //        return NotFound();
        //    }
       
        //    string quizData = Newtonsoft.Json.JsonConvert.SerializeObject(quiz, new Newtonsoft.Json.JsonSerializerSettings()
        //    {
        //        PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects,
        //        Formatting = Newtonsoft.Json.Formatting.Indented
        //    });
        //    ViewBag.jsonQuiz = (quizData);
        //    return View();
        //}
        //GET: 
        public async Task<IActionResult> AttemptQuiz2(int? id,int? comp)
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
            if (comp != null)
            {
                viewModel.Comp = comp.Value;
            }
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


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ValidateSuccessful(int id, [Bind("ID,Name,numberOfQustionsPerTry,time,Visibility")] Quiz quiz)
        {
            if (id != quiz.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    quiz.Visibility = quizVisibility.Javni;
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

        [HttpGet]
        public async Task<IActionResult> ValidateFailed(int? id)
        {
            var quiz = _context.Quiz
                    .FirstOrDefault(x => x.ID == id);
            if(quiz != null)
            {
                try
                {
                    quiz.Visibility = quizVisibility.Privatni;
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

        public async Task<IActionResult> Validate(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quiz = await _context.Quiz
                    .Include(x=> x.Questions)
                    .FirstOrDefaultAsync(x => x.ID == id);
            if (quiz == null)
            {
                return NotFound();
            }
            return View(quiz);
        }


        private ResultsViewModel validate(Quiz quiz, QuizViewModel viewModel)
        {
            ResultsViewModel results = new ResultsViewModel();
            results.copyInfo(quiz);
            for (int i = 0; i < quiz.Questions.Count; i++)
            {
                if(quiz.Questions[i].Picture != null)
                    results.Images.Add(i, FileToByteArray(quiz.Questions[i].Picture));
                ResultQuestion resultQuestion = new ResultQuestion(quiz.Questions[i],viewModel.Questions[i]);
                results.Questions.Add(resultQuestion);
            }
            results.countRightAnswers();
            return results;
        }

        public byte[] FileToByteArray(string fileName)
        {
            byte[] buff = null;
            FileStream fs = new FileStream(fileName,
                                           FileMode.Open,
                                           FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            long numBytes = new FileInfo(fileName).Length;
            buff = br.ReadBytes((int)numBytes);
            return buff;
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

        // GET: Quizs/Publish/5
        public async Task<IActionResult> Publish(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var tmp = await _context.Quiz
                        .FirstOrDefaultAsync(x => x.ID == id);

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
        public IActionResult AdminQuiz()
        {
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> Question(int? id)
        {
            if(id ==null)
            {
                return NotFound();
            }

            var question = await _context.Quiz
                    .SelectMany(x => x.Questions)
                    .Include(x => x.Answers)
                    .Include(x => x.Quiz)
                    .FirstOrDefaultAsync(x => x.ID == id);

            return View(question);
        }
        [HttpPost]
        public async Task<IActionResult> EditQuestion([FromForm] EditQuestionModel model)
        {
            var question = await _context.Quiz
                    .SelectMany(x => x.Questions)
                    .Include(x => x.Answers)
                    .Include(x => x.Quiz)
                    .FirstOrDefaultAsync(x => x.ID == model.ID);
            question.Answers.Clear();
            question.update(model);
            _context.Update(question);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
