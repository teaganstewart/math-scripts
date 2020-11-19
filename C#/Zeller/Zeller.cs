using System;

namespace App
{

    class ZellerBirthday
    {
        int dayNumber;
        int monthNumber;
        int yearNumber;

        string[] dayNames = new string[] { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };
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
            month = month.Substring(0, 1).ToUpper() + month.Substring(1);
            Console.Write("Date Chosen: " + day + " " + month + " " + year + " is a ");
        }

        // Checks whether a number is valid.
        /// <param name="str"> The string  name of the number. </param>
        /// <param name="year"> Whether the number is a year or a day. </param>
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
        /// <param name="day"> The user's day input. </param>
        /// <param name="month"> The user's month input. </param>
        /// <param name="year"> The user's year input. </param>
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
        /// <param name="year"> The user's year input. </param>
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
        /// <param name="month"> The user's month input. </param>
        bool CheckMonthInput(string month)
        {
            return (Array.IndexOf(months, month) > -1);
        }

        void Zeller()
        {
            GetInput();

            // Splits year into front two numbers and back two (length 4)
            int yf = Int32.Parse(yearNumber.ToString().Substring(0, 2));
            int yl = Int32.Parse(yearNumber.ToString().Substring(2, 2));

            // Calculations to work out the day name.
            int p1 = (int)Math.Floor((2.6 * monthNumber) - 5.39);
            int p2 = yf / 4;
            int p3 = yl / 4;
            int sum = p1 + p2 + p3 + dayNumber + yl - (2 * yf);

            int remainder = GetRemainder(sum, 7);

            Console.Write(dayNames[remainder] + "\n");
        }

        // Calculates the Remainder from the division of two numbers.
        /// <param name="a"> The larger number. </param>
        /// <param name="b"> The smaller number (7). For days of the week. </param>
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

                while (a <= -b)
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
