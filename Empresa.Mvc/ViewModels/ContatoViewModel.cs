﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Empresa.Mvc.ViewModels
{
    public class ContatoViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
        [Required]
        public string Assunto { get; set; }
        public string Mensagem { get; set; }
    }
}
