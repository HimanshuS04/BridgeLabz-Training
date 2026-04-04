class StageNode
{
    public string StageName;
    public StageNode Next;

    public StageNode(string stageName)
    {
        StageName = stageName;
        Next = null;
    }
    public override string ToString()
    {
        return $"stage name {StageName}";
    }
}
