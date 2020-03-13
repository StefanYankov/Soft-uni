namespace BirthdayCelebrations
{
    public class Robot : IID
    {
        private string model;

        public Robot(string model, string id)
        {
            this.Model = model;
            this.Id = id;
        }

        public string Model
        {
            get
            { 
                return this.model;
            }
            set 
            { 
                model = value;
            }
        }

        public string Id { get; private set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
