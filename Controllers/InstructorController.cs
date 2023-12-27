using Labs_3.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Labs_3.Controllers
{
    public class InstructorController : Controller
    {
        Company Context = new Company();
        // GET: Instructor
        public ActionResult Index()
        {
            return View(Context.Instructors.ToList());
        }

        // Delete Instructor
        public ActionResult Delete(int id)
        {
            var found = Context.Instructors.Where(i => i.Ins_Id == id).FirstOrDefault();
            Context.Instructors.Remove(found);
            Context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            ViewData["Departments"] =  Context.Departments.ToList();
            return View(new Instructor());
        }

        [HttpPost]
        public ActionResult Create(Instructor instructor)
        {
            if (ModelState.IsValid)
            {
                var Found = Context.Instructors.Where(I => I.Ins_Id == instructor.Ins_Id).FirstOrDefault();
                if (Found == null )
                {
                    Context.Instructors.Add(instructor);
                    TempData["Instructor"] = instructor;
                    Context.SaveChanges();
                    return RedirectToAction("Index");
                }
                
            }
            ViewData["Departments"] = Context.Departments.ToList();
            return View(instructor);
        }

        public ActionResult Update(int Id)
        {
            var found = Context.Instructors.Where(D => D.Ins_Id == Id).FirstOrDefault();
            if (found == null)
            {
                return RedirectToAction("Index");
            }
            ViewData["Dept_Id"] = new SelectList(Context.Departments, "Dept_Id", "Dept_Name", found.Dept_Id);
            return View(found);
        }
        [HttpPost]
        public ActionResult Update(Instructor instructor)
        {
            var found = Context.Instructors.Where(D => D.Ins_Id == instructor.Ins_Id).FirstOrDefault();
            if (ModelState.IsValid)
            {
                found.Ins_Id = instructor.Ins_Id;
                found.Ins_Name = instructor.Ins_Name;
                found.Ins_Degree = instructor.Ins_Degree;
                found.Dept_Id = instructor.Dept_Id;
                found.Salary = instructor.Salary;
                Context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["Dept_Id"] = new SelectList(Context.Departments, "Dept_Id", "Dept_Name", found.Dept_Id);
            return View(found);
        }
    }
}