using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CRUD;
using CRUD.Models;
using System.IO;


namespace CRUD.Controllers
{
    public class EmployeeController : Controller
    {

        EmployeeDataEntities entities = new EmployeeDataEntities();
        
        // View
        public ActionResult Index()
        {
            return View(entities.Employees.ToList());
            
        }


        // Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeID,EmployeeName,Email,Country,Age,Resume")] Employee employee, HttpPostedFileBase file)
        {

            if (ModelState.IsValid)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Files"), fileName);
                file.SaveAs(path);
                employee.Resume = path;
                entities.Employees.Add(employee);
                entities.SaveChanges();
                return RedirectToAction("Index");
            }            

            return View(employee);
        }

        public FileResult DownloadFile(string resume)
        {
            return File(resume, "application/pdf", "File Result.pdf");
        }

        // Edit 
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = entities.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeId, EmployeeName, Email, Country, Age")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                entities.Entry(employee).State = EntityState.Modified;
                entities.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // Details
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = entities.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // Delete    
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = entities.Employees.Find(id);

            if (employee == null)
            {
                return HttpNotFound();
            }            
            entities.Employees.Remove(employee);
            entities.SaveChanges();
            return RedirectToAction("Index");
            
        }        


        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirm(int? id)
        //{
        //        Employee employee = entities.Employees.Find(id);
        //        entities.Employees.Remove(employee);
        //        entities.SaveChanges();
        //        return RedirectToAction("Index");            
        //}

        public ActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file)
        {
            Employee employee = new Employee();
            if (file != null && file.ContentLength > 0)
            {
                // Save the file to a physical location on the server.
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/App_Data/uploads"), fileName);
                file.SaveAs(path);

                // Get the file path and save it to the database.
                var fileModel = new FileModel { FileName = fileName, FilePath = path };
                entities.Employees.Add(employee);
                entities.SaveChanges();

                return RedirectToAction("Index");
            }

            return View();
        }        
    }
    internal class FileModel
    {
        public string FileName { get; set; }
        public string FilePath { get; set; }
    }
}