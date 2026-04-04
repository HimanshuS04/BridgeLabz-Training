using System;

class Search2DMatrix
{
    static void Main()
    {
        int[,] matrix =
        {
            { 1, 3, 5 },
            { 7, 9, 11 },
            { 13, 15, 17 }
        };

        int target = 9;
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        int low = 0, high = rows * cols - 1;
        bool found = false;

        while (low <= high)
        {
            int mid = (low + high) / 2;
            int r = mid / cols;
            int c = mid % cols;

            if (matrix[r, c] == target)
            {
                found = true;
                break;
            }
            else if (matrix[r, c] < target)
                low = mid + 1;
            else
                high = mid - 1;
        }

        Console.WriteLine(found ? "Target Found" : "Target Not Found");
    }
}
