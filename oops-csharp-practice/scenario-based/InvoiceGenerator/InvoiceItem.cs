using System;

class InvoiceItem
{
    public string taskName;
    public int amount;

    public InvoiceItem(string taskName, int amount)
    {
        this.taskName = taskName;
        this.amount = amount;
    }
}
