
namespace p05BirthdayCelebrations
{
    public class Citizen : IIdentifiable, INamble,IBirtdable
    {
        //check if need feild
        public Citizen(string name, int age, string id, string birthDate)
        {
            Name = name;
            Age = age;
            Id = id;
            BirthDate = birthDate;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Id { get; set; }

        public string BirthDate { get; set; }
    }
}
