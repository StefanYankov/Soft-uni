﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VaporStore.Data.Models
{
    public class Game
    {
        public Game()
        {
            this.Purchases = new HashSet<Purchase>();
            this.GameTags = new HashSet<GameTag>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
       // [Range(typeof(decimal),"0.0", "79228162514264337593543950335")]
        public decimal Price { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        [ForeignKey(nameof(Developer))]
        [Required]
        public int DeveloperId { get; set; }
        [Required]
        public Developer Developer { get; set; }

        [ForeignKey(nameof(Genre))]
        [Required]
        public int GenreId { get; set; }
        public Genre Genre { get; set; }

        public virtual ICollection<Purchase> Purchases { get; set; }
        public virtual ICollection<GameTag> GameTags { get; set; }
    }
}

