using System;
using System.Collections.Generic;
using ApplicationCore.Interfaces;
using ApplicationCore;
namespace ApplicationCore.Entities.PatientAggregate
{
    public class Patient : Person, IAggregateRoot
    {
        public Patient() : base(){}
        
        public MedicalRecord MedicalRecord{get; set;}
        public string Email{get; set;}
       
        
       public Patient(string id, string name, DateTime birthDay, Gender gender, string phone, Address address,
                Account account, MedicalRecord medicalRecord) : base(id, name, birthDay, gender, phone, address, account)
        {
            this.MedicalRecord = medicalRecord;

        }

    }

}