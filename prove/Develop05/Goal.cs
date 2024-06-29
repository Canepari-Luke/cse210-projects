public abstract class Goal
{
    public string Name { get; set; }
    public int Points { get; set; }

    public abstract string Serialize();
    public abstract void Deserialize(string data);
    public abstract void RecordEvent();
    public abstract bool IsComplete();
}
