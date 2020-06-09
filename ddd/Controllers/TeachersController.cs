using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ddd.DataContext;
using ddd.Models;
using ddd.ViewModels;

namespace ddd.Controllers
{
    public class TeachersController : Controller
    {
        private ApplicationDataContext db = new ApplicationDataContext();

        // GET: Teachers
        // GET: Teachers
        public ActionResult Index()
        {
            var model = new IndexViewModel
            {
                Teachers = db.Teachers.ToList(),
                Subjects = db.Subjects.ToList(),
                CreateTeacherViewModel = new CreateTeacherViewModel()
                {
                    Subjects = db.Subjects.ToList()
                }
            };

            return View(model);
        }
        // GET: Teachers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teacher teacher = db.Teachers.Find(id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            return View(teacher);
        }

        // GET: Teachers/Create
        public ActionResult Create()
        {
            ViewBag.Subjects = db.Subjects.ToList();
            return View();
        }

        // POST: Teachers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateTeacherViewModel createTeacherViewModel)
        {
            if (ModelState.IsValid)
            {
                Subject subject = db.Subjects.Find(createTeacherViewModel.SubjectId);
                Teacher teacher = new Teacher()
                {
                    Name = createTeacherViewModel.Name,
                    Subject = subject
                };

                db.Teachers.Add(teacher);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(createTeacherViewModel);
        }

        // GET: Teachers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teacher teacher = db.Teachers.Find(id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            var model = new CreateTeacherViewModel();
            ViewBag.Subjects = db.Subjects.ToList();
            return View(model);
        }

        // POST: Teachers/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CreateTeacherViewModel teacherViewModel)
        {
            if (ModelState.IsValid)
            {
                var subject = db.Subjects.Find(teacherViewModel.SubjectId);
                var teacher = db.Teachers.FirstOrDefault(x => x.Id == teacherViewModel.Id);
                teacher.Name = teacherViewModel.Name; teacher.Subject = subject;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(teacherViewModel);
        }

        //GET: Teachers/Delete/5
        [ActionName("Delete")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teacher teacher = db.Teachers.Find(id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            db.Teachers.Remove(teacher);
            db.SaveChanges();
            //return View(teacher);
            return RedirectToAction("Index");
        }

        //// POST: Teachers/Delete/5
        //[HttpPost, ActionName("Delete")]
        ////[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    var teacher = db.Teachers.Find(id);
        //    db.Teachers.Remove(teacher);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}


