namespace EternalQuest
{
    public class SimpleGoal : Goal
    {
        private bool _isComplete;

        public SimpleGoal(string name, string description, int points, bool isComplete = false)
            : base(name, description, points)
        {
            _isComplete = isComplete;
        }

        public override int RecordEvent()
        {
            if (!_isComplete)
            {
                _isComplete = true;
                Console.WriteLine($"Congratulations! You have completed the Simple Goal: {ShortName}");
                return Points;
            }
            Console.WriteLine($"The goal '{ShortName}' is already complete.");
            return 0;
        }

        public override string GetStatusString()
        {
            return _isComplete ? "[X]" : "[ ]";
        }

        public override string GetStringRepresentation()
        {
            return $"SimpleGoal:{ShortName},{_description},{_points},{_isComplete}";
        }
    }
}