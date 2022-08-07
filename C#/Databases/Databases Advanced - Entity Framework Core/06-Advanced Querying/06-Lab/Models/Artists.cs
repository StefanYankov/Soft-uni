using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Lab.Models
{
    public partial class Artists
    {
        public Artists()
        {
            ArtistMetadata = new HashSet<ArtistMetadata>();
            SongArtists = new HashSet<SongArtists>();
        }

        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ArtistMetadata> ArtistMetadata { get; set; }
        public virtual ICollection<SongArtists> SongArtists { get; set; }
    }
}
