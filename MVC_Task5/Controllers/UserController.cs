using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_Task5.Context;
using MVC_Task5.Models;
using MVC_Task5.Models.View_Model;

namespace MVC_Task5.Controllers
    {
    public class UserController : Controller
        {
        private readonly CollageConText _context;
        public UserController()
            {
            _context = new CollageConText();
            }
        public IActionResult GetAll()

            {
            var user = _context.Users.ToList();
            return View(user);
            }
        public IActionResult Search()
            {
            var search = _context.Users.Where(u => u.Name.Contains(u.Name)).ToList();
           
            return RedirectToAction(nameof(Detailes));
            }
        public IActionResult Detailes(int id)

            {

            var user = _context.Users.Include(u => u.courses).FirstOrDefault(e => e.id == id) ?? new();
           
            return View(user);
            }
        private void GetcourseListItems()
            {
            var courseListItem = _context.courses
                .Select(d => new SelectListItem(d.Name, d.Id.ToString()));

            ViewBag.courses= courseListItem;
            }

        [HttpGet]
        public IActionResult Add()
            {

            GetcourseListItems();
            return View();

            }
        [HttpPost]
        public IActionResult Add(UserVald user)
            {
        
            if (!ModelState.IsValid)
                {
                GetcourseListItems();

                return View();
                }

            User adduser = new User()
                {
                Name = user.Name,
                   Age = user.Age,
                 email = user.email,
                  coursesId = user.coursesId,
                  Password=user.Password,
                ConfirmPassword = user.ConfirmPassword,
                };
            GetcourseListItems();
            _context.Users.Add(adduser);
            _context.SaveChanges();
            return RedirectToAction(nameof(GetAll));
            }
        public IActionResult Delete(int id)
            {
          
            var delet_user = _context.Users.FirstOrDefault(u => u.id == id) ?? new();
            _context.Users.Remove(delet_user);
            GetcourseListItems();
            _context.SaveChanges();

            return RedirectToAction(nameof(GetAll));

            }
        [HttpGet]
        public IActionResult Edit(int id)
            {
            var useredit = _context.Users.SingleOrDefault(c => c.id == id);
            GetcourseListItems();
            return View(useredit);
            }
        [HttpPost]
        public IActionResult Edit(User user)
            {
            //if (!ModelState.IsValid)
            //    {
            //    GetcourseListItems();

            //    return View();
            //    }
            var editUser = _context.Users.Find(user.id);

           editUser.Name = user.Name;
            editUser.Age = user.Age;
            editUser.email = user.email;
            editUser.coursesId = user.coursesId;
            editUser.Password = user.Password;
            editUser.ConfirmPassword = user.ConfirmPassword;
            GetcourseListItems();

            _context.SaveChanges();

            return RedirectToAction(nameof(GetAll));

            }
        //public ActionResult Index(string searchName)
        //    {

        //    var user = from User in _context.Users select User;

        //    if (!String.IsNullOrEmpty(searchName))
        //        {
        //        user = user.Where(c => c.Name.Contains(searchName));
        //        }

        //    return View(user);
      //  }
       
        }
    }
