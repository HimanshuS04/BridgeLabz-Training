public class Duck : Bird, ISwimmable
    {
        public Duck(string name) : base(name) { }

        public void Swim()
        {
            System.Console.WriteLine("Duck swims on the lake.");
        }
    }