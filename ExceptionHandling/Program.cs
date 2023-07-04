namespace ExceptionHandling
{
    /*
        Understanding Exceptions
    - Exception is a runtime error and the reason could be either because of some software error or limitations of hardware.
    - In .Net, every exception is an object of type System.Exception or any of its sub class
    - Exception is an object because it can encapsulate all the data required for properly handling an exception in catch block
    - Whenever the integrity of an object is violated, exception is throw
    - Exception handling is done by providing try...catch blocks.
    - For one try we can have multiple catch blocks and each catch block can be used as an excpetion handler for particular type of 
    exception
    - A try block can have any number of catch blocks but only one catch blocks is executed if an exception is throw i.f. the first 
    matching catch block exception
    - For given try, the catch block of parent class must be always after the catch block child class
    - If an exception thrown and is unhandled in an inner block then it is automatically thrown to its outer block
    - If an exception thrown in the called method and if it unhandled in the called method then the exception is automatically thrown to
    its calling method
    - If the excpetion occurs in Main function and is unhandled the CLR handles it and the program is terminated

        Important Note
    - Do prefer using an empty throw when catching and re-throwing an exception. This is the best way to preserve the exception call stack

        Finally Block
    - If the code execution enters try then it is 100% quaranteed that it would also execute finally block(even if the try block has return
    statement)
    - If "finally" block, you cannot use goto or return statements
    - There can be be only one "finally" block per try block and it must be the last block after all catch blocks(if present)

        User-defined/Custom Exception Class
    - Every used defined exception class inherits from System.Exception of any of its subclass
    - Mostly the exception class ahs read only filed members or properties and the are initialized in the constructor of the class
    - Message should be the first parameter in our constructor and same must be passed to the parent class constuctor 
    - Do provide(at least) the commom constructor on all exceptions(as given in example). Make sure the names and types of the parameters
    are the same those used in the following code example
    - Do make exceptions serializable. An exception must be serializable to work correctly across application domain and remoting boundaries
     */
    internal class Program
    {
        static void Main(string[] args)
        {
            int n1 = int.Parse(args[0]);
            int n2 = int.Parse(args[1]);
            int res = Divide(n1, n2);
            Console.WriteLine(res);
        }

        private static int Divide(int n1, int n2)
        {
            try
            {
                return n1 / n2;
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Attempted to divide by zero.");
                return int.MinValue;
                //throw;
            }
            catch (FormatException)
            {
                Console.WriteLine("Please provide only numbers as inputs");
                throw;
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Please provide proper command line inputs!");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}