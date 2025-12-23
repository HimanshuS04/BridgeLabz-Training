using System;
class MultipleNumber
{
    static void Main(string[] args)
    {
        double[] arr= new double[10];
        double total=0.0;
        int index=0;
        while (true)
        {
           if(index<10){
           double num= double.Parse(Console.ReadLine());
                if (num <= 0)
                {
                    break;
                }
                else
                {
                    arr[index]=num;
                    index++;
                }
        
           }
            else
            {
                break;
            }
        }
        for(int i = 0; i < arr.Length; i++)
        {
            total+=arr[i];
        }
    Console.WriteLine($"the total is {total}");
    }
}