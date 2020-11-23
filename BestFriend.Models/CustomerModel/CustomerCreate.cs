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
      
        [Required]
        [Display(Name = "UserName")]
        public char UserName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public char Email { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        public char Password { get; set; }
       
        [Required]
        public char FullName { get; set; }
  
        [Display(Name = "Zipcode")]
        public char ZipCode { get; set; }
       
    }
}

