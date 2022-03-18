

using System;
using System.Collections.Generic;

namespace PersonsInfo
{
    public class Person
    {
        private string firstName;
        private string secondName;
        private int age;
        private decimal salary;
        public Person(string firstName, string secondName, int age, decimal salary)
        {
            this.FirstName = firstName;
            this.SecondName = secondName;
            this.Age = age;
            this.Salary = salary;

        }
        public string FirstName
        {
            get => firstName;
            private set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("First name cannot contain fewer than 3 symbols!");
                }
                this.firstName = value;
            }
        }
        public string SecondName
        {
            get => secondName;
            private set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Last name cannot contain fewer than 3 symbols!");
                }

                this.secondName = value;
            }
        }
        public int Age
        {
            get => age;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Age cannot be zero or a negative integer!");
                }
                this.age = value;
            }
        }
        public decimal Salary
        {
            get => salary;

            private set
            {
                if (value < 460)
                {
                    throw new ArgumentException("Salary cannot be less than 650 leva!");
                }
                this.salary = value;
            }
        }
        public void IncreaseSalary(decimal percentage)
        {
            int decrease = 100;
            if (this.Age < 30)
            {
                decrease = 200;
            }
            Salary += Salary * percentage / decrease;
        }

        public override string ToString()
        {
            return $"{FirstName} {SecondName} receives {Salary:f2} leva.";
        }
    }
}
