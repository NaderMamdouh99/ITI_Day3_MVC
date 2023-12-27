using Labs_3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Labs_3.Controllers
{
    public class DepartmentController : Controller
    {
        Company Context1 = new Company();
        // GET: Department
        public ActionResult Index()
        {

            return View(Context1.Departments.ToList());
        }
        // Delete Department
        public ActionResult Delete(int id)
        {
            var found1 = Context1.Departments.Where(i => i.Dept_Id == id).FirstOrDefault();
            var found2 = Context1.Instructors.Where(i => i.Dept_Id == id).ToList();
            Context1.Departments.Remove(found1);
            Context1.Instructors.RemoveRange(found2);
            Context1.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            ViewData["Instructor"] = Context1.Instructors.ToList();
            return View(new Department());
        }

        [HttpPost]
        public ActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                var Found = Context1.Departments.Where(I => I.Dept_Id == department.Dept_Id).FirstOrDefault();
                if (Found == null)
                {
                    Context1.Departments.Add(department);
                    TempData["department"] = department;
                    Context1.SaveChanges();
                    return RedirectToAction("Index");
                }

            }
            ViewData["Instructor"] = Context1.Instructors.ToList();
            return View(department);
        }

        public ActionResult Update(int Id)
        {
            var found = Context1.Departments.Where(D=>D.Dept_Id == Id).FirstOrDefault();
            if (found == null )
            {
                return RedirectToAction("Index");
            }
            ViewData["Dept_Manager"] = new SelectList(Context1.Instructors,"Ins_Id", "Ins_Name",found.Dept_Manager);
            return View(found);
        }
        [HttpPost]
        public ActionResult Update(Department department)
        {
            var found = Context1.Departments.Where(D => D.Dept_Id == department.Dept_Id).FirstOrDefault();
            if (ModelState.IsValid)
            {
                found.Dept_Id = department.Dept_Id;
                found.Dept_Name = department.Dept_Name;
                found.Dept_Desc = department.Dept_Desc;
                found.Dept_Location = department.Dept_Location;
                found.Dept_Manager = department.Dept_Manager;
                found.Hiredate = department.Hiredate;
                Context1.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["Dept_Manager"] = new SelectList(Context1.Instructors, "Ins_Id", "Ins_Name", found.Dept_Manager);
            return View(found);
        }
    }
}