using System;

class CopyTo1D
{
    static void Main(string[] args)
    {
        int rows = int.Parse(Console.ReadLine());
        int columns = int.Parse(Console.ReadLine());

        int[,] matrix = new int[rows, columns];

        Console.WriteLine("Enter elements of the matrix:");
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                matrix[i, j] = int.Parse(Console.ReadLine());
            }
        }
        int[] array = new int[rows * columns];

        // Copy elements from 2D array to 1D array
        int index = 0;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                array[index] = matrix[i, j];
                index++;
            }
        }

        Console.WriteLine("Elements of 1D array:");
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i] + " ");
        }
    }
}
