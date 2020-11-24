using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestFriend.Models.SupplierModel
{
    public class SupplierListItem
    {
        public int SupplierId { get; set; }
        public Guid SupplierGuid { get; set; }

        [Display(Name = "Name of Supplier")]
        public char SupplierName { get; set; }
        public int Phone { get; set; }
        public char SuppAddress { get; set; }
        public char SuppCity { get; set; }
        public char SuppZipcode { get; set; }

        [DataType(DataType.EmailAddress)]
        public char SuppEmail { get; set; }
        public DateTimeOffset CreateSupp { get; set; }
    }
}
