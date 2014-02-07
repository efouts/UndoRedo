using NUnit.Framework;
using UndoRedo.Commands;

namespace UndoRedo.Tests
{
    [TestFixture]
    public class AddCommandTests
    {
        [Test]
        public void Do()
        {
            var number = new Number(1);
            var addCommand = new AddCommand(number, 1);
            addCommand.Do();

            Assert.That(number.Value, Is.EqualTo(2));
        }

        [Test]
        public void Undo()
        {
            var number = new Number(1);
            var addCommand = new AddCommand(number, 1);
            addCommand.Do();
            addCommand.Undo();

            Assert.That(number.Value, Is.EqualTo(1));
        }
    }
}
