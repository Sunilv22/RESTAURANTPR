using System;
using System.Collections.Generic;

namespace RESTAURANTPROJ.Models
{
    public partial class Registration
    {
        public string Username { get; set; } = null!;
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string? Mobile { get; set; }
    }
}
