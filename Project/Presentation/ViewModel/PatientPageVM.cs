using ApplicationCore.Entities.PatientAggregate;
using ApplicationCore.DTO;
namespace Presentation.ViewModel
{
    public class PatientPageVM
    {
        
        public PaginatedList<PatientsDTO> ListPatient { get; internal set; }
    }
}