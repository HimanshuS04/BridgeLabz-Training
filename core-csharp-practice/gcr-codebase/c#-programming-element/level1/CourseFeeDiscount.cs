using System;

class CourseFeeDiscount
{
    static void Main()
    {
        int fee = 125000;
        int dPercent = 10;

        double discount = fee * dPercent / 100.0;
        double finalFee = fee - discount;

        Console.WriteLine(
            "The discount amount is INR " + discount +
            " and final discounted fee is INR " + finalFee
        );
    }
}
