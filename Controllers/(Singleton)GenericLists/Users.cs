using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoComunidades.Controllers;
using ProyectoComunidadesRelativo.Models;

namespace ProyectoComunidades.Services
{
	public class Users
	{
		private GenericList<User> userList;
		private int numUsers;

		private Users()
		{
			userList = new GenericList<User>();
			numUsers = 0;
		}

		private static Users usersInstance;

		public static Users GetInstance()
		{
			if (usersInstance == null)
			{
				usersInstance = new Users();
			}
			return usersInstance;
		}
		public GenericList<User> UserList
		{
			get { return userList; }
		}
		public int NumUsers
		{
			get { return numUsers; }
		}

	}
}
