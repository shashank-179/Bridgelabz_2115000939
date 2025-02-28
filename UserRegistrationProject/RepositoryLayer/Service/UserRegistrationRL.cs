using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using ModelLayer.DTO;

namespace RepositoryLayer.Service
{
    public class UserRegistrationRL
    {
        ResponseModel<LoginDTO> response;
        private string databaseUsername = "root";
        private string databasePassword = "root";
        private string databasefirstName;
        private string databaselastName;
        private string databaseEmail="shashank179@gmail.com;
        private string databasepassword;

        public List<RegisterDTO> registeredUsers;
        public List<string> registrationRL()
        {
            return new List<string> {"root","root"};
        }

        public LoginDTO getUsernamePassword(LoginDTO loginDTO)
        {
            loginDTO.username = databaseUsername;
            loginDTO.password = databasePassword;

            return loginDTO;
        }
        public RegisterDTO getDatabaseRecords(RegisterDTO registerDTO)
        {
            registerDTO.firstName = databasefirstName;
            registerDTO.lastName = databaselastName;
            registerDTO.EMail = databaseEmail;
            registerDTO.password = databasepassword;
            return registerDTO;
        }
        


    }
}
