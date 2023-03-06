using System;

namespace QuadraticEquationCalculator
{
    class Program
    {
        static QuadraticEquationCalculator cal = new QuadraticEquationCalculator();
        static int a, b, c, delta;

        static void Main()
        {
            Console.Title = "Quadratic Equation Calculator";

            while (true)
            {
                GetValues();
                GetAnswers();

                RestartProgram();
            }
        }

        static void GetValues()
        {
            try
            {
                Console.Write("Enter the value of a: ");
                a = Convert.ToInt32(Console.ReadLine());

                if (a == 0)
                    throw new ArithmeticException();

                Console.Write("Enter the value of b: ");
                b = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter the value of c: ");
                c = Convert.ToInt32(Console.ReadLine());
            }
            catch (ArithmeticException)
            {
                RestartInputs("\n[Error] 'a' cannot be zero.");
                GetValues();
            }
            catch
            {
                RestartInputs("\n[Error] Invalid number entered, please enter integers only.");
                GetValues();
            }
        }

        static void GetAnswers()
        {
            delta = cal.GetDelta(a, b, c);
            Console.WriteLine("\nDelta = {0}\n\n", delta);

            if (delta < 0)  // Negative delta
            {
                Console.WriteLine("* Since delta is negative, this equation does not have any answers.");
            }
            else if (delta == 0)  // Delta = 0
            {
                Console.WriteLine("1 Answer:");
                Console.WriteLine("  x = {0}", cal.GetAnswer(a, b, delta, true));
            }
            else  // Positive delta
            {
                Console.WriteLine("2 Answers:");
                Console.WriteLine("  x = {0}", cal.GetAnswer(a, b, delta, true));
                Console.WriteLine("  x = {0}", cal.GetAnswer(a, b, delta, false));
            }
        }

        static void RestartProgram()
        {
            Console.WriteLine("\nPress 'ESC' to exit, or any other key to calculate another equation...");

            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.Escape:
                    Environment.Exit(0);
                    break;

                default:
                    Console.Clear();
                    break;
            }
        }

        static void RestartInputs(string message)
        {
            Console.WriteLine(message);
            Console.WriteLine("Press any key to try again...");

            Console.ReadKey(true);
            Console.Clear();
        }
    }

    class QuadraticEquationCalculator
    {
        public int GetDelta(int a, int b, int c)
        {
            return (b * b) - 4 * (a * c);
        }

        public double GetAnswer(int a, int b, int delta, bool getPositive)
        {
            if (getPositive)
                return ((-b) + Math.Sqrt(delta)) / (2 * a);

            return ((-b) - Math.Sqrt(delta)) / (2 * a);
        }
    }
}
