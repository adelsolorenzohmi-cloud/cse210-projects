using System.IO;

namespace EternalQuest
{
    public class GoalManager
    {
        private List<Goal> _goals = new List<Goal>();
        private int _score = 0;

        private int _level = 1;
        private int _levelThreshold = 1000;

        private const string FILE_NAME = "goals.txt";

        public GoalManager()
        {
        }

        public void DisplayPlayerInfo()
        {
            Console.WriteLine("\n=================================================");
            Console.WriteLine($"Current Score: {_score} pts");
            Console.WriteLine($"Current Level: {_level} - ({_score} / {_levelThreshold} to next level)");
            Console.WriteLine("=================================================");
        }

        public void ListGoalDetails()
        {
            Console.WriteLine("\nYour Goals:");
            if (_goals.Count == 0)
            {
                Console.WriteLine("No goals currently created.");
                return;
            }
            for (int i = 0; i < _goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
            }
        }

        public void CreateGoal()
        {
            Console.WriteLine("The types of Goals are:");
            Console.WriteLine("  1. Simple Goal");
            Console.WriteLine("  2. Eternal Goal");
            Console.WriteLine("  3. Checklist Goal");
            Console.Write("Which type of goal would you like to create? ");
            string typeChoice = Console.ReadLine();

            Console.Write("What is the name of your goal? ");
            string name = Console.ReadLine();
            Console.Write("What is a short description of your goal? ");
            string description = Console.ReadLine();

            int points;
            Console.Write("What is the amount of points associated with this goal? ");
            while (!int.TryParse(Console.ReadLine(), out points) || points <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a positive whole number for points.");
                Console.Write("What is the amount of points associated with this goal? ");
            }

            switch (typeChoice)
            {
                case "1":
                    _goals.Add(new SimpleGoal(name, description, points));
                    break;
                case "2":
                    _goals.Add(new EternalGoal(name, description, points));
                    break;
                case "3":
                    int target;
                    Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                    while (!int.TryParse(Console.ReadLine(), out target) || target <= 0)
                    {
                        Console.WriteLine("Invalid input. Please enter a positive whole number for the target count.");
                        Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                    }

                    int bonus;
                    Console.Write("What is the bonus for accomplishing it that many times? ");
                    while (!int.TryParse(Console.ReadLine(), out bonus) || bonus < 0)
                    {
                        Console.WriteLine("Invalid input. Please enter a whole number (0 or greater) for the bonus.");
                        Console.Write("What is the bonus for accomplishing it that many times? ");
                    }

                    _goals.Add(new ChecklistGoal(name, description, points, bonus, target));
                    break;
                default:
                    Console.WriteLine("Invalid goal type.");
                    break;
            }
        }

        public void RecordEvent()
        {
            if (_goals.Count == 0)
            {
                Console.WriteLine("You must create goals before recording events.");
                return;
            }

            Console.WriteLine("The goals are:");
            for (int i = 0; i < _goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_goals[i].ShortName}");
            }

            Console.Write("Which goal did you accomplish? ");
            if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= _goals.Count)
            {
                int pointsGained = _goals[index - 1].RecordEvent();
                _score += pointsGained;
                CheckLevelUp(pointsGained);
            }
            else
            {
                Console.WriteLine("Invalid selection.");
            }
        }

        public void SaveGoals()
        {
            using (StreamWriter outputFile = new StreamWriter(FILE_NAME))
            {
                outputFile.WriteLine($"Score:{_score}");
                outputFile.WriteLine($"Level:{_level},{_levelThreshold}");

                foreach (Goal goal in _goals)
                {
                    outputFile.WriteLine(goal.GetStringRepresentation());
                }
                Console.WriteLine($"\nGoals successfully saved to {FILE_NAME}.");
            }
        }

        public void LoadGoals()
        {
            if (!File.Exists(FILE_NAME))
            {
                Console.WriteLine("\nNo previous goals file found. Starting fresh.");
                return;
            }

            _goals.Clear();
            string[] lines = File.ReadAllLines(FILE_NAME);

            foreach (string line in lines)
            {
                if (line.StartsWith("Score:"))
                {
                    _score = int.Parse(line.Split(':')[1]);
                    continue;
                }
                if (line.StartsWith("Level:"))
                {
                    string[] data = line.Split(':')[1].Split(',');
                    _level = int.Parse(data[0]);
                    _levelThreshold = int.Parse(data[1]);
                    continue;
                }

                string[] parts = line.Split(':');
                string goalType = parts[0];
                string[] details = parts[1].Split(',');

                Goal goal = null;
                string name = details[0];
                string description = details[1];
                int points = int.Parse(details[2]);

                switch (goalType)
                {
                    case "SimpleGoal":
                        bool isComplete = bool.Parse(details[3]);
                        goal = new SimpleGoal(name, description, points, isComplete);
                        break;
                    case "EternalGoal":
                        goal = new EternalGoal(name, description, points);
                        break;
                    case "ChecklistGoal":
                        int bonus = int.Parse(details[3]);
                        int target = int.Parse(details[4]);
                        int completed = int.Parse(details[5]);
                        goal = new ChecklistGoal(name, description, points, bonus, target, completed);
                        break;
                }

                if (goal != null)
                {
                    _goals.Add(goal);
                }
            }
            Console.WriteLine($"\nGoals and Score successfully loaded from {FILE_NAME}.");
        }

        private void CheckLevelUp(int pointsGained)
        {
            while (_score >= _levelThreshold)
            {
                _level++;
                _levelThreshold += 1000;
                Console.WriteLine($"\n🎉 LEVEL UP! You are now Level {_level}!");
                Console.WriteLine("=========================================");
            }
        }
    }
}