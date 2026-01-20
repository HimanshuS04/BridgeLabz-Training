class DiscountManager
{
    public static void ApplyDiscount<T>(Product<T> product, double percent)
    {
        product.Price -= product.Price * percent / 100;
    }
}
