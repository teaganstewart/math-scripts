using System;

namespace App
{
    class Program
    {
        int first;
        int second;

        // Gets the user's input for the GCD calculation. Requires to positive integers.
        void getInput() {
            
            for(int i = 0; i < 2; i++) {
                Console.Write("Enter the " + ((i ==0) ? "first" : "second") + " number- "); 
                
                string s = Console.ReadLine();
                while(!checkInput(s)) {
                    Console.WriteLine("Not a correct number. Please enter a number > 0.");
                    Console.Write("Enter the first number- ");
                    s = Console.ReadLine();  
                }

                if( i == 0 ) {
                    first = Int32.Parse(s);
                } else {
                    second = Int32.Parse(s);
                }
            }

                int temp = Math.Max(first, second);
                second = Math.Min(first, second);
                first = temp;
        }

        
        // Makes sure that the users input is positive and an integer.
        /// <param name="n">The user's input.</param>
        bool checkInput(string n) {
            int value;
            if (int.TryParse(n, out value)) {
                if(value > 0) {
                    return true;
                }
            }
            return false;
        }

        // Calculates the Remainder from the division of two numbers.
        int getRemainder(int a, int b) {
            
            while(a >= b) {
                a-=b;
            }

            return a;
        }

        // Calculates the result of dividing two numbers.
        int getDivision(int a, int b) {
            int c = a/b;
            return c;
        }

        void gcd() {
            getInput();

            int remainder = getRemainder(first, second);
            int divisor = getDivision(first, second);

            while(remainder != 0) {
                first = second;
                second = remainder;

                remainder = getRemainder(first, second);
                divisor = getDivision(first, second);
                
            }

            int answer = first/divisor;
            Console.WriteLine("Answer- " + answer);
            Console.WriteLine("Remainder- " + getRemainder(first, second));
            Console.WriteLine("Division- " + getDivision(first, second));
        }

        static void Main(string[] args)
        {
            new Program().gcd();
        }
    }
}
