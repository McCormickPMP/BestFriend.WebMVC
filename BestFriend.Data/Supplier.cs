using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestFriend.Data
{
    public class Supplier
    {
        [Key]
        public int SupplierId { get; set; }
        [Required]
        public char SupplierName { get; set; }
        public int Phone { get; set; }
        public char SuppAddress { get; set; }
        public char SuppCity { get; set; }
        public char SuppZipcode { get; set; }
        [Required]
        public char SuppEmail { get; set; }
        public DateTimeOffset CreateSupp { get; set; }
        public DateTimeOffset ModifySupp { get; set; }
    }
}
