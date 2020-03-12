using System;

using System.Text;

namespace Telephony
{
    public class Smartphone : ICallable, IBrowsable
    {
        public Smartphone()
        {
        }

        public string Browse(string address)
        {
            for (int i = 0; i < address.Length; i++) //url.Any(c => Char.IsDigit(c))) 
            {
                char currentChar = address[i];
                if (char.IsDigit(currentChar))
                {
                    return "Invalid URL!";
                }
            }

            StringBuilder sb = new StringBuilder();
            sb
                .Append("Browsing: ")
                .Append(address)
                .Append("!");

            return sb.ToString();
        }

        public string Call(string phone)
        {
            // int counter = 0; Updated problem Feb-2020
            for (int i = 0; i < phone.Length; i++) //!phone.All(c => Char.IsDigit(c))
            {
                // counter++;
                char currentDigit = phone[i];
                if (char.IsLetter(currentDigit))
                {
                    return "Invalid number!";
                }
            }

            StringBuilder sb = new StringBuilder();

            // if (counter == 10)
            //{
            sb
                .Append("Calling... ")
                .Append(phone);
            //}
            // else
            // sb.Append("Calling... ").Append(phone);

            return sb.ToString();
        }

    }
}
