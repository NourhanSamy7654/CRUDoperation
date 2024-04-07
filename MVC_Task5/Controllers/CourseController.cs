using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_Task5.Context;
using MVC_Task5.Models;

namespace MVC_Task5.Controllers
    {
    public class CourseController : Controller
        {
        private readonly CollageConText _context;
        public CourseController()
            {
            _context = new CollageConText ();
            }
        public IActionResult GetAll()
            {
            var courses = _context.courses.ToList();  //>

            return View(courses);
         
            }
        public IActionResult Details(int id)
            {
            var det_cours = _context.courses.SingleOrDefault(c => c.Id == id);
            return View(det_cours);
            }
        public IActionResult Delete(int id)
            {
            var delete_cours = _context.courses.SingleOrDefault(c => c.Id == id) ??new();
            if (delete_cours is not null)
                _context.courses.Remove(delete_cours);
            _context.SaveChanges();
            return RedirectToAction(nameof(GetAll));
            }
        [HttpGet]
        public IActionResult AddCourse()
            {
            return View();
            }
        [HttpPost]
        public IActionResult AddCourse(Courses cour)
            {
            //if (!ModelState.IsValid)
            //    {
        
            //    return View();
            //    }
            _context.courses.Add(cour);
            _context.SaveChanges();

            return RedirectToAction(nameof(GetAll));
            }
        [HttpGet]
        public IActionResult Edit(int id)
            {
            var courseupdate = _context.courses.Single(c=> c.Id == id);
            return View(courseupdate);
            }
        [HttpPost]
        public IActionResult Edit(Courses cour) {

            var courseupdate = _context.courses.Single(c=> c.Id == cour.Id);
            courseupdate.Name = cour.Name;
            courseupdate.Description = cour.Description;

            _context.SaveChanges();

            return RedirectToAction(nameof(GetAll));
            }

       
        }
    }
