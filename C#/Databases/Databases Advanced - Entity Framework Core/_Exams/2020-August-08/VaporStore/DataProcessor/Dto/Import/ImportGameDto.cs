﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VaporStore.Data.Models;

namespace VaporStore.DataProcessor.Dto.Import
{
    public class ImportGameDto
    {

        [Required]
        public string Name { get; set; }

        [Required]
        [Range(typeof(decimal),"0.0", "79228162514264337593543950335")]
        public decimal Price { get; set; }

        [Required]
        public string ReleaseDate { get; set; }

        [Required]
        public string Developer { get; set; }

        [Required]
        public string Genre { get; set; }

        public string[] Tags { get; set; }
    }
}