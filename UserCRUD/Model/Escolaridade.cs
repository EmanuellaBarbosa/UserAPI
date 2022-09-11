using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserCRUD.Model
{
    public class Escolaridade
    {

        [Key]
        public int IdEscolaridade { get; set; }

        [Required]
        [StringLength(250, MinimumLength = 5)]
        [Column("descricao")]
        public string Descricao { get; set; }
    }
}