public class Program
{
    public static void Main()
    {
        int health = 100;
        int bitcoins = 0;


        var dungeons = Console.ReadLine().Split('|').ToArray();
        var counter = 0;
        foreach (var cmd in dungeons)
        {
            counter++;
            var command = cmd.Split(' ');

            var value = int.Parse(command[1]);

            if (command[0] == "potion")
            {
                health += value;

                if (health > 100)
                {
                    health = 100;
                    Console.WriteLine($"You healed for {Math.Abs(health - value)} hp.");
                }
                else
                {
                    Console.WriteLine($"You healed for {Math.Abs(value)} hp.");
                }

                Console.WriteLine($"Current health: {health} hp.");
            }
            else if (command[0] == "chest")
            {
                bitcoins += value;
                Console.WriteLine($"You found {value} bitcoins.");
            }
            else
            {
                health -= value;
                if (health <= 0)
                {
                    Console.WriteLine($"You died! Killed by {command[0]}.");
                    Console.WriteLine($"Best room: {counter}");
                    return;
                }

                Console.WriteLine($"You slayed {command[0]}.");
            }
        }
        Console.WriteLine("You've made it!");
        Console.WriteLine($"Bitcoins: {bitcoins}");
        Console.WriteLine($"Health: {health}");
    }
}