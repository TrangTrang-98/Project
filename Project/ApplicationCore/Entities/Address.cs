
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using ApplicationCore;
namespace ApplicationCore.Entities
{
    [Owned]
    public class Address : ValueObject// value object -- Patient,
    {
        public string NumHouse{get;  private set;}
        public string Street{get;  private set;}
        public string District{get; private  set;}
        public string City{get;  private set;}
        public string Country{get; private set;}

        public Address(){}
        public Address(string number, string street, string district, string city, string country)
        {
            NumHouse = number;
            Street = street;
            District = district;
            City = city;
            Country = country;
        }
       public Address(Address ad)
       {
           this.NumHouse = ad.NumHouse;
           this.Street = ad.Street;
           this.District = ad.District;
           this.City = ad.City;
           this.Country = ad.Country;
       }

        protected override IEnumerable<object> GetElement()
        {
            yield return NumHouse;
            yield return Street;
            yield return District;
            yield return City;
            yield return Country;
            
        }
    
    public override string ToString()
    {
        
        return NumHouse + "-" + Street + "-" + District + "-"+ City + "-" + Country;
        
    }
    }
    

}
    
