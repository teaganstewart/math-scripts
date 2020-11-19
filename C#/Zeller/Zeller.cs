using System;

namespace App
{
    class ZellerBirthday
    {
        int[] days = new int[] {31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31};
        string[] months = new string[] {"January", "February", "March", "April", "May", "June", "July", 
                            "August", "September", "October", "November", "December"};

        void getInput() {
            Console.Write("Enter your day of birth- "); 
            string day = Console.ReadLine();

            Console.Write("Enter your month of birth- ");
            string month = Console.ReadLine();
            month = char.ToUpper(month[0]) + month.Substring(1);

            Console.Write("Enter you year of birth.");
            string year = Console.ReadLine();

            checkMonthInput(month);
        }

        void checkNumber(string str) {
            int value;
            if(int.TryParse(str, out value)) {
                
            }
        }

        void checkDayInput(string str) {
            
        }

        void checkMonthInput(string month) {
            Console.WriteLine(month);
        }

        void zeller() {
            getInput();
        }

        void checkDay() {

        }

        void checkMonths() {

        }

        static void Main(string[] args)
        {
            new ZellerBirthday().zeller();
        }
    }
}
