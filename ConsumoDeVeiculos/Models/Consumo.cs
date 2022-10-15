using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsumoDeVeiculos.Models
{
    [Table("Consumos")]
    public class Consumo
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Por favor, insira uma descrição")]
        public string Descricao { get; set; }

        [Required]
        public DataType Data { get; set; }

        public int Km { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [Required(ErrorMessage = "Por favor, informe o valor gasto")]
        public decimal Valor { get; set; }

        [Required]
        public TipoCombustivel Combustivel { get; set; }

        [Required(ErrorMessage ="Por favor, informe a identificacao do veiculo")]
        [Display(Name ="Veiculo")]
        public int VeiculoId { get; set; }

        [ForeignKey("VeiculoId")]
        public Veiculo Veiculo { get; set; }

    }
    public enum TipoCombustivel
    {
        Gasolina,
        Etanol,
        Diesel
    }
}
