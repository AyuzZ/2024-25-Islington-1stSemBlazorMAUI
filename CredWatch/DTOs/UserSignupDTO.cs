using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CredWatch.DTOs
{
    public class UserSignupDTO
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string RetypePassword { get; set; }

        public string Currency { get; set; }
    }
}
