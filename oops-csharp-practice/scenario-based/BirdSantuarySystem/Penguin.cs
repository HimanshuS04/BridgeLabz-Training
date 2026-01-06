public class Penguin : Bird, ISwimmable
    {
        public Penguin(string name) : base(name) { }

        public void Swim()
        {
            System.Console.WriteLine("Penguin swims underwater ");
        }
    }