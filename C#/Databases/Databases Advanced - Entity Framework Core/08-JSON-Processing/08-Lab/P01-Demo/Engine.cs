
using System.Text;

namespace P01_Demo
{
    public class Engine
    {
        public int HorsePower { get; set; }
        public float Volume { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"--HorsePower: {this.HorsePower}")
                .AppendLine($"--Volume: {this.Volume:F1}L");
            return sb.ToString().TrimEnd();
        }
    }
}
