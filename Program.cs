using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

const string FileName = "numbers.txt";

try
{
    string text = File.ReadAllText(FileName);

    List<double> numbers = text.Split(new[] { ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                               .Select(double.Parse)
                               .ToList();

    if (!numbers.Any())
    {
        Console.WriteLine("Помилка: Файл порожній або не містить чисел.");
        return;
    }

    Console.WriteLine($"Оброблено числа: {string.Join(", ", numbers)}\n");

    double maxComponent = numbers.Max();
    Console.WriteLine($"1. Найбільше значення: {maxComponent}");

    var evenNumbered = numbers.Where((num, index) => (index + 1) % 2 == 0);
    if (evenNumbered.Any())
    {
        double minEvenNumbered = evenNumbered.Min();
        Console.WriteLine($"2. Найменше значення з парними номерами: {minEvenNumbered}");
    }
    else
    {
        Console.WriteLine("2. У файлі немає компонент з парними номерами.");
    }

    var oddNumbered = numbers.Where((num, index) => (index + 1) % 2 != 0);
    if (oddNumbered.Any())
    {
        double maxAbsOddNumbered = oddNumbered.Select(Math.Abs).Max();
        Console.WriteLine($"3. Найбільше значення модуля з непарними номерами: {maxAbsOddNumbered}");
    }
    else
    {
        Console.WriteLine("3. У файлі немає компонент з непарними номерами.");
    }

    double sumOfMaxAndMin = numbers.Max() + numbers.Min();
    Console.WriteLine($"4. Сума найбільшого і найменшого значень: {sumOfMaxAndMin}");

    if (numbers.Count >= 1)
    {
        double diffFirstLast = numbers.First() - numbers.Last();
        Console.WriteLine($"5. Різниця першої і останньої компонент: {diffFirstLast}");
    }
}
catch (FileNotFoundException)
{
    Console.WriteLine($"Помилка: Файл '{FileName}' не знайдено.");
}
catch (FormatException)
{
    Console.WriteLine($"Помилка: Файл містить некоректні дані (не числа).");
}
catch (Exception ex)
{
    Console.WriteLine($"Сталася неочікувана помилка: {ex.Message}");
}