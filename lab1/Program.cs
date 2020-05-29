using System;

namespace lab1
{
    class Program
    {
        static int DrawCard(int[] deck)
        {
            Random rand = new Random();
            int randCard = rand.Next(0, deck.Length);
            while (deck[randCard] == 0)
            {
                randCard = rand.Next(0, deck.Length);
            }
            return randCard;
        }

        static void Main(string[] args)

        {
            int[] deck = new int[] { 11, 11, 11, 11, 2, 2, 2, 2, 3, 3, 3, 3, 4, 4, 4, 4,
            6, 6, 6, 6, 7, 7, 7, 7, 8, 8, 8, 8, 9, 9, 9, 9, 10, 10, 10, 10 };
            int[] sum = new int[] { 0, 0 };

            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine("Player " + (i + 1) + " draw a card");
                while (true)
                {
                    int randCard = DrawCard(deck);
                    if (deck[randCard] == 11)
                    {
                        if (sum[i] + deck[randCard] >= 21)
                        {
                            deck[randCard] = 1;
                        }
                    }
                    sum[i] += deck[randCard];
                    deck[randCard] = 0;
                    Console.WriteLine(sum[i]);
                    if (sum[i] >= 21)
                    {
                        if (sum[i] != 21)
                        {
                            sum[i] = -1;
                        }
                        break;
                    }
                    Console.WriteLine("Draw another card? (y or n)");
                    ConsoleKey key = Console.ReadKey(true).Key;
                    while (key != ConsoleKey.N && key != ConsoleKey.Y)
                    {
                        key = Console.ReadKey(true).Key;
                    }
                    if (key == ConsoleKey.N) break;
                }
                Console.WriteLine();
            }
            if (sum[0] > sum[1])
            {
                Console.WriteLine("Player 1 win");
            }
            else if (sum[0] < sum[1])
            {
                Console.WriteLine("Player 2 win");
            }
            else Console.WriteLine("Tie");
            Console.ReadLine();
        }
    }
}
