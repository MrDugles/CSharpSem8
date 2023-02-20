// Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// В итоге получается вот такой массив:
// 7 4 2 1
// 9 5 3 2
// 8 4 4 2

int[,] GetArray()
{
    Console.WriteLine("Задайте размерность массива mxn");
    int rows = InputWithValidation("m: ");
    int cols = InputWithValidation("n: ");
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

int[,] SortArray(int[,] thisArr)
{
    int rows = thisArr.GetLength(0);
    int cols = thisArr.GetLength(1);
    for (int row = 0; row < rows; row++)
    {        
        for (int i = 0; i < cols; i++)
        {
            int temp = thisArr[row, i];
            for (int j = 0; j < cols-1; j++)
            {
                int num = thisArr[row, j];
                if (temp < num)
                {
                    temp = thisArr[row, i];
                    thisArr[row, i] = thisArr[row, j];
                    thisArr[row, j] = temp;
                }
            }
        }
    }
    return thisArr;
}

int[,] newArray = GetArray();
PrintArray(newArray);
newArray = SortArray(newArray);
PrintArray(newArray);