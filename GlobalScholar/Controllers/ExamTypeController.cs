using GlobalScholar.Data;
using GlobalScholar.Models;
using GlobalScholar.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GlobalScholar.Controllers
{
    public class ExamTypeController : Controller
    {
        private readonly ApplicationDbContext Context;

        public ExamTypeController(ApplicationDbContext context)
        {
            Context = context;
        }

        // GET: ExamTypeController
        public ActionResult Index()
        {
            List<ExamType> examTypes = Context.ExamTypes.ToList();
            return View(examTypes);
        }

        // GET: ExamTypeController/Details/5
        public ActionResult Details(long id)
        {
            return View();
        }

        // GET: ExamTypeController/Create
        public ActionResult Add()
        {
            return View();
        }

        // POST: ExamTypeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(ExamTypeVm examTypeVm)
        {
            if(ModelState.IsValid)
            {
                var data = new ExamType
                {
                    Name = examTypeVm.Name
                };
                Context.ExamTypes.Add(data);
                Context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }

        // GET: ExamTypeController/Edit/5
        public ActionResult Edit(long id)
        {
            //var examtypes = Context.ExamTypes.Find(id);
            //return View(examtypes);
            return View();
        }

        // POST: ExamTypeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ExamTypeVm examTypeVm)
        {
            if(ModelState.IsValid)
            {
                var examtypes = Context.ExamTypes.Find(examTypeVm.Id);
                examtypes.Name=examTypeVm.Name;
                Context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }

        // GET: ExamTypeController/Delete/5
        public ActionResult Delete(long id)
        {
            var examType = Context.ExamTypes.Find(id);
            Context.Entry(examType).State = EntityState.Deleted;
            Context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // POST: ExamTypeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
