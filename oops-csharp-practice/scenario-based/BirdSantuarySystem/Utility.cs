public class BirdUtility
    {
        public static void ProcessBirds(Bird[] birds)
        {
            foreach (Bird bird in birds)
            {
                System.Console.WriteLine(bird);

                bool canFly = bird is IFlyable;
                bool canSwim = bird is ISwimmable;

                // Special case: both abilities
                if (canFly && canSwim)
                {
                    System.Console.WriteLine("This bird can fly and swim both.");
                }
                else
                {
                    if (canFly)
                        ((IFlyable)bird).Fly();

                    if (canSwim)
                        ((ISwimmable)bird).Swim();
                }

                System.Console.WriteLine();
            }
        }
    }