using System;
using System.Collections.Generic;

namespace AspNetCoreH5Examples.Areas.Database.Models
{
    public partial class Login
    {
        public int Id { get; set; }
        public string User { get; set; } = null!;
        public string Password { get; set; } = null!;
        public byte[]? Salt { get; set; }
    }
}
