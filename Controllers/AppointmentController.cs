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
    public class AppointmentController : Controller
    {
        private IAppointmentRepository repository = null;
        private ITestCentreRepository centreRepository = null;
        public AppointmentController()
        {
            this.repository = new AppointmentRepository();
            this.centreRepository = new TestCentreRepository();
        }

        public AppointmentController(IAppointmentRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public ActionResult Index()
        {
            List<Appointment> model = (List<Appointment>)repository.SelectAll();
            return View(model);
        }

        public ActionResult ByCentre(int id)
        {
            List<Appointment> model = (List<Appointment>)repository.SelectAllByCentre(id);
            return View(model);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            Appointment existing = repository.SelectById(id);
            return View(existing);
        }

        [HttpGet]
        public ActionResult Create()
        {

            Appointment model = new Appointment
            {

                TestCentres = centreRepository.SelectAll().ToList().Select(c => new SelectListItem
                {
                    Value = c.TestCentreID.ToString(),
                    Text = c.CentreName,
                })

            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(Appointment obj)
        {

            if (ModelState.IsValid)
            { // check valid state

                repository.Insert(obj);
                repository.Save();
                return RedirectToAction("Index");
            }
            else // not valid so redisplay
            {
                obj.TestCentres = centreRepository.SelectAll().ToList().Select(c => new SelectListItem
                {
                    Value = c.TestCentreID.ToString(),
                    Text = c.CentreName,
                });
                return View(obj);
            }
        }

        [HttpGet, ActionName("Edit")]
        public ActionResult ConfirmEdit(int id)
        {
            Appointment existing = repository.SelectById(id);
            existing.TestCentres = centreRepository.SelectAll().ToList().Select(c => new SelectListItem
            {
                Value = c.TestCentreID.ToString(),
                Text = c.CentreName,
            });
            return View(existing);
        }

        [HttpPost]
        public ActionResult Edit(Appointment obj)
        {
;

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
            Appointment existing = repository.SelectById(id);
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