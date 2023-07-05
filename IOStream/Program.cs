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
         */
        static void Main(string[] _)
        {

        }
    }
}
