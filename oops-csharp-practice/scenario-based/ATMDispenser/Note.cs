using System;
public class Note
{
    private int value;
    private int count;
    private Note? next;

    public Note(int value, int count)
    {
        this.value = value;
        this.count = count;
        this.next = null;
    }


    public int GetValue()
    {
        return value;
    }

    public void SetValue(int value)
    {
        this.value = value;
    }

    public int GetCount()
    {
        return count;
    }

    public void SetCount(int count)
    {
        this.count = count;
    }

    public Note GetNext()
    {
        return next;
    }

    public void SetNext(Note next)
    {
        this.next = next;
    }

    // 🔁 ToString Override
    public override string ToString()
    {
        return $"Note Value: ₹{value}, Available Count: {count}";
    }
}
