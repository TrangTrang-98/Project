using ApplicationCore.Entities.DoctorAggregate;
using System.Collections.Generic;
using System.Linq;
using ApplicationCore.DTO;
namespace ApplicationCore.Interfaces
{
    public interface IDoctorRepository : IRepository<Doctor>
    {
         IEnumerable<string> GetNames();
         Doctor[] getIdsByDept(string dept);
         IEnumerable<string> AllDoctorId();
        //IQueryable<Doctor> GetAllDoctors();
    }
}