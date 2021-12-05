using System;

namespace Homework_1
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter a number between -99 and 99: ");
            string input = Console.ReadLine();
            string output;

            if (!Is_valid_number(ref input))
            {
                Console.WriteLine("Invalid input");
                return;
            }
            int number = Convert.ToInt16(input);

            bool Is_negative = number < 0;

            if (Is_negative)
            {
                number *= -1;
            }

            if (!Is_in_valid_range(number))
            {
                Console.WriteLine("Input number is outside the valid range");
                return;
            }

            if (number < 10)
            {
                output = Convert_single_digit_numbers(number);
            }
            else if (number > 9 && number < 20)
            {
                output = Convert_two_digit_numbers_till19(number);
            }
            else
            {
                output = Convert_two_digit_numbers_larger19(number);
            }


            if (Is_negative)
            {
                output = "minus " + output;
            }
            Console.WriteLine(output);
        }

        private static bool Is_in_valid_range(int number)
        {
            return (number >= 0) && (number < 100);
        }

        private static string Convert_two_digit_numbers_larger19(int number)
        {
            int dozens = number / 10;
            int remainder = number % 10;

            string dozens_output = Convert_dozens(dozens);
            string units_output = Convert_single_digit_numbers(remainder);

            return dozens_output + " " + units_output;
        }

        private static string Convert_dozens(int dozens)
        {
            string dozens_text = Convert_single_digit_numbers(dozens);
            if (dozens == 2) return "dvidesimt";
            else if (dozens == 3) return "trisdesimt";
            else return dozens_text + "asdesimt";
        }

        private static string Convert_single_digit_numbers(int number)
        {
            switch (number)
            {
                case (0):
                    return "nulis";
                case (1):
                    return "vienas";
                case (2):
                    return "du";
                case (3):
                    return "tris";
                case (4):
                    return "keturi";
                case (5):
                    return "penki";
                case (6):
                    return "sesi";
                case (7):
                    return "septyni";
                case (8):
                    return "astuoni";
                case (9):
                    return "devyni";
                default:
                    return "Error";
            }
        }

        private static string Convert_two_digit_numbers_till19(int number)
        {
            switch (number)
            {
                case (10):
                    return "desimt";
                case (11):
                    return "vienuolika";
                case (12):
                    return "dvilika";
                case (13):
                    return "trilika";
                case (14):
                    return "keturiolika";
                case (15):
                    return "penkiolika";
                case (16):
                    return "sesiolika";
                case (17):
                    return "septyniolika";
                case (18):
                    return "astuniolika";
                case (19):
                    return "devyniolika";
                default:
                    return "Error";
            }
        }

        private static bool Is_valid_number(ref string input)
        {
            char symbol;
            string res = "";
            for (int i = 0; i < input.Length; i++)
            {
                symbol = input[i];
                if (symbol == ' ') continue;
                else if ((symbol=='-' && res.Length == 0) || Is_valid_digit(symbol))
                {
                    res +=symbol;
                }
                else return false;
            }
            input = res;
            return true;
        }

        private static bool Is_valid_digit(char symbol)
        {
            if (symbol.Equals('0') ||
                symbol.Equals('1') ||
                symbol.Equals('2') ||
                symbol.Equals('3') ||
                symbol.Equals('4') ||
                symbol.Equals('5') ||
                symbol.Equals('6') ||
                symbol.Equals('7') ||
                symbol.Equals('8') ||
                symbol.Equals('9')) return true;
            else return false;
        }
    }
}
