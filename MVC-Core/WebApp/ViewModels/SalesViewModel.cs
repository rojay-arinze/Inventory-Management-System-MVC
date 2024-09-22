﻿using System.ComponentModel.DataAnnotations;
using WebApp.Models;

namespace WebApp.ViewModels
{
    public class SalesViewModel
    {
        public int SelectedCategoryId { get; set; }

        public List<Category> Categories { get; set; } = new List<Category>();

        public int SelectedProductId { get; set; }

        [Display(Name ="Quantity")]
        public int QuantityToSell { get; set; }
    }
}
