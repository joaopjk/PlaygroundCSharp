namespace AssembliesGAC
{
    /*
        Dynamic Linking Library
    - A DLL ins application which can have everything what an EXE can have. The differecen between them is, an EXE can execute
    independently but DLL cannot. The code in the DLL can be reused in many other application but the code in EXE cannot be reused.
    Types of DLL in Windows OS:
    - Win32 DLL: Here the code is available in the form of simple "C" functions.
    - COM DLL: This DLL have code in the form of reusable COM components. These are also referred as ActiveX DLL
    - .NET DLL: These DLL's(Portable Executable) are used for distribuiting the reusable classes to varius types of .Net app's.
    Note:
    - The Portable Executable (PE) format is a file format for executables, object code, DLLs, FON font files and others user in 
    32-bit and 64-bit versions of Windows operating systems.
    - PE is a modified version of the UNIX COFF file format. PE/COFF is an alteranative term in Windows Development.
    - Microsoft's .Net Framework has extended the PE format with features which support the Common Language Runtime(CLR).
    - The CLR section of it containes two important segments: Metadate and Intermediate Language(IL) code.

        Assembly in .Net
    An assembly is a collection of types(classes, interface, struct etc) and resources(bmp, jpg, string table, txt, ico) that are
    built to work together and form a logical unit of functionality. An assembly provides the common language runtime with the 
    information it needs to be aware of type implementations. To the runtime, a tpye does not exists outside the context of an
    assembly. Assemblies are a fundamental part of programming with the .NET Framework.
    - It contains code that the common language runtime executes.
    - It forms a security boundary
    - It forms a type boundary
    - It forms a reference scope boundary
    - If forms a version boundary
    - It forms a deployment unit
    - It is unit at wich side-by-side execution is supported

        Assembly Manifest Content
    - Assembly Name
    - Version Number 
    - Cultere
    - Strong name information
    - List of all files in an assembly
    - Type reference information of types exported from assembly
    - Information about other referenced assemblies

        About namespaces
    - A namespace is a logical collection of classes and other types with unique names. In a giver namespace all the types have
    unique name and thus it is uses to resolved the ambiguity in case of name conflict
    - Any type when used outside the namespace, it must be qualified by its namespace, but when used by another type within the 
    same namespace it need not be qualified by the namespace.
    - We can use using Namespace on top of the file so that we don't have to qualify all the types of that namespace in that file
    explicitly.

        Internal Access Specifier
    - A public Class is accessible within and outsise the assembly. Whereas an internal class can be accessed only by other types
    within the same assembly(irrespective of the namespace of other classes within the assembly).
    - Internal is the default access specifier for the class.
    - Top level class can only be declared as either public of internal but nested class(a class within class) can have any access
    modifier.
    - Namespace can never be used as a boundary for an access specifier. It's used only as a name qualifier.
    - A member of a class is accesible to all types within the same assembly and is not accessible outside the assembly.
    - A member declared as "protected internal" is accessible to all the class with in with the assembly and only to be derived
    classes outside the assembly.
    - A public method of a public class cannot have either as parameter or return any data types of the same assembly which is not
    public(or is internal).

        Types of Assemblies
    - Private Assemblies: An assembly whose local copy is maintaned by each & every application referencing to it.
    - Shared Assembly: An assembly whose single copy deployed in Global Assembly Cache(GAC) and use/shared by many applications 
    running on that machine. Such assemblies must have strong name.
    - Satellite Assembly: A resource only assembly for a given culture is called as satellite assemlby. The don't have any code but
    they have only resources like string tables and images.
    - Dynamic Assemblies: These run direclty from memory and are not saved to disk before execution. You can save dynamic assemblies
    to disk after they have executed. The API method Reflection.Emit is used to create dynamic assemblies.

        Working with GAC
    Each computer where the common language runtime is installed has a machine-wide code cache called the global assembly cache. The
    global assembly cache stores assemblies specifically designated to be share by several applications on the computer. 
    There are scenarios where you explicitly do not want to install an assembly into the global assembly cache. If you place one
    of the assemblies that make up an application in the global assembly cache, you can no longer replicate or install the 
    application by using the xcopy command to copy the application directory. You must move the assemly in the global assembly cache
    as well.

    There are several ways to deploy an assembly into the global assembly cache.
    - Use an installer designed to work the global assembly cache. This is the preferred option for installing assemblies into the
    global assembly cache.
    - Use a developer tool called the Global Assembly Cache tool( Gacuitl.exe), provided by the .Net Framework SDK.
    - Use Windows Explorer to drag assemblies into the cache(Not Recommended).

        Notes
    - In deployment scenarios use Windows Installer 2.0 to install assemblies into the global assembly cache.
    - Use Windows Explorer or the Global Assembly Cache tool only in development scenarios, because they do not provide assembly
    reference couting and other features provided when using the Windows Installer
    - You will ned admin privileged used can install or delete assemblies in GAC.
    - You can ensure that a name of assembly is globally unique by signing am assembly with a strong name

    SNK.EXE is the tool used by VS.NET to generate SNK file which contains both Public and Private Key(Digital Signature)
     */
    internal class Program
    {
        static void Main(string[] _)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}