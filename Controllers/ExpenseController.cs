using AppointmentApplication.Data;
using AppointmentApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AppointmentApplication.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public ExpenseController(ApplicationDbContext db)
        {
            dbContext = db;
        }

        public IActionResult Index()
        {
            //get items from DB
            IEnumerable<Expense> objectList = dbContext.Expenses;
            return View(objectList);
        }

        public IActionResult Create()
        {
            //get items from DB
            //IEnumerable< Item > objectList = _db.Items;
            //return View(objectList);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken] //just if we are logged in
        public IActionResult Create(Expense expense)
        {
            if (ModelState.IsValid)
            {
                //get items from DB
                dbContext.Expenses.Add(expense);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(expense);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var expense = dbContext.Expenses.Find(id);
            if (expense == null)
            {
                return NotFound();
            }
            //get items from DB
            dbContext.Expenses.Remove(expense);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        //Get - delete
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //get items from DB
            var expense = dbContext.Expenses.Find(id);
            if (expense == null)
            {
                return NotFound();
            }

            return View(expense);  // return the view with out object so we can display the info we are getting
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdatePost(Expense expense)
        {
            if (ModelState.IsValid)
            {
                //get items from DB
                dbContext.Expenses.Update(expense);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(expense);
        }

        //Get - update
        public IActionResult Update(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //get items from DB
            var expense = dbContext.Expenses.Find(id);
            if (expense == null)
            {
                return NotFound();
            }

            return View(expense);  // return the view with out object so we can display the info we are getting
        }
    }
}