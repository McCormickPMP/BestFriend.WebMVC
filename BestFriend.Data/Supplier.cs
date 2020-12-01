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
        public Guid SupplierGuid { get; set; }
        [Required]
        public string SupplierName { get; set; }
        public int Phone { get; set; }
        public string SuppAddress { get; set; }
        public string SuppCity { get; set; }
        public int SuppZipcode { get; set; }
        [Required]
        public string SuppEmail { get; set; }
        public DateTimeOffset CreateSupp { get; set; }
        public DateTimeOffset ModifySupp { get; set; }
    }
}
