using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestFriend.Models.StatusModel
{
    public class StatusUpdate
    {
        public int StatusId { get; set; }
        public char StatusType { get; set; }
        public DateTimeOffset CreateStatus { get; set; }
        public DateTimeOffset ModifyStatus { get; set; }
    }
}
