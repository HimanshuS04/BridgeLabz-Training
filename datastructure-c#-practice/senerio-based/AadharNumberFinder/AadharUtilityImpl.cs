using System;
public class AadharUtilityImpl : IAadharService
{
    private Aadhar[] aadhars;
    public AadharUtilityImpl()
    {
        aadhars = new Aadhar[]
        {
            new Aadhar(987654321012,"Rahul Sharma",28,"12-03-1996"),
            new Aadhar(123456789010,"Anita Verma",34,"05-08-1990"),
            new Aadhar(987654321010,"Amit Singh",41,"22-01-1983"),
            new Aadhar(123456789012,"Neha Gupta",25,"14-11-1998"),
            new Aadhar(555544443333,"Rohan Mehta",31,"09-06-1993"),
            new Aadhar(111122223333,"Pooja Jain",29,"18-02-1995")
        };
    }
    public void DisplayAll()
    {
        for (int i = 0; i < aadhars.Length; i++)
        {
            Console.WriteLine(aadhars[i]);
        }
    }
    public void SortAadhar()
    {
        RadixSort();
        Console.WriteLine("Aadhar records sorted successfully.");
    }
    // ---------- RADIX SORT ----------
    private void RadixSort()
    {
        long exp = 1;

        for (int i = 0; i < 12; i++)
        {
            CountingSort(exp);
            exp = exp * 10;
        }
    }
    // ---------- COUNTING SORT  ----------
    private void CountingSort(long exp)
    {
        int n = aadhars.Length;
        Aadhar[] output = new Aadhar[n];
        int[] count = new int[10];

        for (int i = 0; i < n; i++)
        {
            int digit = (int)((aadhars[i].GetAadharNumber() / exp) % 10);
            count[digit]++;
        }

        for (int i = 1; i < 10; i++)
        {
            count[i] = count[i] + count[i - 1];
        }

        for (int i = n - 1; i >= 0; i--)
        {
            int digit = (int)((aadhars[i].GetAadharNumber() / exp) % 10);
            output[count[digit] - 1] = aadhars[i];
            count[digit]--;
        }

        for (int i = 0; i < n; i++)
        {
            aadhars[i] = output[i];
        }
    }
    // ---------- SEARCH ----------
    public void SearchAadhar()
    {
        Console.Write("Enter Aadhar number: ");
        long key = long.Parse(Console.ReadLine());
        int index = BinarySearch(key);

        if (index == -1)
        {
            Console.WriteLine("Aadhar record not found");
        }
        else
        {
            Console.WriteLine("Aadhar record found:");
            Console.WriteLine(aadhars[index]);
        }
    }

    private int BinarySearch(long key)
    {
        int low = 0;
        int high = aadhars.Length - 1;

        while (low <= high)
        {
            int mid = (low + high) / 2;

            long midVal = aadhars[mid].GetAadharNumber();

            if (midVal == key)
                return mid;
            else if (midVal < key)
                low = mid + 1;
            else
                high = mid - 1;
        }
        return -1;
    }
}