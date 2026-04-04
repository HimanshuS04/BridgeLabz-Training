using System;

class NumberChecker
{

    public static int CountDigits(int numm)
    {
        numm = Math.Abs(numm);
        if (numm == 0) return 1;

        int count = 0;
        while (numm > 0)
        {
            count++;
            numm /= 10;
        }
        return count;
    }

    public static int[] StoreDigits(int numm)
    {
        int count = CountDigits(numm);
        int[] digits = new int[count];
        numm = Math.Abs(numm);

        for (int i = count - 1; i >= 0; i--)
        {
            digits[i] = numm % 10;
            numm /= 10;
        }
        return digits;
    }

    public static int SumOfDigits(int[] digits)
    {
        int sum = 0;
        foreach (int d in digits) sum += d;
        return sum;
    }

    public static double SumOfSquaresOfDigits(int[] digits)
    {
        double sum = 0;
        foreach (int d in digits) sum += Math.Pow(d, 2);
        return sum;
    }

    //DUCK / ARMSTRONG / HARSHAD 

    public static bool IsDuckNumber(int[] digits)
    {
        foreach (int d in digits)
        {
            if (d == 0) return true;
        }
        return false;
    }

    public static bool IsArmstrong(int numm, int[] digits)
    {
        int power = digits.Length;
        int sum = 0;

        foreach (int d in digits)
        {
            sum += (int)Math.Pow(d, power);
        }
        return sum == numm;
    }

    public static bool IsHarshad(int numm, int[] digits)
    {
        int sum = SumOfDigits(digits);
        return sum != 0 && numm % sum == 0;
    }

    /* ======================= LARGEST / SMALLEST ======================= */

    public static void FindLargestSecondLargest(int[] digits, out int largest, out int secondLargest)
    {
        largest = Int32.MinValue;
        secondLargest = Int32.MinValue;

        foreach (int d in digits)
        {
            if (d > largest)
            {
                secondLargest = largest;
                largest = d;
            }
            else if (d > secondLargest && d != largest)
            {
                secondLargest = d;
            }
        }
    }

    public static void FindSmallestSecondSmallest(int[] digits, out int smallest, out int secondSmallest)
    {
        smallest = Int32.MaxValue;
        secondSmallest = Int32.MaxValue;

        foreach (int d in digits)
        {
            if (d < smallest)
            {
                secondSmallest = smallest;
                smallest = d;
            }
            else if (d < secondSmallest && d != smallest)
            {
                secondSmallest = d;
            }
        }
    }

//palindrome
    public static int[] ReverseArray(int[] arr)
    {
        int[] rev = new int[arr.Length];
        for (int i = 0; i < arr.Length; i++)
        {
            rev[i] = arr[arr.Length - 1 - i];
        }
        return rev;
    }

    public static bool AreArraysEqual(int[] a, int[] b)
    {
        if (a.Length != b.Length) return false;

        for (int i = 0; i < a.Length; i++)
        {
            if (a[i] != b[i]) return false;
        }
        return true;
    }

    public static bool IsPalindrome(int[] digits)
    {
        int[] reversed = ReverseArray(digits);
        return AreArraysEqual(digits, reversed);
    }

//prime specific numm
    public static bool IsPrime(int numm)
    {
        if (numm <= 1) return false;
        for (int i = 2; i <= Math.Sqrt(numm); i++)
        {
            if (numm % i == 0) return false;
        }
        return true;
    }

    public static bool IsNeon(int numm)
    {
        int square = numm * numm;
        int sum = SumOfDigits(StoreDigits(square));
        return sum == numm;
    }

    public static bool IsSpy(int[] digits)
    {
        int sum = 0, product = 1;
        foreach (int d in digits)
        {
            sum += d;
            product *= d;
        }
        return sum == product;
    }

    public static bool IsAutomorphic(int numm)
    {
        int square = numm * numm;
        return square.ToString().EndsWith(numm.ToString());
    }

    public static bool IsBuzz(int numm)
    {
        return numm % 7 == 0 || numm % 10 == 7;
    }

//factor
    public static int[] FindFactors(int numm)
    {
        int count = 0;
        for (int i = 1; i <= numm; i++)
            if (numm % i == 0) count++;

        int[] factors = new int[count];
        int index = 0;

        for (int i = 1; i <= numm; i++)
            if (numm % i == 0) factors[index++] = i;

        return factors;
    }

    public static int GreatestFactor(int[] factors)
    {
        int max = Int32.MinValue;
        foreach (int f in factors)
            if (f > max) max = f;
        return max;
    }

    public static int SumOfFactors(int[] factors)
    {
        int sum = 0;
        foreach (int f in factors) sum += f;
        return sum;
    }

    public static long ProductFactor(int[] factors)
    {
        long product = 1;
        foreach (int f in factors) product *= f;
        return product;
    }

    public static double ProductOfCube(int[] factors)
    {
        double product = 1;
        foreach (int f in factors)
            product *= Math.Pow(f, 3);
        return product;
    }

    public static bool IsPerfect(int numm, int[] factors)
    {
        int sum = 0;
        foreach (int f in factors)
            if (f != numm) sum += f;
        return sum == numm;
    }

    public static bool IsAbundant(int numm, int[] factors)
    {
        int sum = 0;
        foreach (int f in factors)
            if (f != numm) sum += f;
        return sum > numm;
    }

    public static bool IsDeficient(int numm, int[] factors)
    {
        int sum = 0;
        foreach (int f in factors)
            if (f != numm) sum += f;
        return sum < numm;
    }

    public static bool IsStrong(int numm)
    {
        int[] digits = StoreDigits(numm);
        int sum = 0;

        foreach (int d in digits)
        {
            int fact = 1;
            for (int i = 1; i <= d; i++) fact *= i;
            sum += fact;
        }
        return sum == numm;
    }

//main
    static void Main(string[] args)
    {
        Console.Write("Enter a numm: ");
        int numm = Convert.ToInt32(Console.ReadLine());

        int[] digits = StoreDigits(numm);
        int[] factors = FindFactors(numm);

        Console.WriteLine("Digit Count: " + CountDigits(numm));
        Console.WriteLine("Duck Number: " + IsDuckNumber(digits));
        Console.WriteLine("Armstrong Number: " + IsArmstrong(numm, digits));
        Console.WriteLine("Harshad Number: " + IsHarshad(numm, digits));
        Console.WriteLine("Palindrome Number: " + IsPalindrome(digits));
        Console.WriteLine("Prime Number: " + IsPrime(numm));
        Console.WriteLine("Neon Number: " + IsNeon(numm));
        Console.WriteLine("Spy Number: " + IsSpy(digits));
        Console.WriteLine("Automorphic Number: " + IsAutomorphic(numm));
        Console.WriteLine("Buzz Number: " + IsBuzz(numm));
        Console.WriteLine("Perfect Number: " + IsPerfect(numm, factors));
        Console.WriteLine("Abundant Number: " + IsAbundant(numm, factors));
        Console.WriteLine("Deficient Number: " + IsDeficient(numm, factors));
        Console.WriteLine("Strong Number: " + IsStrong(numm));
    }
}
