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
        public string SupplierName { get; set; }
        public int Phone { get; set; }
        public string SuppAddress { get; set; }
        public string SuppCity { get; set; }
        public int SuppZipcode { get; set; }

        [DataType(DataType.EmailAddress)]
        public string SuppEmail { get; set; }
        public DateTimeOffset CreateSupp { get; set; }
    }
}
