namespace UndoRedo
{
    public interface Command
    {
        void Do();
        void Undo();
    }
}
