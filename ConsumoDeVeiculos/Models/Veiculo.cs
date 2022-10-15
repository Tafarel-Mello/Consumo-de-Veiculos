using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsumoDeVeiculos.Models
{
    [Table("Veiculos")]
    public class Veiculo
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Por favor informe o nome do veiculo")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por favor, informe a placa do veiculo")]
        public string Placa { get; set; }

        public ICollection<Consumo> Consumo { get; set; } // Para criar a relacao de consumos com cada veiculo
    }
}
