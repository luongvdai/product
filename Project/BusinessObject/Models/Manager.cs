using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Manager
    {
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public bool? Role { get; set; }
    }
}
