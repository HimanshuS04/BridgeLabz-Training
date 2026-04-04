using System;

class MatrixOperations
{
    //  Create a random matrix
    public static double[,] GenerateRandomMatrix(int rows, int cols, int minValue = 1, int maxValue = 10)
    {
        double[,] matrix = new double[rows, cols];
        Random rand = new Random();
        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
                matrix[i, j] = rand.Next(minValue, maxValue);
        return matrix;
    }

    // b. Add two matrices
    public static double[,] AddMatrices(double[,] A, double[,] B)
    {
        int rows = A.GetLength(0);
        int cols = A.GetLength(1);
        double[,] result = new double[rows, cols];
        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
                result[i, j] = A[i, j] + B[i, j];
        return result;
    }

    // Subtract two matrices
    public static double[,] SubtractMatrices(double[,] A, double[,] B)
    {
        int rows = A.GetLength(0);
        int cols = A.GetLength(1);
        double[,] result = new double[rows, cols];
        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
                result[i, j] = A[i, j] - B[i, j];
        return result;
    }

    // d. Multiply two matrices
    public static double[,] MultiplyMatrices(double[,] A, double[,] B)
    {
        int rows = A.GetLength(0);
        int cols = B.GetLength(1);
        int n = A.GetLength(1); // Columns of A = rows of B
        double[,] result = new double[rows, cols];

        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
                for (int k = 0; k < n; k++)
                    result[i, j] += A[i, k] * B[k, j];

        return result;
    }

    // e. Transpose of a matrix
    public static double[,] TransposeMatrix(double[,] A)
    {
        int rows = A.GetLength(0);
        int cols = A.GetLength(1);
        double[,] result = new double[cols, rows];

        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
                result[j, i] = A[i, j];

        return result;
    }

    // Determinant of 2x2 matrix
    public static double Determinant2x2(double[,] A)
    {
        if (A.GetLength(0) != 2 || A.GetLength(1) != 2)
            throw new Exception("Matrix is not 2x2");
        return A[0, 0] * A[1, 1] - A[0, 1] * A[1, 0];
    }

    // Determinant of 3x3 matrix
    public static double Determinant3x3(double[,] A)
    {
        if (A.GetLength(0) != 3 || A.GetLength(1) != 3)
            throw new Exception("Matrix is not 3x3");

        double det = A[0, 0] * (A[1, 1] * A[2, 2] - A[1, 2] * A[2, 1])
                   - A[0, 1] * (A[1, 0] * A[2, 2] - A[1, 2] * A[2, 0])
                   + A[0, 2] * (A[1, 0] * A[2, 1] - A[1, 1] * A[2, 0]);
        return det;
    }

    // Inverse of 2x2 matrix
    public static double[,] Inverse2x2(double[,] A)
    {
        double det = Determinant2x2(A);
        if (det == 0) throw new Exception("Matrix is singular and cannot be inverted.");

        double[,] inv = new double[2, 2];
        inv[0, 0] = A[1, 1] / det;
        inv[0, 1] = -A[0, 1] / det;
        inv[1, 0] = -A[1, 0] / det;
        inv[1, 1] = A[0, 0] / det;
        return inv;
    }

    // i. Inverse of 3x3 matrix
    public static double[,] Inverse3x3(double[,] A)
    {
        double det = Determinant3x3(A);
        if (det == 0) throw new Exception("Matrix is singular and cannot be inverted.");

        double[,] inv = new double[3, 3];

        inv[0, 0] =  (A[1, 1]*A[2, 2] - A[1, 2]*A[2, 1]) / det;
        inv[0, 1] = -(A[0, 1]*A[2, 2] - A[0, 2]*A[2, 1]) / det;
        inv[0, 2] =  (A[0, 1]*A[1, 2] - A[0, 2]*A[1, 1]) / det;
        inv[1, 0] = -(A[1, 0]*A[2, 2] - A[1, 2]*A[2, 0]) / det;
        inv[1, 1] =  (A[0, 0]*A[2, 2] - A[0, 2]*A[2, 0]) / det;
        inv[1, 2] = -(A[0, 0]*A[1, 2] - A[0, 2]*A[1, 0]) / det;
        inv[2, 0] =  (A[1, 0]*A[2, 1] - A[1, 1]*A[2, 0]) / det;
        inv[2, 1] = -(A[0, 0]*A[2, 1] - A[0, 1]*A[2, 0]) / det;
        inv[2, 2] =  (A[0, 0]*A[1, 1] - A[0, 1]*A[1, 0]) / det;

        return inv;
    }

    // j. Display matrix
    public static void DisplayMatrix(double[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
                Console.Write(matrix[i, j].ToString("F2") + "\t");
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    static void Main(string[] args)
    {
        // Example usage
        double[,] matA = GenerateRandomMatrix(3, 3);
        double[,] matB = GenerateRandomMatrix(3, 3);

        Console.WriteLine("Matrix A:");
        DisplayMatrix(matA);

        Console.WriteLine("Matrix B:");
        DisplayMatrix(matB);

        Console.WriteLine("A + B:");
        DisplayMatrix(AddMatrices(matA, matB));

        Console.WriteLine("A - B:");
        DisplayMatrix(SubtractMatrices(matA, matB));

        Console.WriteLine("A * B:");
        DisplayMatrix(MultiplyMatrices(matA, matB));

        Console.WriteLine("Transpose of A:");
        DisplayMatrix(TransposeMatrix(matA));

        Console.WriteLine("Determinant of A (3x3): " + Determinant3x3(matA));

        Console.WriteLine("Inverse of A (3x3):");
        DisplayMatrix(Inverse3x3(matA));

        // Example for 2x2
        double[,] mat2x2 = GenerateRandomMatrix(2, 2);
        Console.WriteLine("Matrix 2x2:");
        DisplayMatrix(mat2x2);
        Console.WriteLine("Determinant of 2x2: " + Determinant2x2(mat2x2));
        Console.WriteLine("Inverse of 2x2:");
        DisplayMatrix(Inverse2x2(mat2x2));
    }
}
