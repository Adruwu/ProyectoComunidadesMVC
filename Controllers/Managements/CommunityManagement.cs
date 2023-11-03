using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoComunidades.Controllers.Interfaces;
using ProyectoComunidades.Services;

namespace ProyectoComunidades.Controllers.Managements
{
    public class CommunityManagement : ICommunityManagement
    {


        Communities communities = Communities.GetInstance();

        public void CreateCommunity()
        {
            throw new NotImplementedException();
        }

        public void ShowCommunityChats()
        {
            throw new NotImplementedException();
        }

    }
}
