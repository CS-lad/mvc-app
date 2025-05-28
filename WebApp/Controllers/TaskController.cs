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

    }
}