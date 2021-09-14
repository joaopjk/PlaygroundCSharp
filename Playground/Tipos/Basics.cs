using System;

namespace Tipos
{
    public class Basics
    {
        static void Main(string[] _)
        {
            sbyte sb = 100; //-128 a 127 SByte
            short sh = 100;// Int16
            int inteiro = 100;//Int32
            long longo = 10000;//Int64
            byte by = 1;//Byte
            ushort us = 1; //Uint16
            uint ui = 1; //Uint32
            ulong ul = 10000; // Uint64
            float fl = 2.64f;//Single
            double dl = 4.45;//Double
            decimal dc = 0;// Decimal
            char c = 'a';//Char
            char letra = '\u0041';// é possível utilizar a tabela Unicode para declarar variáveis do tipo char
            bool bo = true;//Boolean

            Console.WriteLine(sb);
            Console.WriteLine(sh);
            Console.WriteLine(inteiro);
            Console.WriteLine(longo);
            Console.WriteLine(by);
            Console.WriteLine(us);
            Console.WriteLine(ui);
            Console.WriteLine(ul);
            Console.WriteLine(fl);
            Console.WriteLine(dl);
            Console.WriteLine(dc);
            Console.WriteLine(c);
            Console.WriteLine(letra);
            Console.WriteLine(bo);
            /* Restriçoes para nome de variáveis
             * - Não pode começar com dígito: use lebra ou _
             * - Não usar acentos
             * - Não pode ter espaçõ em branco
             * - Use nomes que tenham nome explicativo
             * 
             * Camel Case: lastName( parâmetros de métodos, variáveis dentro de métodos
             * Pascal Case: LastName( namespace, classe, propriedades e métodos)
             * Padrão _lastName(atributos "internos" de da classe)
             */

            /* Variable is a named memory location in RAM, to store a particular type of value, during the program execution
             * All variables will be stored in Stack
             * For every method call, a new "Stack" will be created
             * The variable's value can be changed any number of times
             * The varialbes must be declared before its usage
             * The variables must be initialized before reading its value
             * Variable's data type should be specified while declaring the variable. It can't be changed later
             * The stack(along with its variable) will be deleted automatically, at the end of method execution
             * 
             * Type: specifies what type of value to be stored in memory
             * 
             * Primitive Type:
             * - Strictly stores single value
             * - Are basic building blocks of non-primitives types
             * 
             * Non-Primitive Types:
             * - Stors one or more values
             * - Usually contains multiple members
             */
        }
    }
}
