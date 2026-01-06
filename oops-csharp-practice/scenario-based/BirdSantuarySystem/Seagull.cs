public class Seagull : Bird, IFlyable, ISwimmable
    {
        public Seagull(string name) : base(name) { }

        public void Fly()
        {
            System.Console.WriteLine("Seagull flies near the sea.");
        }

        public void Swim()
        {
            System.Console.WriteLine("Seagull floats on water.");
        }
    }