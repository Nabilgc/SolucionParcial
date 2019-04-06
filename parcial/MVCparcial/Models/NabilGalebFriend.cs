using System.ComponentModel.DataAnnotations;

namespace MVCparcial.Models
{
    public enum FriendType
    {
        Conocido,
        CompaneroEstudio,
        ColegaTrabajo,
        Amigo,
        AmigoInfancia,
        Pariente

    }
    public class NabilGalebFriend
    {
        [Key]
        public int FriendID { get; set; }

        [Required]
        public string NombreCompleto { get; set; }

        public FriendType TipoAmigo { get; set; }

       [Required]

        public string Apodo { get; set; }

        public string Cumpleanos { get; set; }

    }
}