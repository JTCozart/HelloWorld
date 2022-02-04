using System;
using FluentAssertions;
using HelloFriend.Handlers;
using HelloFriend.Helpers;
using Moq;
using NUnit.Framework;

namespace HelloFriendTests.Handlers
{
    public class GetUserInputHandlerTests
    {
        private Mock<IConsoleWriter> _consoleWriter;
        private GetUserInputHandler _handler;

        [SetUp]
        public void SetupTest()
        {
            _consoleWriter = new Mock<IConsoleWriter>();
            _handler = new GetUserInputHandler(_consoleWriter.Object);
        }

        [Test]
        public void CanAskForUserInput()
        {
            _consoleWriter.Setup(x => x.Read()).Returns("Bob");

            var result = _handler.AskForInput("Please enter your name and press enter...");

            _consoleWriter.Verify(x => x.Write("Please enter your name and press enter..."));
            result.Should().Be("Bob"); 
        }

        [Test]
        public void ThrowsIfInputIsBlank()
        {
            var ex = Assert.Throws<Exception>(() => _handler.AskForInput(""));
            ex.Message.Should().Be("You must supply an input value to ask users"); 
        }
    }
}