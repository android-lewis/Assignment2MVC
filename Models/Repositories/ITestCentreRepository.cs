using System.Collections.Generic;
using Assignment2.Context;

namespace Assignment2.Models.Repositories
{
    public interface ITestCentreRepository
    {
        IEnumerable<TestCentre> SelectAll();
        TestCentre SelectById(int id);
        void Insert(TestCentre obj);
        void Update(TestCentre obj);
        void Delete(int id);
        void Save();
    }
}
