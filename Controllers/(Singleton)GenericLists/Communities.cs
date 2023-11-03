using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoComunidades.Controllers;
using ProyectoComunidades.Controllers.Interfaces;
using ProyectoComunidadesRelativo.Models;

namespace ProyectoComunidades.Services
{
	public class Communities
	{
		private GenericList<Community> communityList;
		private int numCommunities;

		private Communities()
		{
			communityList = new GenericList<Community>();
			numCommunities = 0;
		}

		private static Communities communitiesInstance;

		public static Communities GetInstance()
		{
			if (communitiesInstance == null)
			{
				communitiesInstance = new Communities();
			}
			return communitiesInstance;
		}

		public GenericList<Community> CommunityList
		{
			get { return communityList; }
		}
		public int NumCommunities
		{
			get { return numCommunities; }
		}

	}

}
