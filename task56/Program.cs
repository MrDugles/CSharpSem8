// Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 5 2 6 7
// Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка

int[,] GetArray()
{
    Console.WriteLine("Задайте размерность массива mxn");
    int rows = InputWithValidation("m - число строк: ");
    int cols = InputWithValidation("n - число столбцов: ");
    return FillArray(rows, cols);
}

int InputWithValidation(string message)
{
    int num;
    string? inputText;
    while (true)
    {
        Console.Write(message);
        inputText = Console.ReadLine();
        if (inputText == null || inputText.Trim() == "")
        {
            Console.WriteLine("Ошибка! Вы ничего не ввели.");
            continue;
        }
        try
        {
            num = int.Parse(inputText);
            break;
        }
        catch (FormatException)
        {
            Console.WriteLine("Ошибка! Введите число.");
            continue;
        }
        catch (OverflowException)
        {
            Console.WriteLine("Ошибка! Вы ввели слишком много символов.");
            continue;
        }
    }
    return num;
}

void PrintArray(int[,] thisArr)
{
    int rows = thisArr.GetLength(0);
    int cols = thisArr.GetLength(1);
    Console.WriteLine();
    Console.WriteLine($"Массив {rows}x{cols}:");
    Console.WriteLine();
    for (int i = 0; i < rows; i++)
    {
        Console.Write("{0, 9}", "|");
        for (int j = 0; j < cols; j++)
        {
            Console.Write("{0, 2}{1,2}", thisArr[i, j], "|");
        }
        Console.WriteLine();
    }
}

void PrintSummRows(int[] thisArr)
{
    Console.WriteLine();
    for (int i = 0; i < thisArr.Length; i++)
        Console.WriteLine($"Сумма элементов {i + 1} строки: {thisArr[i]}");
}

int[,] FillArray(int rows, int cols)

{
    int[,] newArr = new int[rows, cols];
    Random randNum = new Random();
    int lowerBound = 0;
    int upperBound = 10;
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < cols; j++)
        {
            newArr[i, j] = randNum.Next(lowerBound, upperBound);
        }
    }
    return newArr;
}

int[] GetSummRows(int[,] thisArr)
{
    int rows = thisArr.GetLength(0);
    int cols = thisArr.GetLength(1);
    int[] summArr = new int[rows];
    for (int row = 0; row < rows; row++)
    {
        for (int i = 0; i < cols; i++)
        {
            summArr[row] += thisArr[row, i];
        }
    }
    return summArr;
}

void GetRowMinSumm(int[] thisArr)
{
    (int value, int num) result = (int.MaxValue, 0);
    for (int i = 0; i < thisArr.Length - 1; i++)
    {
        if (result.value > thisArr[i + 1])
        {
            result.value = thisArr[i];
            result.num = i;
        }
    }
    Console.WriteLine($"Строка, содержащая наименьшую сумму элементов -> {result.num + 1} (Сумма {result.value})");
}

int[,] newArray = GetArray();
PrintArray(newArray);
int[] summArray = GetSummRows(newArray);
PrintSummRows(summArray);
GetRowMinSumm(summArray);