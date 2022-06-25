using System.Collections;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace P03_SerializationDemo
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;

            // read XML with serializer
            //var serializer = new XmlSerializer(typeof(Article[]), new XmlRootAttribute("feed"));
            //IEnumerable<Article> articles = (Article[])serializer.Deserialize(File.OpenRead("../../../../bgwiki.xml"));

            //foreach (var article in articles
            //             .Where(x => x.@abstract.Contains("програмис")
            //             || x.@abstract.Contains("програмир")))
            //{
            //    Console.WriteLine(article.title.Replace("Уикипедия: ", string.Empty));
            //}

            // write XML with serializer
            var serializerOut = new XmlSerializer(typeof(List<Article>), new XmlRootAttribute("feed"));
            var books = new List<Article>
            {
                new() {
                    Title = "1984",
                    Abstract = "Nineteen Eighty-Four: a Novel, ...",
                    Url = @"https://en.wikipedia.org/wiki/Nineteen_Eighty-Four"
                },
                new() {
                    Title = "The Master and Margarita",
                    Abstract = "The Master and Margarita...",
                    Url = @"https://en.wikipedia.org/wiki/The_Master_and_Margarita"
                }
            };

            serializerOut.Serialize(File.OpenWrite("../../../goodBooks.xml"), books);
        }
    }
}

