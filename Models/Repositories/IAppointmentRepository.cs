using System.Collections.Generic;
using Assignment2.Context;

namespace Assignment2.Models.Repositories
{
    public interface IAppointmentRepository
    {
        IEnumerable<Appointment> SelectAll();
        IEnumerable<Appointment> SelectAllByCentre(int id);
        Appointment SelectById(int id);
        void Insert(Appointment obj);
        void Update(Appointment obj);
        void Delete(int id);
        void Save();

    }
}
