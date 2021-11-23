using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Assignment2.Context;
using Assignment2.Models;
using Assignment2.Models.Repositories;

namespace Assignment2.Controllers
{
    public class TestCentreController : Controller
    {
        private ITestCentreRepository repository = null;

        public TestCentreController()
        {
            this.repository = new TestCentreRepository();
        }

        public TestCentreController(ITestCentreRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public ActionResult Index()
        {
            List<TestCentre> model = (List<TestCentre>)repository.SelectAll();
            return View(model);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            TestCentre existing = repository.SelectById(id);
            return View(existing);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(TestCentre obj)
        {
            if (ModelState.IsValid)
            { // check valid state
                repository.Insert(obj);
                repository.Save();
                return RedirectToAction("Index");
            }
            else // not valid so redisplay
            {
                return View(obj);
            }
        }

        [HttpGet, ActionName("Edit")]
        public ActionResult ConfirmEdit(int id)
        {
            TestCentre existing = repository.SelectById(id);
            return View(existing);
        }

        [HttpPost]
        public ActionResult Edit(TestCentre obj)
        {
            if (ModelState.IsValid)
            { // check valid state
                repository.Update(obj);
                repository.Save();
                return RedirectToAction("Index");
            }
            else // not valid so redisplay
            {
                return View(obj);
            }
        }

        [HttpGet, ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            TestCentre existing = repository.SelectById(id);
            return View(existing);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            repository.Delete(id);
            repository.Save();
            return RedirectToAction("Index");
        }

    }
}