using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebData.Models;

namespace WebData.Controllers
{

    [Authorize]
    public class studentController : Controller
    {
        private readonly studentDbContext context;
        public studentController(studentDbContext context)
        {
            this.context = context;

        }
       
        public IActionResult Index()
        {
            var result = context.student.ToList();
            return View(result);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(student model)
        {
            if (ModelState.IsValid)
            {
                var emp = new student()
                {
                    firstname=model.firstname,
                    Id=model.Id,
                    lastname=model.lastname,
                    Email=model.Email,
                    Mobile=model.Mobile,
                    city=model.city,
                };
                context.student.Add(emp);
                context.SaveChanges();
                TempData["errorMessage"] = "Record saved";
                return RedirectToAction("Index");

            }
            else
            {
                TempData["errorMessage"] = "Empty field can not submit";
                return View(model);
            }
                   
              
        }

        public IActionResult Delete(int id)
        {
            var emp = context.student.SingleOrDefault(e => e.Id == id);
            context.student.Remove(emp);
            context.SaveChanges();
            TempData["errorMessage"] = "Record deleted";
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var emp = context.student.SingleOrDefault(e => e.Id == id);
            var result = new student()
            {
                Id=emp.Id,
                firstname = emp.firstname,
                lastname = emp.lastname,
                Email = emp.Email,
                Mobile = emp.Mobile,
                city = emp.city,

            };
            return View(result);
        }
        [HttpPost]
        public IActionResult Edit(student model)
        {
            var emp = new student()
            {
                Id=model.Id,
                firstname = model.firstname,
                lastname = model.lastname,
                Email = model.Email,
                Mobile = model.Mobile,
                city = model.city,

            };
            context.student.Update(emp);
            context.SaveChanges();
            TempData["errorMessage"] = "Record Updated";
            return RedirectToAction("Index");
        }
    }

}
