using System;

namespace CalculatorRPN
{
    class Program
    {
        static void Main(string[] args)

        {
            double numberEntry;
            int stackDepth = 0;
            double[] theStack = new double[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            bool continueEntering = true;

            Console.Clear();
            Console.WriteLine("10:\n9:\n8:\n7:\n6:\n5:\n4:\n3:\n2:\n1:");

            do
            {
                string userEntry = Console.ReadLine();

                try
                {
                    numberEntry = Double.Parse(userEntry);
                    theStack[stackDepth] = numberEntry;
                    stackDepth++;
                    Console.Clear();
                    WriteLineNumbers(theStack, stackDepth);
                    
                }
                catch (FormatException)
                {
                    continueEntering = false;
                }
                if (stackDepth > 9) // theStack[] array is limited to 10 elements
                {
                    LimitReached();
                }
            } while (continueEntering);

        }

        static void WriteLineNumbers(double[] value, int postsEntered)
        {
            for (int i = 10; i > postsEntered; i--)
            {
                Console.WriteLine(i + ":");
            }
            for (int i = postsEntered; i>0; i--)
            {
                Console.WriteLine(i + ":   " + value[postsEntered - i]); // Oldest entry should go highest in the console list, therefore the "postsEntered - 1"
            }
        }

        static void LimitReached()
        {
            string userEntry = Console.ReadLine();
            Console.WriteLine(userEntry);
        }

        static double Multiplication(double number1, double number2)
        {
            double product = number1 * number2;
            return product;
        }

        static double Addition(double number1, double number2)
        {
            double sum = number1 + number2;
            return sum;
        }

        static double Subtraction(double number1, double number2)
        {
            double difference = number1 - number2;
            return difference;
        }

        static double Division(double number1, double number2)
        {
            double quotient = number1 / number2;
            return quotient;
        }

        static void Drop()
        {

        }

        static void Swap()
        {

        }

    }
}
