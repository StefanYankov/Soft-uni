using System.Text;
using System.Xml.Linq;

namespace P02_WikiDemo
{
    public class StartUp
    {
        public static void Main()
        {
            // download data from https://dumps.wikimedia.org/bgwiki/latest/
            Console.OutputEncoding = Encoding.Unicode;
            //XDocument rawDataDocument = XDocument.Load("../../../bgwiki-latest-abstract.xml");

            //// remove all links to thin down the document
            //foreach (var doc in rawDataDocument.Root.Elements())
            //{
            //    doc.SetElementValue("links", null);
            //}

            //rawDataDocument.Save("../../../bgwiki.xml");

            XDocument document = XDocument.Load("../../../../bgwiki.xml");
            var programmingExtract = document.Root.Elements()
                .Where(x => x.Element("abstract").Value.Contains("програми")
                || x.Element("abstract").Value.Contains("програмир"))
                .ToArray();

            foreach (var article in programmingExtract)
            {
                Console.WriteLine(article.Element("title").Value.Replace("Уикипедия: ", string.Empty));
            }
        }
    }
}