using System;
using BestFriend.Data;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestFriend.Models.CustomerModel
{
    public class CustomerDetail
    {
        public int CustomerId { get; set; }
        public string UserName { get; set; }
      [Required]
        public string Email { get; set; }
      [Required]
        public string FullName { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
       
    }
}

