using Exam_Vlasenko;
using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("Расчет оптимального маршрута в городе Кольчугино");

            var graph = UploadingFile.UploadingFromFile("way.txt");
            var speeds = SpeedSelection.RandomSpeedSelection(graph.GetLength(0), graph.GetLength(1));
            var timeGraph = TravelTime.ConvertTravelTime(graph, speeds);

            Console.WriteLine("\nДоступные точки: " + string.Join(", ", Enumerable.Range(1, graph.GetLength(0))));

            int start = ReadPoint("Введите начальную точку: ");
            int end = ReadPoint("Введите конечную точку: ");

            var (distances, predecessors) = Dijkstra.FindShortestPaths(timeGraph, start);
            double totalTime = distances[end];

            Console.WriteLine("\nСредние скорости на участках (км/ч):");
            Matrices.PrintSpeeds(speeds);

            Console.WriteLine($"\nМинимальное время пути: {totalTime:F2} часа ({totalTime * 60:F1} минуты)");
            Dijkstra.PrintPath(predecessors, start, end);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nОшибка: {ex.Message}");
            Console.WriteLine("Проверьте входные данные и повторите попытку");
        }
    }

    static int ReadPoint(string prompt)
    {
        int point;
        while (true)
        {
            Console.Write(prompt);
            if (int.TryParse(Console.ReadLine(), out point) && point >= 1 && point <= 9)
                return point - 1;
            Console.WriteLine("Ошибка: введите число от 1 до 9");
        }
    }
}