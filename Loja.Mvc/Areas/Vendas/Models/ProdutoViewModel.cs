﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Loja.Mvc.Areas.Vendas.Models
{
    public class ProdutoViewModel : BaseViewModel
    {
        public ProdutoViewModel()
        {
            Categorias = new List<SelectListItem>();
        }

        [Required]
        [Display(Name = "Preço")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public decimal? Preco { get; set; }

        [Required]
        public Nullable<int> Estoque { get; set; }

        [Display(Name = "Categoria")]
        public string CategoriaNome { get; set; }

        [Required]
        [Display(Name = "Categoria")]
        public int? CategoriaId { get; set; }

        public List<SelectListItem> Categorias { get; set; }

        public HttpPostedFileBase Imagem { get; set; }

        [Display(Name = "Em Leição")]
        public bool EmLeilao { get; set; }
    }
}