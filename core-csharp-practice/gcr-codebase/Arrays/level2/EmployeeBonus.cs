using System;
using System.Linq.Expressions;
class EmployeeBonus
{
    static void Main(string[] args)
    {
         double[] salary= new double[10];
         double[] service= new double[10];
         double[] newSalary= new double[10];
         double[] bonus= new double[10];
         double totalBonus=0;
         double totalOldSalary=0;
         double totalNewSalary=0;
        
        for(int i = 0; i < 10; i++)
        {
            Console.WriteLine($"Enter the salary for {i+1} employee:");
            salary[i]=double.Parse(Console.ReadLine());
            if (salary[i] < 0)
            {
                Console.WriteLine("Please enter a valid salary.");
                i--;
                continue;
            }
        }
        for(int j = 0; j < 10; j++)
        {
            Console.WriteLine($"Enter the service year of {j+1} employee:");
            service[j]=double.Parse(Console.ReadLine());
            if (service[j] < 0)
            {
                Console.WriteLine("Please enter a valid service year.");
                j--;
                continue;
            }
        }
        for(int k = 0; k < 10; k++)
        {
            if (service[k] > 5)
            {
                bonus[k] =salary[k]*0.05;
                newSalary[k]=salary[k]+bonus[k];
                totalBonus+=bonus[k];
                totalOldSalary+=salary[k];
                totalNewSalary+=newSalary[k];
                
            }
            else if (service[k] < 5)
            {
                bonus[k] =salary[k]*0.02;
                newSalary[k]=salary[k]+bonus[k];
                totalBonus+=bonus[k];
                totalOldSalary+=salary[k];
                totalNewSalary+=newSalary[k];
            }
        }
                Console.WriteLine("Total bonus payout is:"+ totalBonus);
                Console.WriteLine("Total old salary is:"+ totalOldSalary);
                Console.WriteLine("Total new salary is:"+ totalNewSalary);
}
}