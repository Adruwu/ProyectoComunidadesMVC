using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ProyectoComunidadesRelativo.Controllers.Interfaces;

namespace ProyectoComunidadesRelativo.Models
{
    public class Community : IListable
    {
        public Community() { }
        public Community(int id, string tittle, string theme, int creator_id)
        {
            Id = id;
            Tittle = tittle;
            Theme = theme;
            Creator_id = creator_id;
        }

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
        public string Tittle { get; set; }
        public string Theme { get; set; }
        public int Creator_id { get; set; }

        public override string ToString()
        {
            return $"ID: {Id}, Tittle: {Tittle}, Theme: {Theme}, Creator_id: {Creator_id}";
        }

    }
}
