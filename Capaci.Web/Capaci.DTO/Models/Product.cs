﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Capaci.DTO.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public string Description { get; set; }
        public string ImagePath { get; set; }
    }
}
