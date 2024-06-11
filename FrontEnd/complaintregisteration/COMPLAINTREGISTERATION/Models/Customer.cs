using System.ComponentModel.DataAnnotations;

namespace COMPLAINTREGISTERATION.Models
{
    public class Customer
    {
        

        [Key]
        public int Customerid { get; set; }
        public string Name { get; set; }

       
        public string Mobile { get; set; }
        

        public string Email { get; set; }


   
        public string AccountNumber { get; set; }

      
        public string Password { get; set; }


    }
}
