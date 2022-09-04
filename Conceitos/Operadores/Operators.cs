using System;

namespace Operadores
{
    class Operators
    {
        static void Main(string[] _)
        {
            int a = 10;
            a += 15;
            a -= 5;
            a *= 2;
            a /= 2;
            a %= 2;
            a++;//Post incrementation(First it returns values, the incrementes)
            a--;//Post decrementation(First it returns values, the decrements)
            --a;//Pre decrementation(First it returns values, then decrements)
            ++a;//Pre incrementation(First it increments values, then returns)

            /* Comparison values: Used to compare two values and return true or false, based the condition
             * == equal to
             * != not equal to
             * < less then
             * > greater then
             * <= less than or equal to
             * >/ greater than or equal to
             * 
             * Logical: Check both operands(Boolean) and returns true or false
             * &: logical and(both operands should be true).Evaluates both operands, even if left-hand operando returns false
             * &&: conditional and(both operands should be true). Doesn't evaluate right-hand operando if left-hand operand returns false
             * |: logical or(at least any one operand should be true).Evaluates both operands, even if left-hand operand returns true
             * ||: Conditional Or(At least any one operand should be true). Doesn't evaluate right-hand operando if left-hand operand returns true
             * ^: logical exclusive OR - XOR (Any one operand only should be true) Evaluates both operands
             * !: Negation(true becomes false;false becomes true)
             * 
             * Concatenation Operator: Attaches seconde operand string at the end of first operando string and returns the combined string
             * 
             * Ternary Conditional: It evaluetes the given boolean value. Returns first expression(consequent) if true. Returns second expression (alternative)if false
             * ?:(condition)?consequent : alternative
             */
            Console.WriteLine(a);
        }
    }
}
