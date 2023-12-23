using GlobalScholar.Data;
using GlobalScholar.Models;
using GlobalScholar.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GlobalScholar.Controllers
{
    public class CountryController : Controller
    {
        private readonly ApplicationDbContext Context;
        public CountryController(ApplicationDbContext context)
        {
            this.Context = context;
        }
        // GET: CountryController
        public ActionResult Index()
        {
            List<Country> countries = Context.Countries.ToList();
            return View(countries);
        }

        // GET: CountryController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CountryController/Create
        public ActionResult Add()
        {
            return View();
        }

        // POST: CountryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(CountryVM country)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = new Country
                    {
                        Name = country.Name,
                    };
                    Context.Countries.Add(data);
                    Context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View();
                }
            }
            catch {
                return View();
            }
        }

        // GET: CountryController/Edit/5
        public ActionResult Edit(long id)
        {
            var country = Context.Countries.Find(id);
            return View(country);
        }

        // POST: CountryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CountryVM country)
        {
            if(ModelState.IsValid)
            {
                var countries = Context.Countries.Find(country.Id);
                countries.Name = country.Name;
                Context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }

        // GET: CountryController/Delete/5
        public ActionResult Delete(long id)
        {
            var country = Context.Countries.Find(id);
            Context.Entry(country).State=EntityState.Deleted;
            Context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // POST: CountryController/Delete/5
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
