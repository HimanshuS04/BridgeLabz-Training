interface IParcelTracker
{
    void AddStage();
    void AddCheckpoint();
    void TrackParcel();
    void MarkLostAfter();
}
