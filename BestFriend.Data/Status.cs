using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestFriend.Data
{
    public class Status
    {
        [Key]
        public int StatusId { get; set; }
        public Guid StatusGuid { get; set; }
        [Required]
        public string StatusType { get; set; }
        public DateTimeOffset CreateStatus { get; set; }
        public DateTimeOffset ModifyStatus { get; set; }
    }
}
