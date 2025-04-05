namespace Exam_Vlasenko
{
    internal class TravelTime
    {
        public static double[,] ConvertTravelTime(double[,] distanceGraph, double[,] speedGraph)
        {
            if (distanceGraph.GetLength(0) != speedGraph.GetLength(0) ||
                distanceGraph.GetLength(1) != speedGraph.GetLength(1))
                throw new ArgumentException("Матрицы расстояний и скоростей должны быть одного размера");

            int size = distanceGraph.GetLength(0);
            var timeGraph = new double[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (distanceGraph[i, j] > 0)
                    {
                        if (speedGraph[i, j] <= 0)
                            throw new ArgumentException($"Некорректная скорость на участке {i + 1}-{j + 1}");

                        timeGraph[i, j] = distanceGraph[i, j] / speedGraph[i, j];
                    }
                    else
                    {
                        timeGraph[i, j] = 0;
                    }
                }
            }

            return timeGraph;
        }
    }
}