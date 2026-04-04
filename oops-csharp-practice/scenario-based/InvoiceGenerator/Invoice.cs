using System;

class Invoice
{
    private InvoiceItem[] items;
    private int itemCount;

    public Invoice(int size)
    {
        items = new InvoiceItem[size];
        itemCount = 0;
    }
// parse invoice details from input string
    public void ParseInvoice(string input)
    {
        string[] tasks = input.Split(',');

        foreach (string task in tasks)
        {
            string[] parts = task.Split('-');

            if (parts.Length == 2)
            {
                string taskName = parts[0].Trim();

                string amountPart = parts[1].Trim();
                string[] amountWords = amountPart.Split(' ');
                int amount = int.Parse(amountWords[0]);

                items[itemCount] = new InvoiceItem(taskName, amount);
                itemCount++;
            }
        }
    }
// calculate total amount
    public int GetTotalAmount()
    {
        int total = 0;

        for (int i = 0; i < itemCount; i++)
        {
            total += items[i].amount;
        }

        return total;
    }
// display invoice details
    public void DisplayInvoice()
    {
        Console.WriteLine("\nInvoice Details:");
        for (int i = 0; i < itemCount; i++)
        {
            Console.WriteLine(items[i].taskName + " - " + items[i].amount + " INR");
        }
    }
}
