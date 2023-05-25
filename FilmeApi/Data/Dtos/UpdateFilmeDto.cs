using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmeApi.Data.Dtos
{
    public class UpdateFilmeDto
    {
        [Required(ErrorMessage = "Campo título é obrigatório")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "Campo diretor é obrigatório")]
        public string Diretor { get; set; }
        [StringLength(30, ErrorMessage = "Limite máximo de 30 caracteres")]
        public string Genero { get; set; }
        [Range(1, 600, ErrorMessage = "Valores é entre 1 à 600")]
        public int Duracao { get; set; }
    }
}
