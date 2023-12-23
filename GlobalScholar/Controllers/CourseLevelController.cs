using GlobalScholar.Data;
using GlobalScholar.Models;
using GlobalScholar.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GlobalScholar.Controllers
{
    public class CourseLevelController : Controller
    {
        private readonly ApplicationDbContext Context;

        public CourseLevelController(ApplicationDbContext context)
        {
            Context = context;
        }

        // GET: CourseLevelController
        public ActionResult Index()
        {
            List<CourseLevel> data = Context.CourseLevels.ToList();
            return View(data);
        }

        // GET: CourseLevelController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CourseLevelController/Create
        public ActionResult Add()
        {
            return View();
        }

        // POST: CourseLevelController/Create
        [HttpPost]
        public ActionResult Add(CourseLevelVm courseLevelVm)
        {
            if(ModelState.IsValid)
            {
                var data = new CourseLevel
                {
                    Name = courseLevelVm.Name
                };
                Context.CourseLevels.Add(data);
                Context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }

        // GET: CourseLevelController/Edit/5
        public ActionResult Edit(long id)
        {
            var courselevel = Context.CourseLevels.Find(id);
            return View(courselevel);
        }

        // POST: CourseLevelController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CourseLevelVm courseLevelVm)
        {
            if(ModelState.IsValid)
            {
                var courselevel = Context.CourseLevels.Find(courseLevelVm.Id);
                courselevel.Name = courseLevelVm.Name;
                Context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }

        // GET: CourseLevelController/Delete/5
        public ActionResult Delete(long id)
        {
            var courseLevel = Context.CourseLevels.Find(id);
            Context.Entry(courseLevel).State = EntityState.Deleted;
            Context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // POST: CourseLevelController/Delete/5
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
