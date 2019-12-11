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

        Department GetdeptByName(string deptName);
        DepartmentPageVM GetDepartmentPageViewModel(int pageIndex);
        void CreateDepartment(Department Department); // tao them khoa moi
        void UpdateDepartment(Department Department);
        void DeleteDepartment(string id);
    }
}