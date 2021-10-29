using System;
using System.Collections.Generic;

namespace AspNetCoreH5Examples.Areas.Database.Models
{
    public partial class Todolist
    {
        public int Id { get; set; }
        public string User { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}
