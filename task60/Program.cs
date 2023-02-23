// Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
// Массив размером 2 x 2 x 2
// 66(0,0,0) 25(0,1,0)
// 34(1,0,0) 41(1,1,0)
// 27(0,0,1) 90(0,1,1)
// 26(1,0,1) 55(1,1,1)

void PrintArray(int[,,] thisArr)
{
    int firstDimension = thisArr.GetLength(0);
    int secondDimension = thisArr.GetLength(1);
    int thirdDimension = thisArr.GetLength(2);
    Console.WriteLine();
    Console.WriteLine($"Массив {firstDimension}x{secondDimension}x{thirdDimension}:");
    Console.WriteLine();
    for (int i = 0; i < firstDimension; i++)
    {
        for (int j = 0; j < secondDimension; j++)
        {
            Console.Write("{0, 9}", "");
            for (int k = 0; k < thirdDimension; k++)
            {
                Console.Write("{0, 5}", thisArr[i, j, k]);
                Console.Write($"({i},{j},{k})");
            }
            Console.WriteLine();
        }        
    }
}

int[,,] GetArray()
{
    int firstDimension = 2;
    int secondDimension = 2;
    int thirdDimension = 2;
    int[,,] newArr = new int[firstDimension, secondDimension, thirdDimension];
    Random randNum = new Random();
    int lowerBound = 10;
    int upperBound = 100;
    for (int i = 0; i < firstDimension; i++)
    {
        for (int j = 0; j < secondDimension; j++)
        {
            for (int k = 0; k < thirdDimension; k++)
            {
                while (true)
                {
                    int temp = randNum.Next(lowerBound, upperBound);
                    if (CheckUniqueNum(newArr, temp))
                    {
                        newArr[i, j, k] = temp;
                        break;
                    }
                }
            }
        }
    }
    return newArr;
}

bool CheckUniqueNum(int[,,] thisArr, int temp)
{
    int firstDimension = thisArr.GetLength(0);
    int secondDimension = thisArr.GetLength(1);
    int thirdDimension = thisArr.GetLength(2);
    for (int i = 0; i < firstDimension; i++)
    {
        for (int j = 0; j < secondDimension; j++)
        {
            for (int k = 0; k < thirdDimension; k++)
            {
                if (thisArr[i, j, k] == temp)
                    return false;
            }
        }
    }
    return true;
}

int[,,] newArray = GetArray();
PrintArray(newArray);