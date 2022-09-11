using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UserCRUD;

namespace UserCRUD.Model
{
    public class Usuarios
    {
        [Key]
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "{0} valido deve ser informado.")]
        [StringLength(11, ErrorMessage = "O CPF deve conter 11 caracteres.", MinimumLength = 11)]
        [RegularExpression("([0-9]+)", ErrorMessage = "O CPF informado deve conter apenas números.")]        
        public string cpf { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Nome { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Sobrenome { get; set; }

        [Required]
        [RegularExpression("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9]+)*\\.([a-z]{2,4})$", ErrorMessage = "E-mail em formato inválido.")]        
        public string Email { get; set; }

        [DataType(DataType.Date)]        
        public DateTime DataNascimento { get; set; }

        [Required]
        public int HistoricoEscolarId { get; set; }

        [ForeignKey("Escolaridade")]
        public int EscolaridadeId { get; set; }
    }
}