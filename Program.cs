using System;

namespace CalculatorRPN
{
    class Program
    {

        /*

        Try to use Console.ReadKey();
        How to do a "Last" function?   
        What's the simplest way to handle too few arguments error?

        */

        static void Main(string[] args) // This was here from the beginning and the program works, so they are left. Because why break something by acting while still ignorant?

        {
            int stackDepth = 0; // Haven't figured out how to intitialize this counter when the first actual instance happens
            double[] theStack = new double[] { 0, 0, 1, 2, 3, 4, 5, 6, 7, 0, 0, 0 }; // Haven't figured out how to work with a dynamic stack of numbers, with no limit to how many numbers the user can enter and that could be initialized when numbers are entered.
            bool continueEntering = true;

            Console.Clear(); // Problem here – doesn't manage to get this to clear the window fully from previous entries
            Console.WriteLine("10:\n9:\n8:\n7:\n6:\n5:\n4:\n3:\n2:\n1:");

            do
            {

                var operands = GetOperands(theStack, stackDepth); // This line caused problems when the stack was empty – two extra items were added to the array "theStack", below line 1
                
                string userEntry = Console.ReadLine();

                switch (userEntry)
                {
                    case "+":
                        theStack[stackDepth] = MathTwoOperands(operands.number1, operands.number2, 1, stackDepth);
                        break;

                    case "/":
                        theStack[stackDepth] = MathTwoOperands(operands.number1, operands.number2, 2, stackDepth);
                        break;

                    case "*":
                        theStack[stackDepth] = MathTwoOperands(operands.number1, operands.number2, 3, stackDepth);
                        break;

                    case "-":
                        theStack[stackDepth] = MathTwoOperands(operands.number1, operands.number2, 4, stackDepth);
                        break;

                    case "drop":
                        stackDepth--;
                        break;

                    case "swap":
                        double tempValue = theStack[stackDepth + 1];
                        theStack[stackDepth + 1] = theStack[stackDepth];
                        theStack[stackDepth] = tempValue;
                        break;

                    default:
                        try
                        {
                            double numberEntry = Double.Parse(userEntry);
                            theStack[stackDepth] = numberEntry;
                            stackDepth++;
                            Console.Clear();
                            WriteLineNumbers(theStack, stackDepth);

                        }
                        catch (FormatException)
                        {
                            continueEntering = false;
                        }
                        break;
                }

                WriteLineNumbers(theStack, stackDepth);

            } while (continueEntering);



            /*
        
                if (stackDepth > 9) // theStack[] array is limited to 10 elements
                {
                    LimitReached();
                }
            } while (continueEntering);

        }
        */

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
            /*
        static void LimitReached()
        {
            string userEntry = Console.ReadLine();
            Console.WriteLine(userEntry);
        }

        */

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

        static (double number1, double number2) GetOperands(double[] numberList, int postsEntered) // Googled on return of multiple values and ended up here: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/value-tuples
         {
            double number1 = numberList[postsEntered + 1];
            double number2 = numberList[postsEntered];
            return (number1, number2);
         }

        static double MathTwoOperands(double num1, double num2, int kind, int postsEntered)
            {
                if (postsEntered > 1)
                {
                    postsEntered--;
                    switch (kind)
                    {
                        case 1:
                            double outcome = Addition(num1, num2);
                            break;

                        case 2:
                            double outcome = Division(num1, num2);
                            break;

                        case 3:
                            double outcome = Multiplication(num1, num2);
                            break;

                        case 4:
                            double outcome = Subtraction(num1, num2);
                            break;

                        default:
                            break;
                    } } else
                {
                    Console.WriteLine("Error – Too Few Arguments");
                    double outcome = num1;
                     }
                        return outcome;
            }
        }
    }
}