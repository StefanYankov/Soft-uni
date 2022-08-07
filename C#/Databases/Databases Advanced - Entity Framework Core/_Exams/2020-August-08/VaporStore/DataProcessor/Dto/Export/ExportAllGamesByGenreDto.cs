using System.Collections.Generic;

namespace VaporStore.DataProcessor.Dto.Export
{
    public class ExportAllGamesByGenreDto
    {
        public int Id { get; set; }
        public string Genre { get; set; }
        public ICollection<ExportGamesDto> Games { get; set; }

        public int TotalPlayers { get; set; }
    }
}
