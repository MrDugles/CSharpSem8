// Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
// Например, даны 2 матрицы:
// 2 4 | 3 4
// 3 2 | 3 3
// Результирующая матрица будет:
// 18 20
// 15 18

int[,] GetArray()
{
    int rows = 2;
    int cols = 2;
    return FillArray(rows, cols);
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

void PrintArray(int[,] thisArr)
{
    int rows = thisArr.GetLength(0);
    int cols = thisArr.GetLength(1);
    Console.WriteLine();
    Console.WriteLine($"Массив {rows}x{cols}:");
    Console.WriteLine();
    for (int i = 0; i < rows; i++)
    {
        Console.Write("{0, 9}", "");
        for (int j = 0; j < cols; j++)
        {
            Console.Write("{0, 4}", thisArr[i, j]);
        }
        Console.WriteLine();
    }
}

static int[,] MatrixMultiplication(int[,] matrixA, int[,] matrixB)
{
    (int cols, int rows) firstMatrixLength = (matrixA.GetLength(0), matrixA.GetLength(1));
    (int cols, int rows) secondMatrixLength = (matrixB.GetLength(0), matrixB.GetLength(1));
    if (firstMatrixLength.cols != secondMatrixLength.rows)
    {
        throw new Exception("Умножение не возможно! Количество столбцов первой матрицы не равно количеству строк второй матрицы.");
    }

    int[,] matrixC = new int[firstMatrixLength.rows, secondMatrixLength.cols];

    for (int i = 0; i < firstMatrixLength.rows; i++)
    {
        for (int j = 0; j < secondMatrixLength.cols; j++)
        {
            matrixC[i, j] = 0;

            for (int k = 0; k < firstMatrixLength.cols; k++)
            {
                matrixC[i, j] += matrixA[i, k] * matrixB[k, j];
            }
        }
    }

    return matrixC;
}

// int[,] firstMatrix = { {2, 4}, {3, 2} };
// int[,] secondMatrix = { {3, 4}, {3, 3} };
int[,] firstMatrix = GetArray();
int[,] secondMatrix = GetArray();
PrintArray(firstMatrix);
PrintArray(secondMatrix);
PrintArray(MatrixMultiplication(firstMatrix, secondMatrix));