namespace EternalQuest
{
    public abstract class Goal
    {
        protected string _shortName;
        protected string _description;
        protected int _points;

        public string ShortName => _shortName;
        public int Points => _points;

        public Goal(string name, string description, int points)
        {
            _shortName = name;
            _description = description;
            _points = points;
        }

        public abstract int RecordEvent();

        public abstract string GetStatusString();

        public virtual string GetDetailsString()
        {
            return $"{GetStatusString()} {_shortName} ({_description})";
        }

        public abstract string GetStringRepresentation();
    }
}