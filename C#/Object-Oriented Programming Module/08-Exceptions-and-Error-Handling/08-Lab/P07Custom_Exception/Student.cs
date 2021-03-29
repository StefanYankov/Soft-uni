using System;
using P07Custom_Exception.Exceptions;

namespace P07Custom_Exception
{
    public class Student
    {
        private string name;
        private string email;

        public Student(string name, string email)
        {
            this.Name = name;
            this.Email = email;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                foreach (var letter in value)
                {
                    if (!char.IsLetter(letter))
                    {
                        throw new InvalidPersonNameException();
                    }

                    this.name = value;
                }
            }
        }

        public string Email
        {
            get
            {
                return this.email;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("value", "The email cannot be null or empty.");
                }

                this.email = value;
            }
        }
    }
}
