using System;

namespace App
{

    class ZellerBirthday
    {

        int dayNumber;
        int monthNumber;
        int yearNumber;

        int[] days = new int[] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        string[] months = new string[] {"january", "february", "march", "april", "may", "june",
                                        "july", "august", "september", "october", "november", "december"};

        // Gets the user's input for their date of birth.
        void GetInput()
        {

            // First check the month as it affects the valid days and months.
            Console.Write("Enter your year of birth- ");
            string year = Console.ReadLine();

            while (!CheckNumber(year, true))
            {

                Console.WriteLine("Not a valid year. Must be 1000 <= year <= 2020.");
                Console.Write("Enter your year of birth- ");
                year = Console.ReadLine();
            }

            yearNumber = Int32.Parse(year);

            // Second check the month as it affects the valid days.
            Console.Write("Enter your month of birth- ");
            string month = Console.ReadLine().ToLower();

            while (!CheckMonthInput(month))
            {

                Console.WriteLine("Not a valid month.");
                Console.Write("Enter your month of birth- ");
                month = Console.ReadLine().ToLower();
            }

            // Last check if the day is valid based on the month and year given.
            Console.Write("Enter your day of birth- ");
            string day = Console.ReadLine();

            while (!CheckDayInput(day, month, yearNumber))
            {

                Console.WriteLine("Not a valid day based on the month and year.");
                Console.Write("Enter your day of birth- ");
                day = Console.ReadLine();
            }

            dayNumber = Int32.Parse(day);
            monthNumber = Array.IndexOf(months, month) + 1;
            if (monthNumber <= 2)
            {
                monthNumber += 12;
                yearNumber -= 1;
            }

            Console.WriteLine();
            Console.WriteLine("Date Chosen: " + day + " " + month + " " + year);
        }

        // Checks whether a number is valid.
        /// <param value="str"> The string value of the number. </param>
        bool CheckNumber(string str, bool year)
        {

            int value;
            if (int.TryParse(str, out value))
            {
                if (year && value >= 1000 && value <= 2020)
                {
                    return true;
                }
                if (!year) { return true; }
            }

            return false;
        }

        // Checks whether day is valid based on the month.
        bool CheckDayInput(string day, string month, int year)
        {

            if (CheckNumber(day, false))
            {
                int dayNumber = Int32.Parse(day);
                int index = Array.IndexOf(months, month);
                if (index == 1)
                {
                    if (checkLeapYear(year))
                    {
                        days[1] = 29;
                    }
                }
                if (dayNumber > 0 && dayNumber <= days[index])
                {
                    return true;
                }
            }

            return false;
        }

        // Checks the given year, so I know whether there are 29 or 28 days in February.
        bool checkLeapYear(int year)
        {

            if (year % 4 == 0)
            {
                if (year % 100 == 0)
                {
                    if (year % 400 == 0)
                    {
                        return true;
                    }
                }
                else
                {
                    return true;
                }
            }

            return false;
        }

        // Checks if the month entered is valid and in the list.
        bool CheckMonthInput(string month)
        {

            return (Array.IndexOf(months, month) > -1);
        }

        void Zeller()
        {

            GetInput();

            int yf = Int32.Parse(yearNumber.ToString().Substring(0, 2));
            int yl = Int32.Parse(yearNumber.ToString().Substring(2, 2));

            // Calculations to work out the 
            int p1 = (int)Math.Floor((2.6 * monthNumber) - 5.39);
            int p2 = yf / 4;
            int p3 = yl / 4;
            Console.WriteLine(p1 + " " + p2 + " " + p3);
            int sum = p1 + p2 + p3 + dayNumber + yl - (2 * yf);
            Console.Write(sum);
            int remainder = GetRemainder(sum, 7);

            Console.WriteLine(remainder);
        }

        // Calculates the Remainder from the division of two numbers.
        int GetRemainder(int a, int b)
        {

            if (a > b)
            {
                while (a >= b)
                {
                    a -= b;
                }
            }

            if (a < b)
            {
                while (a <= b)
                {
                    a += b;
                }
            }

            return a;
        }

        static void Main(string[] args)
        {
            new ZellerBirthday().Zeller();
        }
    }
}
