using System;

namespace Classes
{
  static class ConsoleClass
  {
    static void Main(string[] _)
    {
      /* Console is a class in "System" namespace, which provided a set of properties and methods to perform I/O operations
       * in Console applications (Command-Prompt Applications). 
       * It is a static class. So all the members of "Console" class are accessible withou creating any object for de Console class
       * Is a part of BCL of .NetFramework
       * Write : It receives a value as parameter and displays the same values in console
       * WriteLine: It receives a value as parameter and displyas the same value in console and also moves the curso to the next line, after the value
       * ReadKey: It waits until the user presses any key on the keyboard. It makes the consele window wait for uses's input
       * Clear: It clears(make empty) the console. After clearing the screen, you can display output again using write methods
       * ReadLine: It accepts a string value from keyboard(entered by user) and returns the same. Always returns the value in string type only
       */
      Console.WriteLine("Console.WriteLine");
      Console.Write("Console.Write");
      string word = Console.ReadLine();
      Console.WriteLine(word);
      Console.ReadLine();
    }
  }
}
