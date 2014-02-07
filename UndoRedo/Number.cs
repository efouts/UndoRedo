using System;

namespace UndoRedo
{
    public class Number
    {
        public Int32 Value { get; private set; }

        public Number(Int32 initialState)
        {
            Value = initialState;
        }

        public void Add(Int32 amount)
        {
            Value = Value + amount;
        }

        public void Subtract(Int32 amount)
        {
            Value = Value - amount;
        }

        public override string ToString()
        {
            return Value.ToString();
        }

        public void Multiply(Int32 amount)
        {
            Value = Value * amount;
        }

        public void Divide(Int32 amount)
        {
            Value = Value / amount;
        }
    }
}
