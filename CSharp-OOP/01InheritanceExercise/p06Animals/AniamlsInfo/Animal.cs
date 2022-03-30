using System;
using System.Text;

namespace Animals.AniamlsInfo
{
    public abstract class Animal : IAnimal
    {
        private int age;
        private string gender;
        private string name;

        public Animal(string name, int age, string gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
        }

        public string Name

        {
            get => name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid input!");
                }
                name = value;
            }
        }

        public int Age
        {
            get => age;
            set
            {
                if (value <= 0)
                {

                    throw new ArgumentException("Invalid input!");
                }
                age = value;
            }
        }
        public string Gender
        {
            get => gender;
            set
            {
                if (value != "Male" && value != "Female" || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid input!");
                }
                gender = value;
            }
        }

        public abstract string ProduceSound();
        public override string ToString()
        {
            var builder = new StringBuilder();

            builder.AppendLine(this.GetType().Name)
                .AppendLine($"{this.name} {this.age} {this.gender.ToString()}")
                .Append($"{this.ProduceSound()}");

            return builder.ToString().TrimEnd();
        }

    }
}
