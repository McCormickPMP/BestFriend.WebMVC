﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestFriend.Models.CustomerModel
{
    public class CustomerList
    {
        public int CustomerID { get; set; }

        [Required]
        public char UserName { get; set; }
        [Required]
        public char Email { get; set; }
       
        [Required]
        public char FullName { get; set; }
        public char Address { get; set; }
        public char City { get; set; }
        public char ZipCode { get; set; }
        public DateTimeOffset CreateCustomer { get; set; }
        public DateTimeOffset ModifyCustomer { get; set; }
    }
}
