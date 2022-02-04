using System;
using HelloFriend.Helpers;

namespace HelloFriend.Handlers
{
    public class GetUserInputHandler
    {
        private readonly IConsoleWriter _consoleWriter; 
        //This is creating a console writer that the code will be using.
        //I could print directly to the console using Console.WriteLine()
        //but I want to make SURE that it is tested so I know my code is
        //printing the right thing to the console. 

        public GetUserInputHandler(IConsoleWriter consoleWriter)
        {
            _consoleWriter = consoleWriter;
            //I am setting the console writer to the instance that is passed in when this class is called
            //this will allow me to overwrite this with a mocked object for testing. 
        }

        public string AskForInput(string input)
        {
            //It is important that we supply an input. So if an engineer uses this method and supplies and empty string 
            // the next two lines here will throw and exception and the program will fail
            if (string.IsNullOrEmpty(input))
                throw new Exception("You must supply an input value to ask users"); 
            
            _consoleWriter.Write(input); //ask for user input
            return _consoleWriter.Read(); // Read the input that the user writes and save it to a string that can be returned for other methods to use
        }
    }
}