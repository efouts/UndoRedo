using System;
using System.Collections.Generic;

namespace UndoRedo.Commands
{
    public class ExpressionCommandBuilder
    {
        private Number number;
        private List<Command> commands;

        public ExpressionCommandBuilder(Number number)
        {
            this.number = number;
            commands = new List<Command>();
        }

        public ExpressionCommandBuilder Add(Int32 amount)
        {
            commands.Add(new AddCommand(number, amount));
            return this;
        }

        public ExpressionCommandBuilder Multiply(Int32 amount)
        {
            commands.Add(new MultiplicationCommand(number, amount));
            return this;
        }

        public Command Build()
        {
            return new ExpressionCommand(commands.ToArray());
        }
    }
}
