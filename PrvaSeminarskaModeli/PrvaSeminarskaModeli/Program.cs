using System;

namespace PrvaSeminarskaModeli
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input regular.txt path:");
            string document = Console.ReadLine();
            Console.WriteLine("Winner for home true/false (Y/N)");
            String winner = Console.ReadLine();
            Console.WriteLine("Team statistics for N game before");
            int nStatistics = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Set ratio for test to learn model");
            int learnToTestRatio = Convert.ToInt32(Console.ReadLine());


            Boolean winnerIsHome = false;
            if (winner == "Y")
            {
                winnerIsHome = true;
            }

            DocumnetReader reader = new DocumnetReader(document);
            reader.readFile();
            setLearnAndTestModel models = new setLearnAndTestModel(reader._games, learnToTestRatio, nStatistics, winnerIsHome);
            models.setRandomRatio();
            models.saveFiles();
        }
    }
}
