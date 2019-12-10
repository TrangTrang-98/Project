using ApplicationCore.Interfaces;
namespace ApplicationCore.Entities
{
    public class RegisterAccount : IAggregateRoot

    {
        
        public string UserName { get; set; }
    
        public string Password { get; set; }
        
    
        public string ConfirmPassword { get; set; }

        
    }

    
}