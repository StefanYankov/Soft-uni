using System.Text;

namespace _02Cars.Cars
{
    public class Seat : ICar
    {
        public string Model { get; set; }
        public string Color { get; set; }

        public Seat(string model, string color)
        {
            this.Model = model;
            this.Color = color;
        }

        public string Start()
        {
            return "Engine start";
        }

        public string Stop()
        {
            return "Breaaak";
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{this.Color} {this.Model}");
            sb.AppendLine($"{this.Start()}");
            sb.AppendLine($"{this.Stop()}");
            return sb.ToString().TrimEnd();
        }
    }
}