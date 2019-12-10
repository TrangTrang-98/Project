using System;
using System.Collections.Generic;
using ApplicationCore.Interfaces;
using ApplicationCore;


namespace ApplicationCore.Entities.PatientAggregate
{
    public class MedicalRecord : Person, IAggregateRoot
    {
    
        public MedicalRecord() : base(){}
        public string MedicalRecordId{get;set;}
        public string Diagnostic{get;set;}

        public string AttendingDoctorName{get;set;}

        public string Email{get; set;}
       
        
       public MedicalRecord(string medicalrecordid,string id, string name, DateTime birthDay, Gender gender, string phone, Address address,
                Account account, string email, string diagnostic, string attendingdoctorname) : base(id, name, birthDay, gender, phone, address, account)
        {
            this.MedicalRecordId = medicalrecordid;
            this.Diagnostic = diagnostic;
            this.AttendingDoctorName = attendingdoctorname;

        }

    }

}