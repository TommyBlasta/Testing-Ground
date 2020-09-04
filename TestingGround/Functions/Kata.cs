using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace TestingGround.Functions
{
    class Kata
    {

        public static long SuperSize(long num)
        {
            var working = num.ToString().ToCharArray();
            return Convert.ToInt64(string.Join("", working.OrderByDescending(x => x).ToArray()));
        }
        //Write a function that accepts an array of 10 integers(between 0 and 9), that returns a string of those numbers in the form of a phone number.

        //Example:
        //Kata.CreatePhoneNumber(new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 0}) // => returns "(123) 456-7890"
        //The returned format must be correct in order to complete this challenge.
        //Don't forget the space after the closing parentheses!
        public static string CreatePhoneNumber(int[] numbers)
        {
            return string.Format("({0}{1}{2}) {3}{4}{5}-{6}{7}{8}{9}", numbers[0], numbers[1], numbers[2], numbers[3], numbers[4], numbers[5], numbers[6], numbers[7], numbers[8], numbers[9]);
        }
        //The goal of this exercise is to convert a string to a new string where each character in the new string is "(" if that character appears only once in the original string, or ")" if that character appears more than once in the original string. Ignore capitalization when determining if a character is a duplicate.

        //Examples
        //"din"      =>  "((("
        //"recede"   =>  "()()()"
        //"Success"  =>  ")())())"
        //"(( @"     =>  "))((" 
        //Notes

        //Assertion messages may be unclear about what they display in some languages. If you read "...It Should encode XXX", the "XXX" is the expected result, not the input!
        public static string DuplicateEncode(string word)
        {
            StringBuilder toReturn = new StringBuilder();
            Dictionary<char, int> foundChars = new Dictionary<char, int>();
            foreach (char c in word)
            {
                char working;
                if (char.IsLetter(c))
                {
                    working = char.ToLower(c);
                }
                else
                {
                    working = c;
                }
                if (!foundChars.ContainsKey(working))
                {
                    foundChars.Add(working, 1);
                }
                else
                {
                    foundChars[working]++;
                }
            }
            foreach (char c in word)
            {
                char working;
                if (char.IsLetter(c))
                {
                    working = char.ToLower(c);
                }
                else
                {
                    working = c;
                }
                if (foundChars[working] != 1)
                {
                    toReturn.Append(')');
                }
                else
                {
                    toReturn.Append('(');
                }

            }
            return toReturn.ToString();
        }
        //An isogram is a word that has no repeating letters, consecutive or non-consecutive.Implement a function that determines whether a string that contains only letters is an isogram.Assume the empty string is an isogram. Ignore letter case.

        //isIsogram "Dermatoglyphics" == true
        //isIsogram "aba" == false
        //isIsogram "moOse" == false -- ignore letter case
        public static bool IsIsogram(string str)
        {
            HashSet<char> foundCs = new HashSet<char>();
            string working = str.ToLower();
            foreach (char c in working)
            {
                if (!foundCs.Add(c))
                {
                    return false;
                }
            }
            return true;
        }
        //Write a function, persistence, that takes in a positive parameter num and returns its multiplicative persistence, which is the number of times you must multiply the digits in num until you reach a single digit.

        //For example:

        // persistence(39) == 3 // because 3*9 = 27, 2*7 = 14, 1*4=4
        //                      // and 4 has only one digit

        // persistence(999) == 4 // because 9*9*9 = 729, 7*2*9 = 126,
        //                       // 1*2*6 = 12, and finally 1*2 = 2

        // persistence(4) == 0 // because 4 is already a one-digit number
        public static int Persistence(long n)
        {
            int iterations = 0;
            long workingResult = n;
            while (workingResult / 10 > 0)
            {
                long newResult = 1;
                foreach (char c in workingResult.ToString())
                {
                    newResult *= Convert.ToInt32(c.ToString());
                }
                workingResult = newResult;
                iterations++;
            }
            return iterations;
        }
        //In a factory a printer prints labels for boxes.For one kind of boxes the printer has to use colors which, for the sake of simplicity, are named with letters from a to m.

        //The colors used by the printer are recorded in a control string. For example a "good" control string would be aaabbbbhaijjjm meaning that the printer used three times color a, four times color b, one time color h then one time color a...

        //Sometimes there are problems: lack of colors, technical malfunction and a "bad" control string is produced e.g.aaaxbbbbyyhwawiwjjjwwm with letters not from a to m.

        //You have to write a function printer_error which given a string will output the error rate of the printer as a string representing a rational whose numerator is the number of errors and the denominator the length of the control string. Don't reduce this fraction to a simpler expression.

        //The string has a length greater or equal to one and contains only letters from a to z.

        //#Examples:

        //s= "aaabbbbhaijjjm"
        //error_printer(s) => "0/14"

        //s= "aaaxbbbbyyhwawiwjjjwwm"
        //error_printer(s) => "8/22"
        public static string PrinterError(String s)
        {

            return string.Format("{0}/{1}", s.Where(x => x < 'a' || x > 'm').Count(), s.Length);
        }
        //What is an anagram? Well, two words are anagrams of each other if they both contain the same letters.For example:

        //'abba' & 'baab' == true

        //'abba' & 'bbaa' == true

        //'abba' & 'abbba' == false

        //'abba' & 'abca' == false
        //Write a function that will find all the anagrams of a word from a list.You will be given two inputs a word and an array with words.You should return an array of all the anagrams or an empty array if there are none.For example:

        //anagrams('abba', ['aabb', 'abcd', 'bbaa', 'dada']) => ['aabb', 'bbaa']

        //anagrams('racer', ['crazer', 'carer', 'racar', 'caers', 'racer']) => ['carer', 'racer']

        //anagrams('laser', ['lazing', 'lazy',  'lacer']) => []
        public static List<string> Anagrams(string word, List<string> words)
        {
            List<string> toReturn = new List<string>();
            var sortedWord = string.Join("", word.OrderBy(x => x));
            foreach (string wrd in words)
            {
                if (string.Join("", wrd.OrderBy(x => x)) == sortedWord)
                {
                    toReturn.Add(wrd);
                }
            }
            return toReturn;
        }
        //Create a function taking a positive integer as its parameter and returning a string containing the Roman Numeral representation of that integer.

        //Modern Roman numerals are written by expressing each digit separately starting with the left most digit and skipping any digit with a value of zero.In Roman numerals 1990 is rendered: 1000=M, 900=CM, 90=XC; resulting in MCMXC. 2008 is written as 2000=MM, 8=VIII; or MMVIII. 1666 uses each Roman symbol in descending order: MDCLXVI.

        //Example:

        //RomanConvert.Solution(1000) -- should return "M"
        //Help:

        //Symbol Value
        //I          1
        //II         2
        //III        3
        //IV         4
        //V          5
        //VI         6
        //VII        7
        //VIII       8
        //IX         9
        //X          10
        //L          50
        //C          100
        //D          500
        //M          1,000
        //Remember that there can't be more than 3 identical symbols in a row.

        //More about roman numerals - http://en.wikipedia.org/wiki/Roman_numerals
        public static string Romanize(int n)
        {
            List<string> solutionStrings = new List<string>();
            StringBuilder solution = new StringBuilder();
            LinkedList<(char, int)> Translations = new LinkedList<(char, int)>();
            Translations.AddLast(new ValueTuple<char, int>('I', 1));
            Translations.AddLast(new ValueTuple<char, int>('V', 5));
            Translations.AddLast(new ValueTuple<char, int>('X', 10));
            Translations.AddLast(new ValueTuple<char, int>('L', 50));
            Translations.AddLast(new ValueTuple<char, int>('C', 100));
            Translations.AddLast(new ValueTuple<char, int>('D', 500));
            Translations.AddLast(new ValueTuple<char, int>('M', 1000));
            Dictionary<int, string> patterns = new Dictionary<int, string>
            {
                { 0, "" },
                { 1, "l" },
                { 2, "ll" },
                { 3, "lll" },
                { 4, "lm" },
                { 5, "m" },
                { 6, "ml" },
                { 7, "mll" },
                { 8, "mlll" },
                { 9, "lh" }
            };
            int workingNumber = n;
            var currentLevel = Translations.First.Next;
            for (int i = 10; workingNumber != 0;)
            {
                //havent reached over thousands (or max level)
                if (currentLevel != null)
                {
                    solutionStrings.Add((patterns[workingNumber % i]
                    .Replace('l', currentLevel.Previous.Value.Item1)
                    .Replace('m', currentLevel.Value.Item1)
                    .Replace('h', currentLevel.Next.Value.Item1)));
                    workingNumber /= 10;
                    currentLevel = currentLevel.Next.Next;
                }
                //reached thousands (or max level)
                else
                {
                    solution.Append(Translations.Last.Value.Item1, workingNumber % i);
                    workingNumber /= 10;
                }
            }
            solutionStrings.Reverse();
            foreach (string str in solutionStrings)
            {
                solution.Append(str);
            }
            return solution.ToString();
        }
        //Complete the solution so that it splits the string into pairs of two characters.If the string contains an odd number of characters then it should replace the missing second character of the final pair with an underscore ('_').

        //Examples:

        //SplitString.Solution("abc"); // should return ["ab", "c_"]
        //SplitString.Solution("abcdef"); // should return ["ab", "cd", "ef"]
        public class SplitString
        {
            public static string[] Solution(string str)
            {
                List<string> splitStrings = new List<string>();
                for (int i = 0; i < str.Length; i += 2)
                {
                    if (i + 1 >= str.Length)
                    {
                        splitStrings.Add(string.Format("{0}{1}", str[i], "_"));
                    }
                    else
                    {
                        splitStrings.Add(string.Format("{0}{1}", str[i], str[i + 1]));
                    }
                }
                return splitStrings.ToArray();
            }
        }
        //Write a function, which takes a non-negative integer(seconds) as input and returns the time in a human-readable format(HH:MM:SS)

        //HH = hours, padded to 2 digits, range: 00 - 99
        //MM = minutes, padded to 2 digits, range: 00 - 59
        //SS = seconds, padded to 2 digits, range: 00 - 59
        //The maximum time never exceeds 359999 (99:59:59)

        //You can find some examples in the test fixtures.
        public static string GetReadableTime(int seconds)
        {
            int workingTime = seconds;
            int hours = workingTime / 3600;
            workingTime -= 3600 * hours;
            int minutes = workingTime / 60;
            workingTime -= 60 * minutes;
            int secs = workingTime;
            return string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, secs);
        }
        //Polycarpus works as a DJ in the best Berland nightclub, and he often uses dubstep music in his performance.Recently, he has decided to take a couple of old songs and make dubstep remixes from them.

        //Let's assume that a song consists of some number of words (that don't contain WUB). To make the dubstep remix of this song, Polycarpus inserts a certain number of words "WUB" before the first word of the song(the number may be zero), after the last word(the number may be zero), and between words(at least one between any pair of neighbouring words), and then the boy glues together all the words, including "WUB", in one string and plays the song at the club.

        //For example, a song with words "I AM X" can transform into a dubstep remix as "WUBWUBIWUBAMWUBWUBX" and cannot transform into "WUBWUBIAMWUBX".


        //Recently, Jonny has heard Polycarpus's new dubstep track, but since he isn't into modern music, he decided to find out what was the initial song that Polycarpus remixed. Help Jonny restore the original song.


        //Input
        //The input consists of a single non-empty string, consisting only of uppercase English letters, the string's length doesn't exceed 200 characters

        //Output
        //Return the words of the initial song that Polycarpus used to make a dubsteb remix.Separate the words with a space.


        //Examples
        //songDecoder("WUBWEWUBAREWUBWUBTHEWUBCHAMPIONSWUBMYWUBFRIENDWUB")
        //  // =>  WE ARE THE CHAMPIONS MY FRIEND
        public static string SongDecoder(string input)
        {
            Regex regex = new Regex("WUB");
            var toReturn = regex.Replace(input, " ");
            bool lastIsSpace = true;
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < toReturn.Length; i++)
            {
                if (lastIsSpace && toReturn[i] == ' ')
                {
                    continue;
                }
                else
                {
                    if (toReturn[i] == ' ')
                    {
                        lastIsSpace = true;
                        stringBuilder.Append(toReturn[i]);
                    }
                    else
                    {
                        lastIsSpace = false;
                        stringBuilder.Append(toReturn[i]);
                    }
                }
            }
            return stringBuilder.ToString().Trim();
        }
        //Complete the function scramble(str1, str2) that returns true if a portion of str1 characters can be rearranged to match str2, otherwise returns false.

        //Notes:

        //Only lower case letters will be used(a-z). No punctuation or digits will be included.
        //Performance needs to be considered
        //Input strings s1 and s2 are null terminated.
        //Examples
        //scramble('rkqodlw', 'world') ==> True
        //scramble('cedewaraaossoqqyt', 'codewars') ==> True
        //scramble('katas', 'steak') ==> False
        public static bool Scramble(string str1, string str2)
        {
            Dictionary<char, int> charNums1 = new Dictionary<char, int>();
            foreach (char c in str1)
            {
                if (charNums1.ContainsKey(c))
                {
                    charNums1[c]++;
                }
                else
                {
                    charNums1.Add(c, 1);
                }
            }
            foreach (char c in str2)
            {
                if (charNums1.ContainsKey(c) && charNums1[c] != 0)
                {
                    charNums1[c]--;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
        //Given a string of words, you need to find the highest scoring word.
        //Each letter of a word scores points according to its position in the alphabet: a = 1, b = 2, c = 3 etc.
        //You need to return the highest scoring word as a string.
        //If two words score the same, return the word that appears earliest in the original string.
        //All letters will be lowercase and all inputs will be valid.
        public static string High(string s)
        {
            int WordScore(string word)
            {
                int toReturn = 0;
                foreach (char c in word)
                {
                    toReturn += (int)c - 96;
                }
                return toReturn;
            }
            string highestWord = string.Empty;
            int highestScore = 0;
            foreach (var str in s.Split(new char[] { ' ' }, options: StringSplitOptions.RemoveEmptyEntries))
            {
                if (WordScore(str) > highestScore)
                {
                    highestWord = str;
                    highestScore = WordScore(str);
                }
            }
            return highestWord;
        }
        //    Implement a function that receives two IPv4 addresses, and returns the number of addresses between them(including the first one, excluding the last one).

        //    All inputs will be valid IPv4 addresses in the form of strings.The last address will always be greater than the first one.

        //    Examples
        //    ips_between("10.0.0.0", "10.0.0.50")  ==   50 
        //    ips_between("10.0.0.0", "10.0.1.0")   ==  256 
        //    ips_between("20.0.0.10", "20.0.1.0")  ==  246
        public static long IpsBetween(string start, string end)
        {
            //long between = 0;
            //int[] possibilities = { 0, 0, 0, 0 };
            //Convert.ToString(3, 2).PadLeft(8, '0');
            long BinToInt(string binary)
            {
                long toReturn = 0;
                int pow = 0;
                for (int i = binary.Length - 1; i >= 0; i--)
                {
                    if (binary[i] == '1')
                    {
                        toReturn += Convert.ToInt64(Math.Pow(2, pow));
                    }
                    pow++;
                }
                return toReturn;
            }
            var endAddress = string.Join("", end.Split('.').Select(x => Convert.ToString(Convert.ToInt32(x), 2).PadLeft(8, '0')).ToArray());
            var startAddress = string.Join("", start.Split('.').Select(x => Convert.ToString(Convert.ToInt32(x), 2).PadLeft(8, '0')).ToArray());
            return BinToInt(endAddress) - BinToInt(startAddress);
            //int[] endAddress = end.Split('.').Select(x => Convert.ToInt32(x)).ToArray();
            //int[] startAddress = start.Split('.').Select(x => Convert.ToInt32(x)).ToArray();
            //var a = (startAddress[0] * Convert.ToInt64(Math.Pow(256, 3)) + (startAddress[1] * 256 * 256) + (startAddress[2] * 256) + (startAddress[3]));
            //var b = (endAddress[0] * Convert.ToInt64(Math.Pow(256, 3)) + (endAddress[1] * 256 * 256) + (endAddress[2] * 256) + (endAddress[3]));
            //return b - a;

        }
        //Write a function that accepts a square matrix(N x N 2D array) and returns the determinant of the matrix.

        //How to take the determinant of a matrix -- it is simplest to start with the smallest cases:

        //A 1x1 matrix |a| has determinant a.

        //A 2x2 matrix[[a, b], [c, d] ] or

        //|a b|
        //|c d|
        //has determinant: a* d - b* c.

        // The determinant of an n x n sized matrix is calculated by reducing the problem to the calculation of the determinants of n matrices ofn-1 x n-1 size.

        // For the 3x3 case, [ [a, b, c], [d, e, f], [g, h, i] ] or

        //|a b c|  
        //|d e f|  
        //|g h i|  
        //the determinant is: a* det(a_minor) - b* det(b_minor) + c* det(c_minor) where det(a_minor) refers to taking the determinant of the 2x2 matrix created by crossing out the row and column in which the element a occurs:

        //|- - -|
        //|- e f|
        //|- h i|  
        //Note the alternation of signs.

        //The determinant of larger matrices are calculated analogously, e.g. if M is a 4x4 matrix with first row[a, b, c, d], then:


        //det(M) = a* det(a_minor) - b* det(b_minor) + c* det(c_minor) - d* det(d_minor)
        public static int Determinant(int[][] matrix)
        {
            int[][] Extend(int[][] inputMatrix)
            {
                int[][] resultMatrix = new int[(inputMatrix.Length * 2) - 1][];
                for (int i = 0; i < inputMatrix.Length; i++)
                {
                    resultMatrix[i] = inputMatrix[i];
                }
                for (int i = 0; i < inputMatrix.Length - 1; i++)
                {
                    resultMatrix[inputMatrix.Length + i] = inputMatrix[i];
                }
                return resultMatrix;
            }
            int DeterminantFromDiagonals(int[][] inputMatrix)
            {
                //from left
                int leftSide = 0;
                for (int i = 0; i < (inputMatrix.Length / 2) + 1; i++)
                {
                    int diagonal = 1;
                    for (int p = 0; p < (inputMatrix.Length / 2) + 1; p++)
                    {
                        diagonal *= inputMatrix[i + p][p];
                    }
                    leftSide += diagonal;
                }

                //from right
                int rightSide = 0;
                for (int i = inputMatrix.Length / 2 + 1; i >= 0; i++)
                {
                    int diagonal = 1;
                    for (int p = inputMatrix[0].Length - 1; p >= 0; p--)
                    {
                        diagonal *= inputMatrix[(inputMatrix[0].Length - 1) - p][p];
                    }
                    rightSide += diagonal;
                }
                return leftSide - rightSide;
            }
            //int[][] Reduce(int[][] inputMatrix, int elementRow, int elementCol)
            //{
            //    int[][] newMatrix = new int[inputMatrix[0].Length - 1][];
            //    for (int row = 0; row < inputMatrix.Length; row++)
            //    {
            //        if (row == elementRow)
            //        {
            //            continue;
            //        }
            //        else
            //        {
            //            int[] newRow = new int[newMatrix.Length];
            //            bool skipped = false;
            //            for (int col = 0; col < inputMatrix.Length; col++)
            //            {
            //                if (col == elementCol)
            //                {
            //                    continue;
            //                }
            //                else
            //                {
            //                    newRow[i]
            //                }

            //            }
            //        }

            //    }
            //    foreach (var row in inputMatrix)
            //    {
            //        int[] newRow = new int[newMatrix.Length];
            //        foreach (var element in row)
            //        {
            //            if ()
            //        }
            //        Console.WriteLine();
            //    }
            //}
            foreach (var row in Extend(matrix))
            {
                foreach (var element in row)
                {
                    Console.Write(element + "");
                }
                Console.WriteLine();
            }

            // Your code here!
            return DeterminantFromDiagonals(Extend(matrix));
        }
    }

}
