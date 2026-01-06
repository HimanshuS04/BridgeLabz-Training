public class Sparrow : Bird, IFlyable
    {
        public Sparrow(string name) : base(name) { }

        public void Fly()
        {
            System.Console.WriteLine("Sparrow flies quickly.");
        }
    }