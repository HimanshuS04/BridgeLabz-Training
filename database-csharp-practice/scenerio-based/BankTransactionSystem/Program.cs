class Program
{
    static void Main(string[] args)
    {
        
        CacheManager.LoadSampleData();

        Menu menu = new Menu();
        menu.Show();
    }
}
