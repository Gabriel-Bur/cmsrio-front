using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class ContatoViewModel
    {

        [Required]
        [StringLength(60, MinimumLength = 5, ErrorMessage = "Digite seu nome Completo")] 
        public string Nome { get; set; }


        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [StringLength(600, MinimumLength = 10, ErrorMessage = "Seu comentário deve conter no mínimo 10 e no máximo 600 caracteres")]
        public string Comentario { get; set; }
    }
}