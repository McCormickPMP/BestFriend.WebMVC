using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestFriend.Models.CustomerModel
{
    public class CustomerUpdate
    {
        public int CustomerID { get; set; }
       
      
        public char UserName { get; set; }
      
        public char Email { get; set; }
    
        public char Password { get; set; }
       
        public char FullName { get; set; }
        public char Address { get; set; }
        public char City { get; set; }
        public char ZipCode { get; set; }
        public DateTimeOffset CreateCustomer { get; set; }
        public DateTimeOffset ModifyCustomer { get; set; }
    }
}
