namespace Assets.Scripts
{
    public class Status
    {
        public int Value { get; set; }

        public int Maximum { get; set; }

        public int Minimum { get; set; }

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
