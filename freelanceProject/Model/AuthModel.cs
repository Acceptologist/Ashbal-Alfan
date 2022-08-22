using System;
using System.Collections.Generic;

namespace freelanceProject.Model
{
    public class AuthModel
    {
        public string Username { get; set; }

        public string Role { get; set; }
        public bool IsAuthenticated { get; set; }

        public string Token { get; set; }
        public DateTime ExpiresOn { get; set; }
    }
}