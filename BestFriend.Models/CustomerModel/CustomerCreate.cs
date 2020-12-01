using System;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestFriend.Models.CustomerModel
{
    public class CustomerCreate
    {
      
        public int CustomerID { get; set; }

        [Display(Name = "User Name")]
        public string UserName { get; set; }
       
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        
        
        [DataType(DataType.Password)]
        public string Password { get; set; }
       
       [Display(Name ="Enter Full Name")]
        public string FullName { get; set; }
  
        [Display(Name = "Zipcode")]
        public int ZipCode { get; set; }
       
    }
}

