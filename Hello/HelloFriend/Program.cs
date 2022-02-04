using HelloFriend.Handlers;
using HelloFriend.Helpers;

namespace HelloFriend
{
    class Program
    {
        //This is the entry point of our program. This is what is executed first to kick off the whole thing! 
        static void Main(string[] args)
        {
            while (true) //We want the user to always be asked for their name so that the program can operate over and over again without having to be re-ran. We are using a while look to do this
            {
                //Ask for the user's name and store this in a userInput variable 
                var userInput = new GetUserInputHandler(new ConsoleWriter()).AskForInput("Please enter your name and press enter"); 
                
                //Use the stored userInput variable and use it to say hello to the user.
                new SayHelloHandler(new ConsoleWriter()).SayHello(userInput);
            }
        }
    }
}
