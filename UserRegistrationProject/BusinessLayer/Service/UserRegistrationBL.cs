using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer.DTO;
using RepositoryLayer.Service;

namespace BusinessLayer.Service
{
    public class UserRegistrationBL
    {
        UserRegistrationRL _userRegistrationRL;
        public UserRegistrationBL(UserRegistrationRL userRegistrationRL) 
        { 
            _userRegistrationRL = userRegistrationRL;
        }
        public string registrationBL(string username,string password) 
        { 
            List<string> credentials = _userRegistrationRL.registrationRL();
            string savedname = credentials[0];
            string savedpasswd = credentials[1];
            if ((username == savedname) & (password == savedpasswd))
            {
                return "Login Successful.";
            }
            else 
            {
                return "Invalid username and password.";            
            }
        }
        public bool RegisterUser(RegisterDTO registerDTO)
        {
            string frontendfirstName = registerDTO.firstName;
            string frontendlastName = registerDTO.lastName;
            string frontendEmail = registerDTO.EMail;
            string frontendPassword = registerDTO.password;

            RegisterDTO result = _userRegistrationRL.getDatabaseRecords(registerDTO);
            bool res = checkRecords(frontendEmail, result);
            return res;
        }
        private bool checkRecords(string frontendEmail, RegisterDTO result) 
        {
            if (frontendEmail == result.EMail)
            {
                return true;
            }
            return false;
        }
        public bool loginUser(LoginDTO loginDTO)
        {
            string frontendUsername = loginDTO.username;
            string frontendPassword = loginDTO.password;

            LoginDTO result = _userRegistrationRL.getUsernamePassword(loginDTO);

            bool res = checkUsernamePassword(frontendUsername, frontendPassword, result);
            return res;
        }
        private bool checkUsernamePassword(string frontendUsername, string frontendPassword, LoginDTO result)
        {
            if (frontendUsername == result.username && frontendPassword == result.password)
            {
                return true;
            }
            return false;

        }
    }
}
