// Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
// Например, на выходе получается вот такой массив:
// 01 02 03 04
// 12 13 14 05
// 11 16 15 06
// 10 09 08 07



Console.Clear();
Console.WriteLine($"Задача 62: Заполните спирально массив 4 на 4.");
Console.WriteLine();

int n = 9;
int[,] sqareMatrix = new int[n, n];

int cell = 1;
int row = 0;
int col = 0;
int rows = sqareMatrix.GetLength(0);
int cols = sqareMatrix.GetLength(1);
while (cell <= rows * cols)
{
    sqareMatrix[row, col] = cell;
    cell++;
    if (row <= col + 1 && row + col < cols - 1)
        col++;
    else if (row < col && row + col >= rows - 1)
        row++;
    else if (row >= col && row + col > cols - 1)
        col--;
    else
        row--;
}

WriteArray(sqareMatrix);

void WriteArray(int[,] array)
{
    int rows = array.GetLength(0);
    int cols = array.GetLength(1);
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < cols; j++)
        {
            if (array[i, j] < 10)
                Console.Write("{0,3}", "0" + array[i, j]);
            else
                Console.Write("{0,3}", array[i, j]);
        }
        Console.WriteLine();
    }
}