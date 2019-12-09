using ApplicationCore.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using ApplicationCore.DTO;
using Presentation;
namespace Presentation.ViewModel
{
    public class EnrollmentPageVM
    {
        //public SelectList Names { get; set; }
        public PaginatedList<EnrollmentsDTO> ListEnrollment { get; internal set; }
    }
}