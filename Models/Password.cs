using System.ComponentModel.DataAnnotations;
using ProyectoComunidadesRelativo.Controllers.Interfaces;

namespace ProyectoComunidadesRelativo.Models
{
    public class Password
    {
        [Key]
        public int Id { get; set; }
        public int User_id { get; set; }
        public string Pass { get; set; }

    }
}
