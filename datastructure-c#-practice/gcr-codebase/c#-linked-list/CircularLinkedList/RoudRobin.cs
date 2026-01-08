class ProcessNode
{
    public int pid, burst;
    public ProcessNode next;
}

class RoundRobin
{
    ProcessNode head;

    public void AddProcess(int pid, int burst)
    {
        ProcessNode node = new ProcessNode { pid = pid, burst = burst };
        if (head == null)
        {
            head = node;
            node.next = head;
            return;
        }

        ProcessNode temp = head;
        while (temp.next != head)
            temp = temp.next;

        temp.next = node;
        node.next = head;
    }

    public void Simulate(int tq)
    {
        ProcessNode temp = head;
        do
        {
            Console.WriteLine("Executing P" + temp.pid);
            temp.burst -= tq;
            temp = temp.next;
        } while (temp != head);
    }
}
