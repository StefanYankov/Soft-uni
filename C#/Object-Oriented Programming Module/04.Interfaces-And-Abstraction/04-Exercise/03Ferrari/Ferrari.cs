using System.Text;

namespace Ferrari
{
    public class Ferrari : ICar
    {
        private const string Model = "488-Spider";

        public Ferrari(string driver)
        {
            this.Driver = driver;
        }

        public string Driver { get ; set ; }

        public string BreakPedal()
        {
            return "Brakes!";
        }

        public string GasPedal()
        {
            return "Gas!";
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{Model}/{this.BreakPedal()}/{this.GasPedal()}/{this.Driver}");
            return sb.ToString().TrimEnd();
        }
    }
}
