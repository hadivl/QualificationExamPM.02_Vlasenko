using System;
using System.Globalization;
using System.IO;

namespace Exam_Vlasenko
{
    internal class UploadingFile
    {
        public static double[,] UploadingFromFile(string filename)
        {
            if (!File.Exists(filename))
                throw new FileNotFoundException($"Файл {filename} не найден");

            var lines = File.ReadAllLines(filename);
            if (lines.Length == 0)
                throw new Exception("Файл пуст");

            int size = lines.Length;
            var graph = new double[size, size];
            var culture = CultureInfo.InvariantCulture;

            for (int i = 0; i < size; i++)
            {
                if (string.IsNullOrWhiteSpace(lines[i]))
                    throw new Exception($"Пустая строка {i + 1} в файле");

                var values = lines[i].Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                if (values.Length != size)
                    throw new Exception($"Ожидается {size} чисел в строке {i + 1}, но найдено {values.Length}");

                for (int j = 0; j < size; j++)
                {
                    if (!double.TryParse(values[j], NumberStyles.Any, culture, out graph[i, j]))
                        throw new Exception($"Неверный формат числа в строке {i + 1}, позиция {j + 1}: '{values[j]}'");

                    if (graph[i, j] < 0)
                        throw new Exception($"Отрицательное расстояние в строке {i + 1}, позиция {j + 1}");
                }
            }

            return graph;
        }
    }
}