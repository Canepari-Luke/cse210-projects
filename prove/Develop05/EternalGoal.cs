public class EternalGoal : Goal
{
    public int Count { get; set; }

    public override string Serialize()
    {
        return $"EternalGoal:{Name},{Points},{Count}";
    }

    public override void Deserialize(string data)
    {
        var parts = data.Split(',');
        Name = parts[0];
        Points = int.Parse(parts[1]);
        Count = int.Parse(parts[2]);
    }

    public override void RecordEvent()
    {
        Count++;
    }

    public override bool IsComplete()
    {
        return false; // Eternal goals are never "complete"
    }
}
