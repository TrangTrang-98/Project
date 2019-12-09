using AutoMapper;
using ApplicationCore.Entities.PatientAggregate;
using ApplicationCore.Entities.DoctorAggregate;
using ApplicationCore.DTO;
using ApplicationCore.Entities;
namespace ApplicationCore.Mapping
{
    // using mapping to tranform data from Patient to PatientDTO 
    public class MappingProfile : Profile
    {
     public MappingProfile()
     {
            CreateMap<Patient, PatientsDTO>();
            CreateMap<Doctor, DoctorsDTO>();
            CreateMap<Department, DepartmentsDTO>();
            CreateMap<Enrollment, EnrollmentsDTO>();


     }   
    }
}