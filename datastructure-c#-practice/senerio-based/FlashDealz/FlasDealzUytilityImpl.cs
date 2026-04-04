using System;

public class FlashDealzUtilityImpl : IFlashDealz
{
    private Product[] products;
    private int count;

    public FlashDealzUtilityImpl()
    {
        products = new Product[10];
        count = 0;

        AddPredefined("Laptop", 50);
        AddPredefined("Mobile", 55);
        AddPredefined("Headphones", 35);
        AddPredefined("Smart Watch", 45);
        AddPredefined("Camera", 25);
    }

    private void AddPredefined(string name, int discount)
    {
        Product p = new Product();
        p.SetProduct(name, discount);
        AddInternal(p);
    }

    public void AddProduct()
    {
        Console.Write("Enter product name: ");
        string name = Console.ReadLine();

        Console.Write("Enter discount: ");
        int discount = int.Parse(Console.ReadLine());

        Product p = new Product();
        p.SetProduct(name, discount);

        AddInternal(p);
        Console.WriteLine("Product added.");
    }

    private void AddInternal(Product product)
    {
        if (count == products.Length)
            Resize();

        products[count++] = product;
    }

    private void Resize()
    {
        Product[] newArr = new Product[products.Length * 2];
        for (int i = 0; i < products.Length; i++)
            newArr[i] = products[i];

        products = newArr;
    }

    // ONE-METHOD iterative quick sort (unchanged)
    public void SortByDiscount()
    {
        if (count <= 1)
            return;

        int[] low = new int[count];
        int[] high = new int[count];
        int top = -1;

        low[++top] = 0;
        high[top] = count - 1;

        while (top >= 0)
        {
            int h = high[top];
            int l = low[top--];

            int pivot = products[h].GetDiscount();
            int i = l - 1;

            for (int j = l; j < h; j++)
            {
                if (products[j].GetDiscount() > pivot)
                {
                    i++;
                    Product t = products[i];
                    products[i] = products[j];
                    products[j] = t;
                }
            }

            Product temp = products[i + 1];
            products[i + 1] = products[h];
            products[h] = temp;

            int p = i + 1;

            if (p - 1 > l)
            {
                low[++top] = l;
                high[top] = p - 1;
            }

            if (p + 1 < h)
            {
                low[++top] = p + 1;
                high[top] = h;
            }
        }

        Console.WriteLine("Products sorted by discount.");
    }

    public void DisplayProducts()
    {
        if (count == 0)
        {
            Console.WriteLine("No products available.");
            return;
        }

        for (int i = 0; i < count; i++)
            Console.WriteLine(products[i]); // ToString()
    }
}
