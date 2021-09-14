using System;
using System.Collections.Generic;

/*
- Due Wednesday 11:59pm.
- Print the numbers 1 to 1000 to the console. 
- Print them in groups of 10 per line with one space separating each number.
- When the number is a multiple of three, print “sweet” instead of the number to the console.
- If the number is a multiple of five, print “salty” (instead of the number) to the console.
- For numbers which are multiples of three and five, print “sweet’nSalty” to the console (instead of the number).
- After the numbers have all been printed, print out, on 3 separate lines, how many sweet’s, how many salty’s, and how many sweet’nSalty’s. These are three separate groups, so sweet’nSalty does not increment sweet or salty (and vice versa). 
- Include verbose commentary in the source code to tell me what each few lines are doing. 
- Push the source code to a new repo created under the naming convention CodeAssignment-fname-lname (ex. CodeAssignment-mark-moore)
- Store the code in a directory titled, SweetnSaltyConsole
*/

namespace SweetNSalty
{
    class Program
    {
        static void Main(string[] args)
        {
            // counters for number of "sweet" nums and "salty" nums and "sweetnsalty" nums
            int totalSweet = 0;
            int totalSalt = 0;
            int totalSweetSalt = 0;

            // create a space in memory to store current group's output strings
            string[] numbers = new string[10];

            // iterate thru each number group, 10 at a time
            for (int i = 1; i < 1000; i += 10)
            {
                // iterate thru the number in the group, one at a time
                for (int j = i; j < i + 10; j++)
                {
                    // Create a 0-based index for the group to reference correct spot in numbers arr
                    int idx = ((j - 1) % 10);
                    // add string for the number to current group's output
                    numbers[idx] = SweetOrSalty(j, ref totalSalt, ref totalSweet, ref totalSweetSalt);
                }
                // create line by joining numbers' strings with spaces between
                var curLine = string.Join(" ", numbers);
                // write result as we go
                Console.WriteLine(curLine);
            }
            // write counts for each type of number
            Console.WriteLine(totalSweet);
            Console.WriteLine(totalSalt);
            Console.WriteLine(totalSweetSalt);
        }

        /// <summary>
        /// Decide whether to print sweet or salty for n, and increment corresponding counters
        /// (the counters are mutually exclusive)
        /// </summary>
        /// <param name="n">number to output</param>
        /// <param name="numSalty">counter for salty numbers</param>
        /// <param name="numSweet">counter for sweet numbers</param>
        /// <param name="numBoth">counter for numbers that are both</param>
        /// <returns></returns>
        static string SweetOrSalty(int n, ref int numSalty, ref int numSweet, ref int numBoth)
        {
            // Decide whether a number is a multiple of 3 or 5, and increment appropriate counters
            bool multipleOf3 = (n % 3 == 0);
            bool multipleOf5 = (n % 5 == 0);
            if (multipleOf3 && multipleOf5)
            {
                numBoth++;
                return "sweet'nSalty";
            }
            else if (multipleOf3)
            {
                numSweet++;
                return "sweet";
            }
            else if (multipleOf5)
            {
                numSalty++;
                return "salty";
            }
            else
            {
                return $"{n}";
            }
        }
    }
}
