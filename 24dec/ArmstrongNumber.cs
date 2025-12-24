using System;
class ArmstrongNumber
{
    static void Main(string[] args)
    {
        int n=int.Parse(Console.ReadLine());
        int temp=n;
        int sum=0;
        int countDigit=0;
        while(temp>0)
        {
            countDigit+=1;
            temp=temp/10;  
        }
        temp=n;
        while (temp > 0)
        {
           int rem = temp % 10;
            sum += (int)Math.Pow(rem,countDigit);
            temp /= 10; 
        }
        if(sum==n)
        {
            Console.WriteLine($"{n} is an Armstrong Number");
        }
        else
        {
            Console.WriteLine($"{n} is not an Armstrong Number");
        }
    }
}
