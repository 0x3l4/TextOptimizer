using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextOptimizer
{
    public static class TextOptimizer
    {
        public static void OptimizeFile(string inputFilePath, string outputFilePath)
        {
            Console.WriteLine($"Начинаю обработку файла {inputFilePath}...");

            HashSet<string> uniqueWords = new HashSet<string>();
            int deletedRowsCount = 0;
            
            var table = new ConsoleTable("№", "Слово", "Причина удаления", "Строка");

            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                string? line;
                int currentLine = 1;

                while ((line = reader.ReadLine()) != null)
                {
                    line = line.Replace('ё', 'е').Replace('Ё', 'Е');

                    if (!line.Contains('-'))
                    {
                        if (!uniqueWords.Add(line.Trim()))
                        {
                            deletedRowsCount++;
                            table.AddRow(deletedRowsCount, line, "Дубликат", currentLine);
                        }
                    }
                    else
                    {
                        deletedRowsCount++;
                        table.AddRow(deletedRowsCount, line, "Содержит тире", currentLine);
                    }

                    currentLine++;
                }
            }

            Console.WriteLine(table);

            File.WriteAllLines(outputFilePath, uniqueWords.ToArray());

            Console.WriteLine($"Обработка завершена. Результат сохранён в файл: {outputFilePath}.");
            Console.WriteLine($"Было строк: {deletedRowsCount + uniqueWords.Count}.");
            Console.WriteLine($"Удалено строк: {deletedRowsCount}.");
            Console.WriteLine($"Итого строк в новом файле: {uniqueWords.Count}.");
        }
    }
}
