using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Assignment2.Context;

namespace Assignment2.Models.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private CovidDBContext db = null;
        public AppointmentRepository()
        {
            this.db = new CovidDBContext();
        }

        public AppointmentRepository(CovidDBContext db)
        {
            this.db = db;
        }
        public IEnumerable<Appointment> SelectAll()
        {
            return db.Appointments.OrderBy(a => a.AppointmentDate).ThenBy(a => a.AppointmentTime).ToList();
        }

        public IEnumerable<Appointment> SelectAllByCentre(int id)
        {
            return db.Appointments.Where(a => a.TestCentreID == id).OrderBy(a => a.AppointmentDate).ThenBy(a => a.AppointmentTime).ToList();
        }

        public Appointment SelectById(int id)
        {
            return db.Appointments.Find(id);
        }

        public void Insert(Appointment obj)
        { 
            db.Appointments.Add(obj);
        }

        public void Update(Appointment obj)
        {
            db.Entry(obj).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            db.Appointments.Remove(db.Appointments.Find(id) ?? throw new InvalidOperationException());
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}