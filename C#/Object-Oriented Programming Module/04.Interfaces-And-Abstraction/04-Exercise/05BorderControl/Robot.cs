namespace BorderControl
{
    public class Robot : IId
	{
		private string name;

		public Robot(string name, string id)
		{
			this.Name = name;
			this.Id = id;
		}

		public string Name
		{
			get
			{
				return name;
			}
			private set
			{
				name = value;
			}
		}

		public string Id { get; set; }
	}
}
