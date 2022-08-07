using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace _07_Lab_Demo.Models
{
    public partial class Song
    {
        public Song()
        {
            SongArtists = new HashSet<SongArtist>();
            SongMetadata = new HashSet<SongMetadata>();
        }

        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string Name { get; set; }
        public int? SourceId { get; set; }
        public string SourceItemId { get; set; }
        public string SearchTerms { get; set; }

        public virtual Source Source { get; set; }
        public virtual ICollection<SongArtist> SongArtists { get; set; }
        public virtual ICollection<SongMetadata> SongMetadata { get; set; }
    }
}
