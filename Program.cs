using System;

namespace CalculatorRPN
{
    class Program
    {


        static void Main(string[] args) // This was here from the beginning and the program works, so they are left. Because why break something by acting while still ignorant?

        {
            int stackDepth = 0; // Haven't figured out how to intitialize this counter when the first actual instance happens
            double[] theStack = new double[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }; // Haven't figured out how to work with a dynamic stack of numbers, with no limit to how many numbers the user can enter and that could be initialized when numbers are entered.
            bool continueEntering = true;

           
            do
            {
                Console.Clear();
                WriteLineNumbers(theStack, stackDepth);

                string userEntry = Console.ReadLine();

                bool twoOperandCommands = userEntry.Contains("+") || userEntry.Contains("-") || userEntry.Contains("/") || userEntry.Contains("*") || userEntry.Contains("swap");
                bool oneOperandCommands = userEntry.Contains("drop") || userEntry.Contains("root") || userEntry.Contains("sqr") || userEntry.Contains("sin") || userEntry.Contains("cos") || userEntry.Contains("tan") || String.IsNullOrEmpty(userEntry);

                if (stackDepth < 2 && twoOperandCommands)
                {
                    Console.WriteLine("Error – Too Few Arguments");
                    System.Threading.Thread.Sleep(2300);
                }
                else if (stackDepth < 1 && oneOperandCommands)
                {
                    Console.WriteLine("Error – Too Few Arguments");
                    System.Threading.Thread.Sleep(2300);
                }
                else
                {

                    switch (userEntry)
                    {
                        case "+":
                            theStack[stackDepth - 2] = Addition(theStack[stackDepth - 2], theStack[stackDepth - 1]);
                            stackDepth--;
                            break;

                        case "/":
                            theStack[stackDepth - 2] = Division(theStack[stackDepth - 2], theStack[stackDepth - 1]);
                            stackDepth--;
                            break;

                        case "*":
                            theStack[stackDepth - 2] = Multiplication(theStack[stackDepth - 2], theStack[stackDepth - 1]);
                            stackDepth--;
                            break;

                        case "-":
                            theStack[stackDepth - 2] = Subtraction(theStack[stackDepth - 2], theStack[stackDepth - 1]);
                            stackDepth--;
                            break;

                        case "sqr":
                            theStack[stackDepth - 1] = Math.Pow(theStack[stackDepth - 1], 2);
                            break;

                        case "root":
                            theStack[stackDepth - 1] = Math.Sqrt(theStack[stackDepth - 1]);
                            break;

                        case "sin":
                            theStack[stackDepth - 1] = Math.Sin(theStack[stackDepth - 1]);
                            break;

                        case "cos":
                            theStack[stackDepth - 1] = Math.Cos(theStack[stackDepth - 1]);
                            break;

                        case "tan":
                            theStack[stackDepth - 1] = Math.Tan(theStack[stackDepth - 1]);
                            break;

                        case "drop":
                            stackDepth--;
                            break;

                        case "swap":
                            double tempValue = theStack[stackDepth - 1];
                            theStack[stackDepth - 1] = theStack[stackDepth - 2];
                            theStack[stackDepth - 2] = tempValue;
                            break;

                        case "":
                            if (stackDepth > 9)
                            {
                                Console.WriteLine("Error – Only Ten Numbers Total");
                                System.Threading.Thread.Sleep(2300);
                            }   else  {
                                theStack[stackDepth] = theStack[stackDepth - 1];
                                stackDepth++;
                            }
                            break;

                        case "?":
                            Console.WriteLine("+  -  *  /  sqr  root  sin  cos  tan  drop  swap  quit\nPress any key to continue");
                            Console.ReadKey();
                            break;

                        case "quit":
                            continueEntering = false;
                            break;

                        default:

                            if (stackDepth > 9)
                            {
                                Console.WriteLine("Error – Only Ten Numbers Total");
                                System.Threading.Thread.Sleep(2300);
                            }
                            else
                            {
                                try
                                {
                                    theStack[stackDepth] = Double.Parse(userEntry);
                                    stackDepth++;
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Error – Invalid Operation");
                                    System.Threading.Thread.Sleep(2300);
                                }
                            }
                            break;
                    }
                }
                
            } while (continueEntering);


            static void WriteLineNumbers(double[] value, int postsEntered)
            {
                Console.WriteLine("For a list of actions, press ?");
                for (int i = 10; i > postsEntered; i--)
                {
                    Console.WriteLine(i + ":");
                }
                for (int i = postsEntered; i > 0; i--)
                {
                    Console.WriteLine(i + ":   " + value[postsEntered - i]); // Oldest entry should go highest in the console list, therefore the "postsEntered - 1"
                }
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
        }
    }
}
 