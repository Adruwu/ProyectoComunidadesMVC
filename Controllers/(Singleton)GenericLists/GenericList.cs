using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoComunidades.Controllers.Interfaces;
using ProyectoComunidadesRelativo.Controllers.Interfaces;

namespace ProyectoComunidades.Controllers
{
	public class GenericList<T> : IGenericList<T> where T : IListable
	{
		private List<T> elements = new List<T>();
		public void AddToList(T element)
		{
			elements.Add(element);
		}
		public void ShowList()
		{
			foreach (T element in elements)
			{
				Console.WriteLine(element.ToString());
			}
		}
		public List<T> GetList() { return elements; }

	}
}
