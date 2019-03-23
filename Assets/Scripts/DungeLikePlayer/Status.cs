namespace Assets.Scripts
{
    public class Status
    {
        private int gold;

        public Status(int value, int maximum, int minimum)
        {
            Value = value;
            Maximum = maximum;
            Minimum = minimum;
        }

        public int Value { get; private set; }

        public int Maximum { get; private set; }

        public int Minimum { get; private set; }

        public virtual void AddValue(int valueToAdd)
        {
            Value += valueToAdd;
            if (Value > Maximum)
                Value = Maximum;
        }

        public virtual void RemoveValue(int valueToToRemove)
        {
            Value -= valueToToRemove;
            if (Value < Minimum)
                Value = Minimum;
        }
    }
}
