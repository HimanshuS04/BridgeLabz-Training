using System;

class ParcelMenu
{
    private IParcelTracker tracker = new ParcelTrackerUtilityImpl();

    public void ShowMenu()
    {
        int choice;

        do
        {
            Console.WriteLine("\n---- Parcel Tracker Menu ----");
            Console.WriteLine("1. Track Parcel");
            Console.WriteLine("2. Add Custom Checkpoint");
            Console.WriteLine("3. Mark Parcel as Lost");
            Console.WriteLine("4. Exit");
            Console.Write("Enter choice: ");

            choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    tracker.TrackParcel();
                    break;
                case 2:
                    tracker.AddCheckpoint();
                    break;

                case 3:
                    tracker.MarkLostAfter();
                    break;

                case 4:
                    Console.WriteLine("Exiting Parcel Tracker...");
                    break;

                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }

        } while (choice != 4);
    }
}
