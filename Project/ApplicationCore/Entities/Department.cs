using ApplicationCore.Interfaces;
using ApplicationCore.Entities.DoctorAggregate;
using System.Collections.Generic;

namespace ApplicationCore.Entities
{
    public class Department : IAggregateRoot
    {
        public string DeptId{get; set; }

        public string DeptName{get; set;}

        //public ICollection<Doctor> DoctorH{get; set;}

        // doctor head
        public Doctor Doctor{get; set;} //a dept has only a doctor head
        public string DoctorId{get; set;}
        public string DoctorHead{get; set;}

        public ICollection<Doctor> Doctors{get; set;} // a dept has many doctors
        

        // public Department(string id, string name, Doctor doctor)
        // {
        //     this.DeptId = id;
        //     this.DeptName = name;
        //     this.Doctor = doctor;
        // }
        public Department(){}
    }
}