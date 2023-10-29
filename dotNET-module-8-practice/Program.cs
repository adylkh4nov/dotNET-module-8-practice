using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNET_module_8_practice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1.
            Console.WriteLine("Введите начальный и конечный индексы для создания диапазона массива:");
            Console.Write("Начальный индекс: ");
            int startIndex = int.Parse(Console.ReadLine());
            Console.Write("Конечный индекс: ");
            int endIndex = int.Parse(Console.ReadLine());

            RangeOfArray customArray = new RangeOfArray(startIndex, endIndex);

            Console.WriteLine("Введите элементы массива:");

            for (int i = startIndex; i <= endIndex; i++)
            {
                Console.Write($"Элемент с индексом {i}: ");
                customArray[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("Массив:");

            for (int i = startIndex; i <= endIndex; i++)
            {
                Console.WriteLine($"Элемент с индексом {i}: {customArray[i]}");
            }

            // 2.

            DateTime currentTime = DateTime.Now;

            bool isDiscountAvailable = currentTime.Hour >= 8 && currentTime.Hour < 12;

            string[] products = { "Хлеб", "Молоко", "Яйца", "Фрукты", "Овощи" };
            double[] prices = { 1.2, 2.0, 1.5, 3.0, 2.5 };

            Console.WriteLine("Список продуктов и цен:");
            for (int i = 0; i < products.Length; i++)
            {
                Console.WriteLine($"{i}) {products[i]}: {prices[i]} $");
            }

            Console.WriteLine("Введите номера выбранных продуктов (через запятую):");
            string input = Console.ReadLine();
            string[] selectedProductNumbers = input.Split(',');

            double totalCost = 0.0;

            foreach (string productNumber in selectedProductNumbers)
            {
                int index = int.Parse(productNumber.Trim());
                if (index >= 0 && index < products.Length)
                {
                    totalCost += prices[index];
                }
            }

            if (isDiscountAvailable)
            {
                totalCost *= 0.95;
                Console.WriteLine("Применена 5% скидка!");
            }

            Console.WriteLine($"Общая стоимость: {totalCost} $");

            Console.WriteLine("Спасибо за покупки!");

            // 3.

            double[] months = { 1, 2, 3, 4, 5 };
            double[] sales = { 10, 15, 13, 20, 18 };

            int n = months.Length;

            double sumMonths = 0, sumSales = 0, sumMonthsSales = 0, sumMonthsSquared = 0;
            for (int i = 0; i < n; i++)
            {
                sumMonths += months[i];
                sumSales += sales[i];
                sumMonthsSales += months[i] * sales[i];
                sumMonthsSquared += months[i] * months[i];
            }

            double a = (n * sumMonthsSales - sumMonths * sumSales) / (n * sumMonthsSquared - sumMonths * sumMonths);
            double b = (sumSales - a * sumMonths) / n;

            for (int month = 6; month <= 8; month++)
            {
                double forecast = a * month + b;
                Console.WriteLine($"Прогноз продаж на месяц {month}: {forecast:F2}");
            }



            Console.ReadLine();
        }
    }
}
class RangeOfArray
{
    private int startIndex;
    private int endIndex;
    private int[] array;

    public RangeOfArray(int start, int end)
    {
        if (end < start)
        {
            throw new ArgumentException("Конечный индекс должен быть больше или равен начальному индексу.");
        }

        startIndex = start;
        endIndex = end;
        array = new int[end - start + 1];
    }

    public int this[int index]
    {
        get
        {
            if (IsIndexValid(index))
            {
                return array[ConvertToInternalIndex(index)];
            }
            else
            {
                throw new IndexOutOfRangeException("Индекс находится вне диапазона.");
            }
        }
        set
        {
            if (IsIndexValid(index))
            {
                array[ConvertToInternalIndex(index)] = value;
            }
            else
            {
                throw new IndexOutOfRangeException("Индекс находится вне диапазона.");
            }
        }
    }

    private bool IsIndexValid(int index)
    {
        return index >= startIndex && index <= endIndex;
    }

    private int ConvertToInternalIndex(int index)
    {
        return index - startIndex;
    }
}
