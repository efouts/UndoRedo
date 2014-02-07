using System.Collections.Generic;
using System.Linq;

namespace UndoRedo
{
    public class UndoRedoCommandHandler
    {
        private Stack<Command> undo = new Stack<Command>();
        private Stack<Command> redo = new Stack<Command>();

        public void Do(Command command) 
        {
            command.Do();
            redo.Clear();
            undo.Push(command);
        }

        public void Undo() 
        {
            if (undo.Any() == false)
                return;
            
            var command = undo.Pop();
            command.Undo();
            redo.Push(command);            
        }

        public void Redo() 
        {
            if (redo.Any())
                redo.Pop().Do();
        }
    }
}
