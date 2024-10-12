using Microsoft.AspNetCore.Mvc;
using NewToDoListApp.Data;
using NewToDoListApp.Models;
using System.Linq;

namespace NewToDoListApp.Controllers
{
    public class TaskController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TaskController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var tasks = _context.ToDoTasks.ToList();
            return View(tasks);
        }

        [HttpPost]
        public IActionResult Create(ToDoTask task)
        {
            if (ModelState.IsValid)
            {
                _context.ToDoTasks.Add(task);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            var tasks = _context.ToDoTasks.ToList();
            return View("Index", tasks);
        }

        // متدهای دیگر برای ویرایش و حذف (اختیاری)
    }
}
