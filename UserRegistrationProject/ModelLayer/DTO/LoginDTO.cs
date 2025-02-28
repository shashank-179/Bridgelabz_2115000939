using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.DTO
{
    public class LoginDTO
    {
        public string username { get; set; }
        public string password { get; set; }

        override
        public string ToString()
        {
            return "Username:" + username + "and" + "Password:" + password;
        }
    }
}
