using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ConsumoDeVeiculos.Models
{
    [Table("Usuarios")]
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe seu nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Digite sua senha")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        public TipoPerfil Perfil { get; set; }

    }

    public enum TipoPerfil
    {
        Admin,
        Usuario
    }
}
