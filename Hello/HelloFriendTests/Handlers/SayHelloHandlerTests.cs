using HelloFriend.Handlers;
using HelloFriend.Helpers;
using Moq;
using NUnit.Framework;

/*
 * This is my test class for the SayHelloHandler
 * This will make SURE that when I write new code I am not breaking existing code and that the
 * previously written code is working as expected. I follow TDD (Test driven development) so that means that
 * I will not write any code without first writing a failing unit test. This means that when the test passes
 * I know that my code is working correctly. 
 */

namespace HelloFriendTests.Handlers
{
    public class SayHelloHandlerTests
    {
        private Mock<IConsoleWriter> _consoleWriter; //This is a mocked console writer so that I can verify that my code is outputting to this correctly
        private SayHelloHandler _handler; //This is the main class that I am testing. This is where my code will live

        [SetUp]
        public void Setup()
        {
            _consoleWriter = new Mock<IConsoleWriter>(); //I am making a new console writer that I can control 
            _handler = new SayHelloHandler(_consoleWriter.Object); // I am making a new handler that I will be calling to test
        }

        [Test]
        public void WritesCustomHelloMessageWhenStringIsPassed()
        {
            //This is my first unit test. I want to know that when I call my handler with a string (some random text)
            //it will print "Hello [TEXT]" This should be obvious as a part of the test name but I am making this comment 
            // to ensure that someone new to code knows what is going on. Normally I would not have comments here. 
            _handler.SayHello("Jake");

            _consoleWriter.Verify(x => x.Write("Hello Jake!"));
        }
        
        [Test]
        public void WritesHelloFriendIfNoStringIsPassed()
        {
            _handler.SayHello();
            
            _consoleWriter.Verify(x => x.Write("Hello Friend!"));
        }

        [Test]
        public void WritesHelloFriendIfEmptyStringIsPassed()
        {
            _handler.SayHello("");
            
            _consoleWriter.Verify(x => x.Write("Hello Friend!"));
        }

        
        /*
         * Notice the way the tests are laid out. There is a line space between the tested object (_handler) and the
         * verify object (_consoleWriter). This is intentional. It follows the coding style of setup, test, assert.
         * Each section is broken by a line break so that we know what we are doing at a glace. This makes the code
         * easier to read.
         *
         * setup stuff
         * setup someMoreStuff
         *
         * Test
         *
         * Verify stuff 
         * 
         */
    }
}