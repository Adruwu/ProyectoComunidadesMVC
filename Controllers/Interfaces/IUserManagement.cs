
namespace ProyectoComunidades.Controllers.Interfaces
{
	public interface IUserManagement
	{
		public void AddUser(string username, string password, int age, string email, string description);
		public void DeleteUser();
		public void ModifyUser();

	}
}
