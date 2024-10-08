﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EntitiesLayer
{
    public class Category
    {
        public int CategoryId { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;
        
        public string? Description { get; set; } = string.Empty ;
        //navigation property for ef core

        public List<Product>? Products { get; set; }
    }
}
