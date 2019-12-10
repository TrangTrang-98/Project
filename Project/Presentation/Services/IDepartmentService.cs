using ApplicationCore.Entities;
using System.Collections.Generic;
using ApplicationCore.DTO;
using ApplicationCore.Entities.DoctorAggregate;
using Presentation.ViewModel;
namespace Presentation.Services
{
    public interface IDepartmentService
    {
        Department GetDepartment(string id);
        IEnumerable<DepartmentsDTO> GetDepartments(int pageIndex, int pageSize, out int count);
        IEnumerable<string> GetNameDepartments(); // ds ten benh nhan(de loc)
        IEnumerable<string> GetDoctorNames();
        DepartmentPageVM GetDepartmentPageViewModel(int pageIndex);

        Department GetdeptByName(string deptName);
        void CreateDepartment(Department Department); // tao them khoa moi
        void UpdateDepartment(Department Department);
        void DeleteDepartment(string id);
    }
}