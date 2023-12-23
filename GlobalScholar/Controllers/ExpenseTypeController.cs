using GlobalScholar.Data;
using GlobalScholar.Models;
using GlobalScholar.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GlobalScholar.Controllers
{
    public class ExpenseTypeController : Controller
    {
        private readonly ApplicationDbContext Context;

        public ExpenseTypeController(ApplicationDbContext context)
        {
            Context = context;
        }

        // GET: ExpenseTypeController
        public ActionResult Index()
        {
            List<ExpenseType> expenseTypes = Context.ExpenseTypes.ToList();
            return View(expenseTypes);
        }

        // GET: ExpenseTypeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ExpenseTypeController/Create
        public ActionResult Add()
        {
            return View();
        }

        // POST: ExpenseTypeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(ExpenseTypeVm expenseType)
        {
            if(ModelState.IsValid)
            {
                var data = new ExpenseType
                {
                    Name= expenseType.Name
                };
                Context.ExpenseTypes.Add(data);
                Context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }

        // GET: ExpenseTypeController/Edit/5
        public ActionResult Edit(long id)
        {
            var data = Context.ExpenseTypes.Find(id);
            return View(data);
        }

        // POST: ExpenseTypeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ExpenseType expenseType)
        {
            if(ModelState.IsValid)
            {
                var data = Context.ExpenseTypes.Find(expenseType.Id);
                data.Name = expenseType.Name;
                Context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }

        // GET: ExpenseTypeController/Delete/5
        public ActionResult Delete(long id)
        {
            var expensesType = Context.ExpenseTypes.Find(id);
            Context.Entry(expensesType).State = EntityState.Deleted;
            Context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // POST: ExpenseTypeController/Delete/5
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
