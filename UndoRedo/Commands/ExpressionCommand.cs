using System.Collections.Generic;
using System.Linq;

namespace UndoRedo.Commands
{
    public class ExpressionCommand : Command
    {
        private IEnumerable<Command> commands;

        public ExpressionCommand(params Command[] commands)
        {
            this.commands = commands;
        }

        public void Do()
        {
            foreach (var command in commands)
                command.Do();
        }

        public void Undo()
        {
            foreach (var command in commands.Reverse())
                command.Undo();
        }        
    }
}
