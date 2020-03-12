
namespace BorderControl
{
    public class Citizen : IId
    {
		private string name;
		private int age;

		public Citizen(string name, int age, string id)
		{
			this.Name = name;
			this.Age = age;
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
		
		public int Age
		{
			get
			{
				return age;
			}
			private set
			{
				age = value;
			}
		}

		public string Id { get ; set ; }
    }
}
