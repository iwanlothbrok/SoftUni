using System;

namespace po_06._Tournament_of_Christmas
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int winCount = 0;
            int loseCount = 0;
            double savedMoneyFirstDay = 0;
            double totalMoney = 0;
            int totalWins = 0;
            int totalLoses = 0;
            //1
            for (int i = 1; i <= days; i++)
            {
                string sport = Console.ReadLine();
                while (sport != "Finish")
                {
                    string winOrLose = Console.ReadLine();
                    if (winOrLose == "win")
                    {
                        winCount++;
                        savedMoneyFirstDay += 20;

                    }
                    else
                    {
                        loseCount++;
                    }
                    sport = Console.ReadLine();
                }
                if (winCount > loseCount)
                {
                    savedMoneyFirstDay *= 1.1;
                }
                totalMoney += savedMoneyFirstDay;
                savedMoneyFirstDay = 0;
                totalWins += winCount;
                winCount = 0;
                totalLoses += loseCount;
                loseCount = 0;


            }
            if (totalWins > totalLoses)
            {
                totalMoney *= 1.2;
                Console.WriteLine($"You won the tournament! Total raised money: {totalMoney:f2}");
            }
            else
            {
                Console.WriteLine($"You lost the tournament! Total raised money: {totalMoney:f2}");
            }
        }
    }
}
//win count , lose count , saved money 