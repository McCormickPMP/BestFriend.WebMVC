using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestFriend.Models.WishListModel
{
    public class WishListItem
    {
        public int WishId { get; set; }
        public decimal Money { get; set; }
        public char Item { get; set; }
        public int Supplier { get; set; }
        public DateTimeOffset CreateWish { get; set; }
        public DateTimeOffset ModifyWish { get; set; }
    }
}
