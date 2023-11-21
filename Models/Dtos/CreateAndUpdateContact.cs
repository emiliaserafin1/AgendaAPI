using AgendaApi.Entities;
using System.ComponentModel.DataAnnotations;

namespace AgendaApi.Models
{
    public class CreateAndUpdateContact
    {
        /*NOTA IMPORTANTE*/
        /*Los DTOS están en ESPAÑOL porque el front tiene las intefaces
         definidas en ESPAÑOL, esta es una de las ventajas de utilizar DTOs
        para transportar datos desde el back a una capa del front ya que nos permite adaptarnos
        y tener flexibilidad a la hora de responder a las requests*/
        [Required]
        public string name { get; set; }
        public string lastName { get; set; }
        public string? address { get; set; }
        public string email { get; set; }
        public string? image { get; set; }
        public string number { get; set; }
        public string? company { get; set; }
        public User? User;
    }
}
