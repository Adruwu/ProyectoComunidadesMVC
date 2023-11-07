using System.ComponentModel.DataAnnotations;
using ProyectoComunidadesRelativo.Controllers.Interfaces;

namespace ProyectoComunidadesRelativo.Models
{
    public class User : IListable
    {
        public User() { }
        public User(string username, string pass, int age, string email, string description)
        {
            Username = username;
            Pass = pass;
            Age = age;
            Email = email;
            Description = description;
        }

        public User(int id, string username, string pass, int age, string email, string description)
        {
            Id = id;
            Username = username;
            Pass = pass;
            Age = age;
            Email = email;
            Description = description;
        }

        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Pass { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return $"ID: {Id}, Username: {Username}, Pass: {Pass}, Age: {Age}, Email: {Email}, Description: {Description}";
        }

    }
}
