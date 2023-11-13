using System.ComponentModel.DataAnnotations;
using ProyectoComunidadesRelativo.Controllers.Interfaces;

namespace ProyectoComunidadesRelativo.Models
{
    public class Community : IListable
    {
        public Community() { }
        public Community(int id, string name, string theme, int numMembers)
        {
            Id = id;
            Name = name;
            Theme = theme;
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Theme { get; set; }

        public override string ToString()
        {
            return $"ID: {Id}, Name: {Name}, Theme: {Theme}";
        }

    }
}
