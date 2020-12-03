using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestFriend.Data
{
    public enum Class {[Display(Name = "Customer")] Customer = 1, [Display(Name = "Admin")] Admin }
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        [Required]
        public virtual ICollection<Order> Orders { get; set; }
        public string  UserName { get; set; }
        [Required]
        public string  Email { get; set; }
        [Required]
        public string  Password { get; set; }
        public Class Class { get; set; }
        [Required]
        public string FullName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int ZipCode { get; set; }
        public DateTimeOffset CreateCustomer { get; set; }
        public DateTimeOffset ModifyCustomer { get; set; }
        
    }
}
