using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using System.Collections.Generic;
using WebApp.Data;

namespace WebApp.Controllers 
{
    public class TaskController : Controller
    {
        private readonly AppDbContext _context;

        public TaskController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var tasks = _context.Tasks.ToList();
            return View(tasks);
        }

        public IActionResult Add(string description)
        {
            var task = new TaskItem { Description = description };
            _context.Tasks.Add(task);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var task = _context.Tasks.Find(id);
            if (task != null)
            {
                _context.Tasks.Remove(task);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        //Show the edit form
        public IActionResult Edit(int id)
        {
            var task = _context.Tasks.Find(id);
            if (task == null)
            {
                return NotFound();
            }
            return View(task);
        }

        //Handle the edit form submission
        [HttpPost]
        public IActionResult Edit(TaskItem updateTask)
        {
            var task = _context.Tasks.Find(updateTask.Id);
            if (task == null)
            {
                return NotFound();
            }

            task.Description = updateTask.Description;
            _context.SaveChanges();

            return RedirectToAction("Index");
        }


    }
}