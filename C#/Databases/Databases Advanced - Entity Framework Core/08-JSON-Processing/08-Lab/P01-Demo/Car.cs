using System.Text;

namespace P01_Demo;

public class Car
{
    public string Vendor { get; set; }
    public string Model { get; set; }
    public decimal Price { get; set; }
    public DateTime ManufacturedOn { get; set; }
    public List<string> Extras { get; set; }

    public Engine Engine { get; set; }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb
            .AppendLine($"Vendor: {this.Vendor}")
            .AppendLine($"Model: {this.Model}")
            .AppendLine($"Price: {this.Price:F2}")
            .AppendLine($"Manufactured on: {this.ManufacturedOn}")
            .AppendLine($"Extras: {Environment.NewLine}--{string.Join($"{Environment.NewLine}--", this.Extras)}")
            .AppendLine($"Engine: {Environment.NewLine}{this.Engine.ToString()}");
        return sb.ToString().TrimEnd();

    }
}