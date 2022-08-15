namespace Trucks.DataProcessor.ExportDto
{
    public class ExportClientsWithMostTrucksDto
    {
        public string Name { get; set; }
        public ExportTruckDto[] Trucks { get; set; }
    }
}
