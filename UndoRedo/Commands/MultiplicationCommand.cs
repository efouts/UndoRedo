using System;

namespace UndoRedo.Commands
{
    public class MultiplicationCommand : Command
    {
        private Number number;
        private Int32 amount;

        public MultiplicationCommand(Number number, Int32 amount)
        {
            this.number = number;
            this.amount = amount;
        }

        public void Do()
        {
            number.Multiply(amount);   
        }

        public void Undo()
        {
            number.Divide(amount);
        }
    }
}
