using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorCondominios.BLL.Models
{
    public class Veiculo
    {
        public int VeiculoId { get; set; }


        //Nome
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(20, ErrorMessage = "Use menos caracteres")]
        public string Nome { get; set; }


        //Marca
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(20, ErrorMessage = "Use menos caracteres")]
        public string Marca { get; set; }


        //Cor
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(20, ErrorMessage = "Use menos caracteres")]
        public string Cor { get; set; }


        //Placa
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Placa { get; set; }

        public string UsuarioId { get; set; } // Chave estrangeira aparece no banco de dados

        public Usuario Usuario { get; set; }
    }
}
