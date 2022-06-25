using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace P05_BinaryDemo
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            // Deprecated! Use BSON
            var serializer = new XmlSerializer(typeof(Article[]), new XmlRootAttribute("feed"));
            IEnumerable<Article>? articles = (Article[])serializer.Deserialize(File.OpenRead("../../../../bgwiki.xml"))!;
            var binaryFormatter = new BinaryFormatter();

            binaryFormatter.Serialize(File.OpenWrite("articles.bin"), articles);

        }
    }
}