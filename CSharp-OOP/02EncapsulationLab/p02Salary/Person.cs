

using System.Collections.Generic;

namespace PersonsInfo
{
    public class Person
    {
        
        public Person(string firstName, string secondName, int age, decimal salary)
        {
            this.FirstName = firstName;
            this.SecondName = secondName;
            this.Age = age;
            this.Salary = salary;
           
        }
        public string FirstName { get; private set; }
        public string SecondName { get; private set; }
        public int Age { get; private set; }
        public decimal Salary { get; private set; }

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
