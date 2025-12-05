namespace EternalQuest
{
    public class ChecklistGoal : Goal
    {
        private int _amountCompleted;
        private int _target;
        private int _bonusPoints;

        public ChecklistGoal(string name, string description, int points, int bonusPoints, int target, int completed = 0)
            : base(name, description, points)
        {
            _bonusPoints = bonusPoints;
            _target = target;
            _amountCompleted = completed;
        }

        public override int RecordEvent()
        {
            if (_amountCompleted < _target)
            {
                _amountCompleted++;
                int pointsEarned = Points;

                if (_amountCompleted == _target)
                {
                    pointsEarned += _bonusPoints;
                    Console.WriteLine($"\n*** CONGRATULATIONS! You fully completed the Checklist Goal: {ShortName}! ***");
                    Console.WriteLine($"You earned {Points} regular points plus a {_bonusPoints} bonus!");
                }
                else
                {
                    Console.WriteLine($"Goal '{ShortName}' recorded. You gained {Points} points. Progress: {_amountCompleted}/{_target}");
                }
                return pointsEarned;
            }
            Console.WriteLine($"The goal '{ShortName}' is already fully completed.");
            return 0;
        }

        public override string GetStatusString()
        {
            return _amountCompleted == _target ? "[X]" : "[ ]";
        }

        public override string GetDetailsString()
        {
            return $"{GetStatusString()} {ShortName} ({_description}) -- Currently Completed: {_amountCompleted}/{_target}";
        }

        public override string GetStringRepresentation()
        {
            return $"ChecklistGoal:{ShortName},{_description},{_points},{_bonusPoints},{_target},{_amountCompleted}";
        }
    }
}