using System;
using P07Custom_Exception.Exceptions;

namespace P07Custom_Exception
{
    public class StartUp
    {
        public static void Main()
        {
            try
            {
                Student student = new Student("Gin4o", "gin4o@abv.bg");

                Console.WriteLine("Student was successfully created.");
            }
            catch (InvalidPersonNameException ipne)
            {
                Console.WriteLine(ipne.Message);
            }
            catch (ArgumentNullException ane)
            {
                Console.WriteLine(ane.Message);
            }
        }
    }
}
