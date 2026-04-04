using System;
public abstract class Bird
    {
        public string Name { get; private set; }

        protected Bird(string name)
        {
            Name = name;
        }

        // Overriding ToString()
        public override string ToString()
        {
            return $"Bird Name: {Name}, Type: {GetType().Name}";
        }
    }