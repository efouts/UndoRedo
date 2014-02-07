using NUnit.Framework;
using UndoRedo.Commands;

namespace UndoRedo.Tests.Commands
{
    [TestFixture]
    public class MultiplicationCommandTests
    {
        [Test]
        public void Do()
        {
            var number = new Number(2);
            var command = new MultiplicationCommand(number, 3);
            command.Do();

            Assert.That(number.Value, Is.EqualTo(6));
        }

        [Test]
        public void Undo()
        {
            var number = new Number(2);
            var command = new MultiplicationCommand(number, 3);
            command.Do();
            command.Undo();

            Assert.That(number.Value, Is.EqualTo(2));
        }
    }
}
