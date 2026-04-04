using System;

class ParcelTrackerUtilityImpl : IParcelTracker
{

    public ParcelTrackerUtilityImpl()
    {
        LoadDefaultStages();
    }

    private void LoadDefaultStages()
    {
        head = new StageNode("Packed");
        head.Next = new StageNode("Shipped");
        head.Next.Next = new StageNode("In Transit");
        head.Next.Next.Next = new StageNode("Delivered");
    }
    private StageNode head;

    public void AddStage()
    {
        Console.Write("Enter stage name: ");
        string stage=Console.ReadLine();
        StageNode newNode = new StageNode(stage);

        if (head == null)
        {
            head = newNode;
            return;
        }

        StageNode temp = head;
        while (temp.Next != null)
        {
            temp = temp.Next;
        }
        temp.Next = newNode;
    }

    public void AddCheckpoint()
    { 
        Console.Write("Enter existing stage: ");
        string afterStage = Console.ReadLine();
        Console.Write("Enter new checkpoint: ");
        string newStage = Console.ReadLine();
        
        StageNode temp = head;

        while (temp != null && temp.StageName != afterStage)
        {
            temp = temp.Next;
        }

        if (temp == null)
        {
            Console.WriteLine("Stage not found. Checkpoint not added.");
            return;
        }

        StageNode checkpoint = new StageNode(newStage);
        checkpoint.Next = temp.Next;
        temp.Next = checkpoint;
    }

    public void TrackParcel()
    {
        if (head == null)
        {
            Console.WriteLine("Parcel LOST or tracking not started.");
            return;
        }

        StageNode temp = head;
        Console.Write("Parcel Status: ");

        while (temp != null)
        {
            Console.Write(temp.StageName);
            if (temp.Next != null)
                Console.Write(" → ");
            temp = temp.Next;
        }
        Console.WriteLine();
    }

    public void MarkLostAfter()
    {
        Console.Write("Enter stage after which parcel is lost: ");
        string stage=Console.ReadLine();
        StageNode temp = head;

        while (temp != null && temp.StageName != stage)
        {
            temp = temp.Next;
        }

        if (temp == null)
        {
            Console.WriteLine("Stage not found. Cannot mark lost.");
            return;
        }

        temp.Next = null;
        Console.WriteLine("Parcel LOST after stage: " + stage);
    }
}
