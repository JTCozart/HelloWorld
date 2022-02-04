using System;

/*
 * This class is that simply wraps the console.write line methods.
 * It seems like extra work but I want to be able to test my code and ensure the right
 * thing is getting passed to the console.writeLine method. Because this is wrapped in an interface
 * I can now call ConsoleWriter.Verify() to make sure that the right string of text was logged to the console. 
 */

namespace HelloFriend.Helpers
{
    public interface IConsoleWriter
    {
        //an interface is a contract that ensure that other methods know to implement methods. Anything that uses the IConsoleWriter must implement Write and Read 
        void Write(string value); 
        string Read(); 
    }
    
    public class ConsoleWriter : IConsoleWriter
    {
        public void Write(string value)
        {
            Console.WriteLine(value); //Writes a line to the console 
        }

        public string Read()
        {
            return Console.ReadLine(); //Reads user input from the console and returns a string 
        }
    }
}