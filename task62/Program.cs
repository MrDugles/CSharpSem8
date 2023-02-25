// Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
// Например, на выходе получается вот такой массив:
// 01 02 03 04
// 12 13 14 05
// 11 16 15 06
// 10 09 08 07

int[,] GetArray(int size)
{
    int cell = 1;
    int row = 0;
    int col = 0;
    int[,] newArr = new int[size, size];
    while (cell <= size * size)
    {
        newArr[row, col] = cell;
        cell++;
        if (row <= col + 1 && row + col < size - 1)
            col++;
        else if (row < col && row + col >= size - 1)
            row++;
        else if (row >= col && row + col > size - 1)
            col--;
        else
            row--;
    }
    return newArr;
}

void PrintArray(int[,] thisArr)
{
    int rows = thisArr.GetLength(0);
    int cols = thisArr.GetLength(1);
    Console.Clear();
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < cols; j++)
        {
            if (thisArr[i, j] < 10)
                Console.Write("{0,3}", "0" + thisArr[i, j]);
            else
                Console.Write("{0,3}", thisArr[i, j]);
        }
        Console.WriteLine();
    }
}

int[,] newArray = GetArray(4);
PrintArray(newArray);