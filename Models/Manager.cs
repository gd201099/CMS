using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMS.Models
{
    public class Manager
    {
        public int HrId { get; set; }
        public string HrFirstName { get; set; }
        public string HrLastName { get; set; }
        public string HrPhone { get; set; }
        public string HrEmail { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

    }
}