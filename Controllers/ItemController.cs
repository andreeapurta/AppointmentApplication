using AppointmentApplication.Data;
using AppointmentApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AppointmentApplication.Controllers
{
    public class ItemController : Controller
    {
        public ApplicationDbContext _db;
        public ItemController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            //get items from DB
            IEnumerable<Item> objectList = _db.Items;
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
        public IActionResult Create(Item obj)
        {
            //get items from DB
            _db.Items.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}