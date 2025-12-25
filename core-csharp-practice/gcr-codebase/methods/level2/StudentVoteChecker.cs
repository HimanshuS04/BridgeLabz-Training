using System;
class StudentVoteChecker
{
    public static bool CanVote(int age)
    {

        if (age < 0)
            return false;


        if (age >= 18)
            return true;
        else
            return false;
    }

    public static void Main(string[] args)
    {
        int[] ages = new int[10];

        for (int i = 0; i < ages.Length; i++)
        {
            Console.Write("Enter age of student " + (i + 1) + ": ");
            ages[i] = Convert.ToInt32(Console.ReadLine());

            bool canVote = CanVote(ages[i]);

            if (canVote)
            {
                Console.WriteLine("Student " + (i + 1) + " can vote.");
            }
            else
            {
                Console.WriteLine("Student " + (i + 1) + " cannot vote.");
            }
        }
    }

}