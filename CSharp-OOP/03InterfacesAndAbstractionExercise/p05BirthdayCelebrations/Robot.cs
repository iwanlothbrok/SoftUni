
namespace p05BirthdayCelebrations
{
    public class Robot : IIdentifiable, INamble
    {
        public Robot(string name, string id)
        {
            Name = name;
            Id = id;
        }

        public string Name { get; set; }

        public string Id { get; set; }
    }
}
