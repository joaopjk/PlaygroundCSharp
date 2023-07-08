namespace IOStream
{
    public class Program
    {
        /*
            Stream
        - Text streams: In a stream of text, one unit of data is one characther i.e. at a time we read or write a character or an array
        of characters. Here we should know the type of enconding before we can read characters from text stream. Based on the type of 
        enconding user number of bytes a character takes is decided and this remains fixed throughout the stream.
        - Binary streams: In a stream of binary, the unit of data is not fixes as it can be of any data type. The order of writing to
        the stream must be know so that in the same order we can read data from the stream.
            Categories of streams
        - Basic Stream
        - Character/Text Stream
        - Binary Stream

            System.IO
            Stream (abstract class):
        FileStream \ MemoryStream \ BufferedStream are inherited from Stream
        - Stream and its inherited classes provide us data in the form of bytes
        - These classes can be directly used only if the format of the data is not of any interest to required application
        - Theses objects are used as the core  on which another wrapper object has to be created bases on the format of the data in that
        stream. If the format is Text, StreamReader or StreamWriter must be used other BinaryReader or BinaryWriter must be used.
        - FileStream: It is used to read from, write to, and manipulate file-related operations. FileStream objects support random access
        to files using the Seek method. Seek allows the read/write position to be moved to any position within the file.
        - MemoryStream: It is a non-buffered stream whose encapsulated data is directly accessible in memmory. This stream has no backing
        store and might be useful as a temporary buffer. It uses byte array for managing data in memory.
        - BufferedStream: It is a stream that adds buffering to another stream such as a NetworkStream(FileStream already has buffering
        internally, and a MemoryStream does not need buffering). A BufferedStream can be composed around some types of streams in order
        to improve read and write performance.

            Character/ Text based stream
        - StreamReader reads characters from Streams, using encondig to convert characters to and from bytes. It has a constructor that
        attempts to ascertain what the correct Enconding for a given streams is, based on the presence of an Enconding-specific preamble,
        such as a byte order mark.
        - StreamWriter writes characters to streams, using Enconding to convert Characters to bytes. It reads characters from strings. It
        allows you to treat strings with the same api, so your output can be either a Stream in any enconding or a String.
        - BinaryStream and BinaryWrite read and write encoded strings and primitive data types from adn to a basic stream(stream category
        objects).
            - Console.In -- TextReader - By default reads from keyboard
            - Console.Out -- TextWriter - By default writes to Monitor
            - Console.Error -- TextWriter - By default writes to Monitor
        Methods of TextReader: Read, ReadBlock, ReadLine & ReadToEnd
        Methods of TextWriter: Write and WriteLine

            Note
        - In .NET we cannot directly read any particular type of data from the keyboard. We have to read keyboard input as string and 
        convert to appropriate tpye.
        - The above programs works good only with One Byte character set i.e. ASCII character set and below programs works with Unicode
        code char set and be used saving text of any language.
        - All collection objects are Serializable and hence we can many other serializable objects to them and persist them so that we
        can them back when needed.
            
            File Handling
        Most common constructor of FileStream(it has 15 overloaded forms)
        public FileStream(string path, FileMode mode, FileAccess access, FileShare share)
            - FileMode = CreateNew, Create, Open, OperOrCreate, Truncate, Append
            - File Access = Read, Write, ReadWrite
            - File Share = Read, Write, ReadWrite, Delete, None

        For reading a text file, the FileStream object must be encapsulated by StreamReader object. StreamReader based on the first two
        bytes of a file know the type of enconding used for saving data into the file and accordingly the "Read" method of it would read the
        character and retunr the integer form it(irrespective of the numbers of bytes the character is made up of).
        The Second parameter of StreamReader constructor i.e. the type of enconding used in the encapsulated stream is optional only if the
        two bytes of the encapsulated stream indentifies the type of enconding.

        Write method of BinaryWriter writes the parameter value to the stream is the same format as it would be stored in memory. The write
        method is overloaded for all the basica data types. Eg: The write method with Integer parameter writes 4 bytes to the stream.

            Work with File System
        In IO we have four more class wich is used for managing the file system on the machine. They are
        - File provides static methods for the creation, copying, deletion, moving, and openning of files, and aids in the creation of a 
        FileStream.
        - Direactory provides static methods for creating, moving, and enumerating through directories and subdirectories.
        - FileInfor provides instance methods for the creation, copying, deletion, moving, and opening of files, and aids in the creation of 
        FileStream objects. This class cannot be inherited
        - DirectoryInf provices instance methods for creating, moving, and enumerating through directories and subdirectories.
        So generally, when we want to perform more than one operation, we go FileInfor and DirectoryInfo. But for a given path if we want to
        perform only operation we go for File and Directory.

            Serialization
        It is a process in which the objects state can be converted to a stream/ any other form so that it can be either persisted in a
        file or transported over the network.
        The are two types of serialization: Binary Serialization & XML Serialization
        - In binary serialization all the instance data members expect the ones declared as <NonSerialized()> are serialized.
        - Im XML serialization only the Public instance members of a Public Class can be serialized.
        - Static/Shared members of the class not serialized.
         */
        static void Main(string[] _)
        {
            //while (true)
            //{
            //    int data = Console.In.Read(); // Read a character and give int value
            //    if(data == -1)
            //        break;
            //    //Console.Out.WriteLine(data);
            //    //Console.Out.WriteLine((char)data);
            //    Console.Out.Write((char)data);
            //}

            //int bufferSize = 5;
            //char[] buffer = new char[bufferSize];
            //int actualNoofCharsRead = Console.In.Read(buffer, 0, bufferSize);
            ////int actualNoofCharsRead = Console.In.ReadBlock(buffer, 0, bufferSize); // Force to input total size of buffer

            //Console.WriteLine(actualNoofCharsRead);

            //for (int i = 0;i < bufferSize;i++)
            //    Console.Out.Write(buffer[i]);

            //int n1,n2;

            //Console.Out.Write("Enter the value of first number: ");
            //n1 = int.Parse(Console.In.ReadLine());
            //Console.Out.Write("Enter the value of second number: ");
            //n2 = int.Parse(Console.In.ReadLine());

            //Console.WriteLine("Sum: " + (n1 + n2));

            //Console.WriteLine("Press any key to continue");
            //ConsoleKeyInfo ki = Console.ReadKey(true);
            //Console.WriteLine(ki.KeyChar);

            //Console.ReadKey();

            TextReader textReader = new StringReader("This is line 1\nThis is line2 \n");
            Console.SetIn(textReader);

            string stringFirstLine = textReader.ReadLine();
            string stringLastLine = textReader.ReadLine();

            TextWriter textWriter = new StringWriter();
            Console.SetOut(textWriter);

            Console.WriteLine(stringFirstLine);
            Console.WriteLine(stringLastLine);
        }
    }
}
