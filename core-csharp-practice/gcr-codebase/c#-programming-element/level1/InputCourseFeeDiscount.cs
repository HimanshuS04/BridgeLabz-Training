using System;

class InputCourseFeeDiscount
{
    static void Main()
    {
        int fee = Convert.ToInt32(Console.ReadLine());
        int discountPercent = Convert.ToInt32(Console.ReadLine());

        double dis = fee * discountPercent / 100.0;
        double finalFee = fee - dis;

        Console.WriteLine(
            "The dis amount is INR " + dis +
            " and final discounted fee is INR " + finalFee
        );
    }
}