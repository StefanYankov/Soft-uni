using System.Xml.Linq;

namespace P01_Demo
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            //XDocument document = XDocument.Load("Data.xml");
            ///*Console.WriteLine(document
            //    .Root
            //    .Elements()
            //    .FirstOrDefault(x => x.Attributes().Any(a => a.Name == "test"))
            //    ?.Value);*/

            //// Read all titles
            ///*foreach (var book in document.Root.Elements())
            //{
            //    Console.WriteLine(book.Element("title")?.ToString());
            //}*/

            //// Modify XML 

            //// Add new element
            //foreach (var book in document.Root.Elements())
            //{
            //    book.SetElementValue("price", 1.20);
            //}

            //document.Save("../../../Data_new.xml");

            //// remove all elements

            ///*
            //foreach (var book in document.Root.Elements())
            //{
            //    book.RemoveAll();
            //}

            //document.Save("../../../Data_new.xml");
            //*/

            //// Add new attribute

            //document.Root.SetAttributeValue("book_count", document.Root.Elements().Count());
            //document.Save("../../../Data_new.xml");

            //// Add new element
            //document.Root.Add(
            //new XElement(
            //    "book",
            //    new XElement("title", "SoftUni Book"),
            //    new XElement("author", "SoftUni"),
            //    new XElement("isbn", "999-9-999-999999-0"),
            //    new XElement("price", "1.2")
            //    ));

            //document.Save("../../../Data_new.xml");

            //var bookTitle = document.Root.Elements().Select(x => new
            //    {
            //        Name = x.Element("title").Value,
            //        Isbn = x.Element("isbn").Value,
            //    })
            //    .OrderByDescending(x => x.Isbn)
            //    .Select(x => x.Name)
            //    .FirstOrDefault();

            //Console.WriteLine(bookTitle);

            // Create new XML document

            XDocument newDocument = new XDocument();
            var root = new XElement("library");
            newDocument.Add(root);

            for (int i = 0; i < 100; i++)
            {
                var book = new XElement("book");
                root.Add(book);
                book.Add(new XElement("title", i.ToString()));
                book.Add(new XElement("price", i * 100));
            }

            newDocument.Save("../../../New_library.xml");

        }
    }
}