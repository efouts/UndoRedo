using System;
using NUnit.Framework;
using UndoRedo.Commands;

namespace UndoRedo.Tests
{
    [TestFixture]
    public class UndoRedoCommandHandlerTests
    {
        private Number number;
        private UndoRedoCommandHandler numberCruncher;

        [SetUp]
        public void Setup()
        {
            number = new Number(1);
            numberCruncher = new UndoRedoCommandHandler();
        }

        [Test]
        public void CanDoACommand()
        {
            Add(1);
            Assert.That(number.Value, Is.EqualTo(2));
        }

        [Test]
        public void CannotUndoIfNothingHasBeenDone()
        {
            numberCruncher.Undo();
            Assert.That(number.Value, Is.EqualTo(1));
        }

        [Test]
        public void CanUndoACommand()
        {
            Add(1);
            numberCruncher.Undo();
            Assert.That(number.Value, Is.EqualTo(1));
        }

        [Test]
        public void CannotRedoIfNothingHasBeenUndone()
        {
            Add(1);
            Add(2);
            Add(3);
            numberCruncher.Redo();

            Assert.That(number.Value, Is.EqualTo(7));
        }

        [Test]
        public void CanUndoThenRedoACommand()
        {
            Add(1);
            numberCruncher.Undo();
            numberCruncher.Redo();

            Assert.That(number.Value, Is.EqualTo(2));
        }

        [Test]
        public void CanUndoMultipleCommands()
        {
            Add(1);
            Add(2);
            Add(3);

            numberCruncher.Undo();
            numberCruncher.Undo();
            numberCruncher.Undo();

            Assert.That(number.Value, Is.EqualTo(1));
        }

        [Test]
        public void CanUndoMultipleThenRedoMultipleCommands()
        {
            Add(1);
            Add(2);
            Add(3);

            numberCruncher.Undo();
            numberCruncher.Undo();
            numberCruncher.Undo();

            numberCruncher.Redo();
            numberCruncher.Redo();
            numberCruncher.Redo();

            Assert.That(number.Value, Is.EqualTo(7));
        }

        [Test]
        public void CannotRedoAfterDoing()
        {
            Add(1);
            Add(2);
            Add(3);

            numberCruncher.Undo();
            numberCruncher.Undo();
            numberCruncher.Undo();

            Add(4);

            numberCruncher.Redo();

            Assert.That(number.Value, Is.EqualTo(5));
        }

        private void Add(Int32 amount)
        {
            var command = new AddCommand(number, amount);
            numberCruncher.Do(command);
        }
    }
}
