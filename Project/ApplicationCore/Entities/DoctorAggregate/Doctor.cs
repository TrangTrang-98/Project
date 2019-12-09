using System;
using ApplicationCore.Interfaces;
using System.Collections.Generic;
using ApplicationCore.Entities;
using ApplicationCore;
namespace ApplicationCore.Entities.DoctorAggregate
{
    
    public class Doctor : Person, IAggregateRoot
    {
        // public string DoctorId{get; set;}

        // public string DoctorName{get; set;}

        // public Gender Gender{get; set;}
        // public string Phone{get; set;}

        //public string DeptName{get; set;}

       
        public string  DeptId{get ; set;}
    

        // private List<DocAppointment> _appointment = new List<DocAppointment>();
        // IEnumerable<DocAppointment> appointment => _appointment.AsReadOnly();

        public Doctor() : base() {}
        public Doctor(string id, string name, DateTime birthDay, Gender gender, string phone, string deptId)
            : base(id, name, birthDay, gender, phone)
        {
            this.DeptId = deptId;
        }
    }
}