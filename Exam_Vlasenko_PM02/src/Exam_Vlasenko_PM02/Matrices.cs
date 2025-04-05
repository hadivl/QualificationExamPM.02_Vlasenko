namespace Exam_Vlasenko
{
    internal class Matrices
    {
        public static void PrintSpeeds(double[,] speeds)
        {
            int size = speeds.GetLength(0);
            Console.Write("   ");
            for (int i = 0; i < size; i++)
                Console.Write($"{i + 1,5}");
            Console.WriteLine();

            for (int i = 0; i < size; i++)
            {
                Console.Write($"{i + 1,2} ");
                for (int j = 0; j < size; j++)
                {
                    Console.Write(speeds[i, j] > 0 ? $"{speeds[i, j],5:F0}" : "    -");
                }
                Console.WriteLine();
            }
        }
    }
}