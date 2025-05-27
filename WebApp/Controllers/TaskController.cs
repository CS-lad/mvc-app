using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using System.Collections.Generic;

namespace WebApp.Controllers 
{
    public class TaskController : Controller
    {
        static List<TaskItem> tasks = new List<TaskItem>();

        public IActionResult Index()
        {
            return View(tasks);
        }

        public IActionResult Add(string description)
        {
            tasks.Add(new TaskItem { Id = tasks.Count + 1, Description = description });
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            tasks.RemoveAll(t => t.Id == id);
            return RedirectToAction("Index");
        }
    }
}