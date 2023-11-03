using ProyectoComunidadesRelativo.Controllers.Interfaces;

namespace ProyectoComunidadesRelativo.Models
{
    public class Community : IListable
    {
        private int id;
        private string name;
        private string theme;
        private int numMembers;

        public Community(int id, string name, string theme, int numMembers)
        {
            this.id = id;
            this.name = name;
            this.theme = theme;
            this.numMembers = numMembers;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Theme { get => theme; set => theme = value; }
        public int NumMembers { get => numMembers; set => numMembers = value; }

    }
}
