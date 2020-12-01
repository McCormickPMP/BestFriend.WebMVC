using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestFriend.Models.WishListModel
{
    public class WishCreate
    {
       
        public int WishId { get; set; }
        public Guid WishGuid { get; set; }
        public decimal Money { get; set; }
        public string Item { get; set; }
        public int Supplier { get; set; }
        public DateTimeOffset CreateWish { get; set; }
        public DateTimeOffset ModifyWish { get; set; }
    }
}
