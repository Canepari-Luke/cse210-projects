public class SimpleGoal : Goal
{
    public bool IsCompleted { get; set; }

    public override string Serialize()
    {
        return $"SimpleGoal:{Name},{Points},{IsCompleted}";
    }

    public override void Deserialize(string data)
    {
        var parts = data.Split(',');
        Name = parts[0];
        Points = int.Parse(parts[1]);
        IsCompleted = bool.Parse(parts[2]);
    }

    public override void RecordEvent()
    {
        IsCompleted = true;
    }

    public override bool IsComplete()
    {
        return IsCompleted;
    }
}
