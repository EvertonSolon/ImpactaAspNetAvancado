using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Loja.Mvc.Areas.Vendas.Models
{
    public class BaseViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "ProdutoCabecalhoNome", ResourceType = typeof(Resources.Resource))]
        public string Nome { get; set; }
    }
}