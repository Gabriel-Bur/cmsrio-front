﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class AvaliacaoViewModel
    {
        public int IDAvaliacao { get; set; }


        public int? IDHospital { get; set; }

        [Required]
        [StringLength(60,MinimumLength = 5,ErrorMessage ="Digite seu nome Completo")]
        public string Nome { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [Required]
        public string Assunto { get; set; }

        [Required]
        [StringLength(600, MinimumLength = 10, ErrorMessage = "Seu comentário deve conter no mínimo 10 e no máximo 600 caracteres")]
        public string Comentario { get; set; }


        public string Data { get; set; }




    }
}