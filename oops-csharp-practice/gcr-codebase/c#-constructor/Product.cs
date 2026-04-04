using System;

class Product
{
    // Instance variables
    public string productName;
    public double price;

    // Class variable
    public static int totalProducts = 0;

    public Product(string name, double p)
    {
        productName = name;
        price = p;
        totalProducts++;
    }

    // Instance method
    public void DisplayProductDetails()
    {
        Console.WriteLine("Product Name: " + productName);
        Console.WriteLine("Price       : " + price);
    }

    // Class method
    public static void DisplayTotalProducts()
    {
        Console.WriteLine("Total Products: " + totalProducts);
    }

    static void Main()
    {
        Product p1 = new Product("Laptop", 50000);
        Product p2 = new Product("Mobile", 20000);

        p1.DisplayProductDetails();
        p2.DisplayProductDetails();

        Product.DisplayTotalProducts();
    }
}
