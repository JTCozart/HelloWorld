using HelloFriend.Helpers;

namespace HelloFriend.Handlers
{
    public class SayHelloHandler
    {
        private readonly IConsoleWriter _consoleWriter; 
        //This is creating a console writer that the code will be using.
        //I could print directly to the console using Console.WriteLine()
        //but I want to make SURE that it is tested so I know my code is
        //printing the right thing to the console. 

        public SayHelloHandler(IConsoleWriter consoleWriter)
        {
            _consoleWriter = consoleWriter; 
            //I am setting the console writer to the instance that is passed in when this class is called
            //this will allow me to overwrite this with a mocked object for testing. 
        }

        public void SayHello(string text = "Friend")
        {
            //This is my main method. When I call this it will print "Hello [TEXT]!" or if the text is not provided
            //It will print "Hello Friend!
            if (string.IsNullOrEmpty(text)) //Check if the text is empty 
                text = "Friend";  // if empty set the text to "Friend" 
            
            _consoleWriter.Write($"Hello {text}!"); //Write Hello to the console 
        }
    }
}