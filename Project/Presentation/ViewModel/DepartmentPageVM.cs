using ApplicationCore.Entities;
using ApplicationCore.DTO;
namespace Presentation.ViewModel
{
    public class DepartmentPageVM
    {
        
        public PaginatedList<DepartmentsDTO> ListDept { get; internal set; }
    }
}