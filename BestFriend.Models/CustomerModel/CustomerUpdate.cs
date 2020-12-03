using BestFriend.Data;
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
        public int CustomerId { get; set; }
        [Required]
        public string UserName { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int ZipCode { get; set; }
        [Required]
        public DateTimeOffset ModifyCustomer { get; set; }
    }
}
