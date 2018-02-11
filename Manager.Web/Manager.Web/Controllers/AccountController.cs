using Manager.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Manager.Web.Controllers
{
    public class AccountController : Controller
    {
        static List<Account> list = new List<Account>()
        {
           new Account(){AccountId = 1, FirstName ="Name",LastName = "Name 2", Address = "Av san sandres" },
           new Account(){AccountId = 2, FirstName ="Name",LastName = "Name 2", Address = "Av san sandres" },
           new Account(){AccountId = 3, FirstName ="Name",LastName = "Name 2", Address = "Av san sandres" },
           new Account(){AccountId = 4, FirstName ="Name",LastName = "Name 2", Address = "Av san sandres" }
        };
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ListarBandeja()
        {
            int index = 1;
            var jsonData = new
            {
                total = 1,
                page = 1,
                records = list.Count,
                rows = from f in list.AsEnumerable()
                       select new
                       {
                           id = index++,
                           cell = new
                           {
                               f.AccountId,
                               f.FirstName,
                               f.LastName,
                               f.Address,

                           }
                       }
            };

            return Json(jsonData);
        }

        // GET: Account/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Account/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Account/Create
        [HttpPost]
        public ActionResult Create(Account collection)
        {
            try
            {
                list.Add(collection);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Account/Edit/5
        public ActionResult Edit(int id)
        {
            Account count = new Account();
            count = list.Where(x => x.AccountId == id).FirstOrDefault();
            return View(count);
        }

        // POST: Account/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Account/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Account/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
