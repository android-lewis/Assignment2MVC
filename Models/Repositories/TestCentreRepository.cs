using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Assignment2.Context;

namespace Assignment2.Models.Repositories
{
    public class TestCentreRepository : ITestCentreRepository
    {
        private CovidDBContext db = null;

        public TestCentreRepository()
        {
            this.db = new CovidDBContext();
        }

        public TestCentreRepository(CovidDBContext db)
        {
            this.db = db;
        }
        public IEnumerable<TestCentre> SelectAll()
        {
            return db.TestCentres.OrderBy(a => a.CentreName).ToList();
        }

        public TestCentre SelectById(int id)
        {
            return db.TestCentres.Find(id);
        }

        public void Insert(TestCentre obj)
        {
            db.TestCentres.Add(obj);
        }

        public void Update(TestCentre obj)
        {
            db.Entry(obj).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            db.TestCentres.Remove(db.TestCentres.Find(id) ?? throw new InvalidOperationException());
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}