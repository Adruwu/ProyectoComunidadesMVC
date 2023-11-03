

namespace ProyectoComunidades.Controllers.Interfaces
{
	public interface IGenericList<T>
	{
		public void AddToList(T elemento);
		public void ShowList();
		public List<T> GetList();

	}
}
