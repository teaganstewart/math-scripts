using System;

namespace App
{
    class Program
    {
        int first;
        int second;

        // Gets the user's input for the gcd calculation. Requires to positive integers.
        void GetInput()
        {

            for (int i = 0; i < 2; i++)
            {
                Console.Write("Enter the " + ((i == 0) ? "first" : "second") + " number- ");

                string s = Console.ReadLine();
                while (!CheckInput(s))
                {
                    Console.WriteLine("Not a correct number. Please enter a number > 0.");
                    Console.Write("Enter the first number- ");
                    s = Console.ReadLine();
                }

                if (i == 0)
                {
                    first = Int32.Parse(s);
                }
                else
                {
                    second = Int32.Parse(s);
                }
            }

            int temp = Math.Max(first, second);
            second = Math.Min(first, second);
            first = temp;
        }


        // Makes sure that the users input is positive and an integer.
        /// <param name="n">The user's input.</param>
        bool CheckInput(string str)
        {
            int value;
            if (int.TryParse(str, out value))
            {
                if (value > 0)
                {
                    return true;
                }
            }
            return false;
        }

        // Calculates the Remainder from the division of two numbers.
        int GetRemainder(int a, int b)
        {

            while (a >= b)
            {
                a -= b;
            }

            return a;
        }

        // Calculates the result of dividing two numbers.
        int GetDivision(int a, int b)
        {
            int c = a / b;
            return c;
        }

        // Carries out the euclidian algorithm using the remainder and division algorithms.
        void Gcd()
        {
            GetInput();

            int remainder = GetRemainder(first, second);
            int divisor = GetDivision(first, second);

            while (remainder != 0)
            {
                first = second;
                second = remainder;

                remainder = GetRemainder(first, second);
                divisor = GetDivision(first, second);

            }

            int answer = first / divisor;
            Console.WriteLine("Answer- " + answer);
            Console.WriteLine("Remainder- " + GetRemainder(first, second));
            Console.WriteLine("Division- " + GetDivision(first, second));
        }

        static void Main(string[] args)
        {
            new Program().Gcd();
        }
    }
}
