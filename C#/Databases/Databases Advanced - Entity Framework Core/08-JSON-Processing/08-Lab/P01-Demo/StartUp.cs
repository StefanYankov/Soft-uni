using System.Globalization;
using System.Text.Json;
using System.Xml;
using CsvHelper;

namespace P01_Demo
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var car = new Car()
            {
                Extras = new List<string> { "Klimatronik", "4x4", "Farove" },
                ManufacturedOn = DateTime.Now,
                Model = "Golf",
                Vendor = "VW",
                Price = 12345.67M,
                Engine = new Engine()
                {
                    HorsePower = 125,
                    Volume = 1.6F,
                }
            };

            // File.WriteAllText("myCar.json", JsonSerializer.Serialize(car));
            /*var options = new JsonSerializerOptions()
            {
                WriteIndented = true,
            };
            Console.WriteLine(JsonSerializer.Serialize(car, options));*/



            var json = File.ReadAllText("myCar.json");
            Car carFromFile = JsonSerializer.Deserialize<Car>(json);
            Console.WriteLine(carFromFile.ToString());

            // to XML

            string xml = @"<?xml version='1.0' standalone='no'?> 
                             <root> 
                                <person id='1'> 
                                    <name>Alan</name> 
                                    <url>www.google.com</url> 
                                </person> 
                                <person id='2'> 
                                    <name>Louis</name> 
                                    <url>www.yahoo.com</url> 
                                </person> 
                            </root>";

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);

            // CSV

            using var reader = new StreamReader("Departments.csv");
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            var records = csv.GetRecords<Department>();
        }
    }

    public class Department
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Salary { get; set; }
    }
}