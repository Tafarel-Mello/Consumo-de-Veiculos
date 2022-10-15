using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace My_Second_MVC.Models
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
        public ICollection<Consumo> Consumos { get; set; }
    }
}
