namespace Footballers.DataProcessor.ExportDto
{
    public class ExportTeamsWithMostFootballersDto
    {
        public string Name { get; set; }

        public ExportFootballersDto[] Footballers { get; set; }
    }
}
