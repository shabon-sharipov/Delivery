﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Domain.Model
{
    public class Sender: EntityBase
    {
       public string FirstName { get; set; }
       public string LastName { get; set; }
       public DateTime DataOfBirth { get; set; }
       public string PhoneNumber { get; set; }
       public string Address { get; set; }
       public  string Email { get; set; }
       public string Password { get; set; }
        
    }
}
