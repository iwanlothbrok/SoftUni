namespace ValidationAttributes
{
    public class Person
    {
        public Person(string name, int age)
        {
            FullName = name;
            Age = age;
        }
        [MyRequired]
        public string FullName { get; set; }
        public int Age { get; set; }
    }
}