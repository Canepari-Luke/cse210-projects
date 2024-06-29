public class ChecklistGoal : Goal
{
    public int CurrentCount { get; set; }
    public int TargetCount { get; set; }
    public int BonusPoints { get; set; }
    public bool IsCompleted { get; set; }

    public override string Serialize()
    {
        return $"ChecklistGoal:{Name},{Points},{CurrentCount},{TargetCount},{BonusPoints},{IsCompleted}";
    }

    public override void Deserialize(string data)
    {
        var parts = data.Split(',');
        Name = parts[0];
        Points = int.Parse(parts[1]);
        CurrentCount = int.Parse(parts[2]);
        TargetCount = int.Parse(parts[3]);
        BonusPoints = int.Parse(parts[4]);
        IsCompleted = bool.Parse(parts[5]);
    }

    public override void RecordEvent()
    {
        CurrentCount++;
        if (CurrentCount >= TargetCount)
        {
            IsCompleted = true;
        }
    }

    public override bool IsComplete()
    {
        return IsCompleted;
    }
}
