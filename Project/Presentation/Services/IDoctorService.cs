using ApplicationCore.Entities.DoctorAggregate;
using System.Collections.Generic;
using ApplicationCore.DTO;
using System.Linq;
using Presentation.ViewModel;
namespace Presentation.Services
{
    public interface IDoctorService
    {
        Doctor GetDoctor(string id);
        IEnumerable<DoctorsDTO> GetDoctors(int pageIndex, int pageSize, out int count);
        IEnumerable<string> GetNames();// ds ten bac si(de loc)
        IEnumerable<string> GetAllDept();
       //  IQueryable<Doctor> GetAllDoctors();
       IEnumerable<string> AllDoctorId();
        
        Doctor getRandDoctorID(string dept);

        DoctorPageVM GetDoctorPageViewModel(string SearchString, int pageIndex);
        void CreateDoctor(Doctor Doctor); // them moi bac si
        void UpdateDoctor(Doctor Doctor);
        void DeleteDoctor(string id);
    }
}