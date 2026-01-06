public class Eagle : Bird, IFlyable
    {
        public Eagle(string name) : base(name) { }

        public void Fly()
        {
            System.Console.WriteLine("Eagle flies at great height.");
        }
    }