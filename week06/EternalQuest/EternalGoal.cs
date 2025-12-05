namespace EternalQuest
{
    public class EternalGoal : Goal
    {
        public EternalGoal(string name, string description, int points)
            : base(name, description, points)
        {
            // Eternal goals have no completion status
        }

        public override int RecordEvent()
        {
            Console.WriteLine($"Goal '{ShortName}' recorded. You gained {Points} points!");
            return Points;
        }

        public override string GetStatusString()
        {
            return "[ ]";
        }

        public override string GetStringRepresentation()
        {
            return $"EternalGoal:{ShortName},{_description},{_points}";
        }
    }
}