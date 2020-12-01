using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestFriend.Models.StatusModel
{
    public class StatusListItem
    {
        public int StatusId { get; set; }
        public string StatusType { get; set; }
        public DateTimeOffset CreateStatus { get; set; }
        public DateTimeOffset ModifyStatus { get; set; }
    }
}
