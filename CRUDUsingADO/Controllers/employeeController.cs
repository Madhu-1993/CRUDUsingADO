using CRUDUsingADO.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace CRUDUsingADO.Controllers
{
    [UserLog]
    public class employeeController : Controller
    {
        private readonly IConfiguration _configuration;
        private employeeCRUD db;
        public employeeController(IConfiguration configuration)
        {
            _configuration = configuration;
            db=new employeeCRUD(_configuration);
        }
        // GET: employeeController
        public ActionResult Index()
        {
            var list =db.GetEmployees();
            return View(list);
        }

        // GET: employeeController/Details/5
        public ActionResult Details(int eid)
        {
            var emp = db.GetEmployeeById(eid);
            return View(emp);
        }

        // GET: employeeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: employeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(employee emp)
        {
            try
            {
                int result = db.AddEmployee(emp);
                if(result>0)
                return RedirectToAction(nameof(Index));
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: employeeController/Edit/5
        public ActionResult Edit(int eid)
        {
            var emp = db.GetEmployeeById(eid);
            return View(emp);
        }

        // POST: employeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(employee emp)
        {
            try
            {
                int result = db.EditEmployee(emp);
                if (result > 0)
                    return RedirectToAction(nameof(Index));
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: employeeController/Delete/5
        public ActionResult Delete(int eid)
        {
            var emp = db.GetEmployeeById(eid);
            return View(emp);
        }

        // POST: employeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int eid)
        {
            try
            {
                int result = db.DeleteEmployee(eid);
                if (result > 0)
                    return RedirectToAction(nameof(Index));
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }
    }
}
