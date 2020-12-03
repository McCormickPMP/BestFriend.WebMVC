using BestFriend.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestFriend.Models.CustomerModel
{
    public class CustomerList
    {
        public int CustomerId { get; set; }
        [Required]
        public string UserName { get; set; }

        public string Email { get; set; }

        public string FullName { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
