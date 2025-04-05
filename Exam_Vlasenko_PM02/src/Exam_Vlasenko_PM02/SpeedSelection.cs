using System;

namespace Exam_Vlasenko
{
    internal class SpeedSelection
    {
        private static readonly Random random = new Random();

        public static double[,] RandomSpeedSelection(int rows, int cols)
        {
            if (rows <= 0 || cols <= 0)
                throw new ArgumentException("Размеры матрицы должны быть положительными");

            var speeds = new double[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    speeds[i, j] = random.Next(30, 81); // Скорость от 30 до 80 км/ч
                }
            }

            return speeds;
        }
    }
}