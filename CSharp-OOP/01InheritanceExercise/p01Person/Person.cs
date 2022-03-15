
using System;
using System.Text;

namespace p01Person
{
    public class Person
    {
        private string name;
        private int age;
        public Person(string name,int age)
        {
            this.Name = name;
            this.Age = age;
        }
        public string Name { get; set; }
        public int Age
        {
            get { return age; }
            set
            {
                if (age < 0)
                {
                    throw new System.Exception("Problem");
                }
                age = value;
            }
        }
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(String.Format("Name: {0}, Age: {1}",
                                 this.Name,
                                 this.Age));

            return stringBuilder.ToString();
        }
    }
}
