using Microsoft.AspNetCore.Mvc;
using ToDoList.Data;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class TasksController : Controller
    {
        private readonly ApplicationDbContext _db;

        public TasksController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Tasks> objCategoryList = _db.tasks;
            return View(objCategoryList);
        }

        //GET
        public IActionResult Create()
        {
            
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Tasks obj)
        {
            _db.tasks.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int? id)
        {

            var obj = _db.tasks.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.tasks.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");

        }

        //Get
        public IActionResult View(int? id)
        {
            var obj = _db.tasks.Find(id);
            if(obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        public IActionResult Completed(int? id)
        {
            var obj = _db.tasks.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            obj.Completed = true;
            _db.tasks.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
 