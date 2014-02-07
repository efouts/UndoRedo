using NUnit.Framework;
using UndoRedo.Commands;

namespace UndoRedo.Tests.Commands
{
    [TestFixture]
    public class ExpressionCommandBuilderTests
    {
        [Test]
        public void BuildShortExpression()
        {
            var number = new Number(2);
            var builder = new ExpressionCommandBuilder(number);
            var command = builder.Add(3).Multiply(3).Build();

            command.Do();

            Assert.That(number.Value, Is.EqualTo(15));
        }

        [Test]
        public void BuildLongExpression()
        {
            var number = new Number(2);
            var builder = new ExpressionCommandBuilder(number);
            var command = builder.Add(3).Multiply(3).Add(1).Multiply(2).Build();

            command.Do();

            Assert.That(number.Value, Is.EqualTo(32));
        }
    }
}
