using ApplicationCore.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using ApplicationCore.DTO;
using Presentation;
namespace Presentation.ViewModel
{
    public class DoctorPageVM
    {
        public SelectList Names { get; set; }
        public PaginatedList<DoctorsDTO> ListDoctor { get; internal set; }
    }
}