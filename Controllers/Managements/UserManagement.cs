using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ProyectoComunidades.Controllers;
using ProyectoComunidades.Controllers.Interfaces;
using ProyectoComunidadesRelativo.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProyectoComunidades.Controllers.Managements
{
    public class UserManagement : IUserManagement
    {
        DatabaseManagement DBInstance = new DatabaseManagement();
        public void AddUser(string username, string password, int age, string email, string description)
        {
            User newUser = new User(username, password, age, email, description);
            DBInstance.InsertUserDB(newUser);
        }
        public void DeleteUser()
        {

        }
        public void ModifyUser()
        {

        }

    }
}
