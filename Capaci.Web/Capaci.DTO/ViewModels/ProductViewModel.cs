using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Capaci.DTO.ViewModels
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public double Price { get; set; }

        public string Description { get; set; }
         public IFormFile ImageFile { get; set; }
        public string ImagePath { get; set; }
    }
}
