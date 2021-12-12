using System;
using System.Linq;

namespace Homework_2
{
    class Program
    {
        static void Main(string[] args)
        {
            const int LEFT_BOUND = 100000;
            const int RIGHT_BOUND = 200000;
            int number_xk;
            int[] number_array = new int[6];
            int[] number_xk_array = new int[6];
            bool is_magic_number_found = false;

            Console.WriteLine("Let's find a magic 6-digit number.");

            for (int number=LEFT_BOUND; number < RIGHT_BOUND; number++)
            {
                number_array = ConvertIntegerToArray(number);

                if (!CheckIfArrayElementsAreUnique(number_array))
                {
                    continue;
                }

                for(int k = 2; k <= 6; k++)
                {
                    number_xk = number * k;
                    number_xk_array = ConvertIntegerToArray(number_xk);
                    if (Convert.ToString(number_xk).Length!=6 || !CheckIfTwoArraysContainsSameElements(number_array, number_xk_array))
                    {
                        break;
                    }
                    if (k == 6)
                    {
                        is_magic_number_found = true;
                    }
                }

                if (is_magic_number_found)
                {
                    Console.WriteLine($"Magic number is {number}!");
                    break;
                }

            }

        }

        private static bool CheckIfTwoArraysContainsSameElements(int[] arr1, int[] arr2)
        {
            // Sort string String.Concat(str.OrderBy(c => c))
            for(int i=0; i<arr1.Length; i++)
            {
                if(!arr2.Contains(arr1[i])){
                    return false;
                }
            }
            return true;
        }

        private static bool CheckIfArrayElementsAreUnique(int[] integer_array)
        {
            for(int i=1; i< integer_array.Length; i++)
            {
                for(int j=0; j<i; j++)
                {
                    if(integer_array[i] == integer_array[j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private static int[] ConvertIntegerToArray(int number)
        {
            string string_number = Convert.ToString(number);
            int n = string_number.Length;
            int[] result = new int[n];
            for (int i = 0; i < string_number.Length; i++)
            {
                result[i] = int.Parse(string_number[i].ToString());
            }
            return result;
        }
    }
}
