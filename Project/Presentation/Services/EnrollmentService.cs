using ApplicationCore.Interfaces;
using System.Collections.Generic;
using ApplicationCore.Entities.DoctorAggregate;
using ApplicationCore.DTO;
using AutoMapper.QueryableExtensions;
using AutoMapper;
using ApplicationCore.Specifications;
using System.Linq;
using ApplicationCore.Entities;
using Presentation.ViewModel;
using ApplicationCore.Entities.PatientAggregate;
namespace Presentation.Services
{
    public class EnrollmentService: IEnrollmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private int pageSize = 7;
        public EnrollmentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
         public EnrollmentPageVM GetEnrollmentPageViewModel(int pageIndex = 1)
        {
       
            var rs = _unitOfWork.Enrollments.GetAll();
            var enrollments = _mapper.Map<IEnumerable<Enrollment>, IEnumerable<EnrollmentsDTO>>(rs);
            return new EnrollmentPageVM
            {
                ListEnrollment = PaginatedList<EnrollmentsDTO>.Create(enrollments, pageIndex, pageSize)
            };
        }

        public Patient GetPatient(string id)
        {
            return _unitOfWork.Patients.GetBy(id);
        }
       
         public IEnumerable<string> AllPatientId()
         {
             return _unitOfWork.Patients.AllPatientId();
         }

        public IEnumerable<string> AllDoctorId()
        {
            return _unitOfWork.Doctors.AllDoctorId();
        }

         public void CreateEnrollment(Enrollment enrollment)
         {
             _unitOfWork.Enrollments.Add(enrollment);
             _unitOfWork.Complete();
         }

        public void DeleteEnrollment(string id)
         {
              var enrollment = _unitOfWork.Enrollments.GetBy(id);

            if (enrollment == null) return;

            _unitOfWork.Enrollments.Remove(enrollment);

            _unitOfWork.Complete();
         }

         public void UpdateEnrollment(Enrollment enrollment)
         {
            _unitOfWork.Enrollments.Update(enrollment);
             _unitOfWork.Complete();
         }
        //  public Enrollment GetEnrollment(string IDPatient, string IDDoctor)
        // {
        //     return _unitOfWork.Enrollments.GetIdEnroll(IDPatient, IDDoctor);
        // }

         public Enrollment GetEnrollmentIDPatient(string IDPatient)
        {
            return _unitOfWork.Enrollments.GetIdEnrollIdPatient(IDPatient);
        }
        public Enrollment GetEnrollment(string IDPatient)
        {
            return _unitOfWork.Enrollments.GetIdEnroll(IDPatient);
        }
        
    }
}