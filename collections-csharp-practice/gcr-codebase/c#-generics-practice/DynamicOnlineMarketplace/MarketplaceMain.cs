class MarketplaceMain
{
    static void Main()
    {
        Product<BookCategory> book = new Product<BookCategory>
        {
            ProductName = "C# Book",
            Price = 600,
            Category = new BookCategory { Genre = "Programming" }
        };

        DiscountManager.ApplyDiscount(book, 10);
        Console.WriteLine(book.Price);
    }
}
