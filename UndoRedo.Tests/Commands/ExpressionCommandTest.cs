using NUnit.Framework;
using UndoRedo.Commands;

namespace UndoRedo.Tests.Commands
{
    [TestFixture]
    public class ExpressionCommandTest
    {
        [Test]
        public void Do()
        {
            var number = new Number(2);
            var addCommand = new AddCommand(number, 3);
            var multiplicationCommand = new MultiplicationCommand(number, 3);
            var expressionCommand = new ExpressionCommand(addCommand, multiplicationCommand);

            expressionCommand.Do();

            Assert.That(number.Value, Is.EqualTo(15));
        }

        [Test]
        public void Undo()
        {
            var number = new Number(2);
            var addCommand = new AddCommand(number, 3);
            var multiplicationCommand = new MultiplicationCommand(number, 3);
            var expressionCommand = new ExpressionCommand(addCommand, multiplicationCommand);

            expressionCommand.Do();
            expressionCommand.Undo();

            Assert.That(number.Value, Is.EqualTo(2));
        }
    }
}
