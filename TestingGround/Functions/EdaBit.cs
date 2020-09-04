using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace TestingGround.Functions
{
    public class EdaBitMethods
    {
        public int CounterpartCharCode(char symbol)
        {
            if (char.IsUpper(symbol))
            {
                return (int)char.ToLower(symbol);
            }
            else if (char.IsLower(symbol))
            {
                return (int)char.ToUpper(symbol);
            }
            return (int)symbol;
        }
        //Create a function that takes an array of non-negative integers and strings and return a new array without the strings.

        //Examples
        //FilterArray([1, 2, "a", "b"]) ➞ [1, 2]

        //FilterArray([1, "a", "b", 0, 15]) ➞ [1, 0, 15]

        //FilterArray([1, 2, "aasf", "1", "123", 123]) ➞ [1, 2, 123]
        //Notes
        //Zero is a non-negative integer.
        public int[] FilterArray(object[] arr)
        {
            LinkedList<int> toReturn = new LinkedList<int>();
            foreach (object obj in arr)
            {
                if (obj is int)
                {
                    toReturn.AddLast((int)obj);
                }
            }
            return toReturn.ToArray();
        }
        //        An isogram is a word that has no repeating letters, consecutive or nonconsecutive.Create a function that takes a string and returns either
        //        true or false depending on whether or not it's an "isogram".

        //        Examples
        //        IsIsogram("Algorism") ➞ true

        //        IsIsogram("PasSword") ➞ false
        //        // Not case sensitive.

        //        IsIsogram("Consecutive") ➞ false
        //        Notes
        //        Ignore letter case (should not be case sensitive).
        //          All test cases contain valid one word strings.
        public static bool IsIsogram(string str)
        {
            HashSet<char> found = new HashSet<char>();
            foreach (char c in str)
            {
                if (!(found.Add(char.ToLower(c))))
                {
                    return false;
                }
            }
            return true;
        }
        //Create a function that takes a number as an argument and returns a string formatted to separate thousands.

        //Examples
        //FormatNum(1000) ➞ "1,000"

        //FormatNum(100000) ➞ "100,000"

        //FormatNum(20) ➞ "20"
        //Notes
        //You can expect a valid number for all test cases.
        public static string FormatNum(int num)
        {
            if (num / 1000 > 0)
            {
                return FormatNum(num / 1000) + "," + (num % 1000).ToString().PadLeft(3, '0');
            }
            else return num.ToString();
        }
        //Create a function that takes a string and replaces every letter with the letter following it in the alphabet("c" becomes "d", "z" becomes "a", "b" becomes "c", etc). Then capitalize every vowel(a, e, i, o, u) and return the new modified string.

        //Examples
        //Mangle("Fun times!") ➞ "GvO Ujnft!"

        //Mangle("The quick brown fox.") ➞ "UIf rvjdl cspxO gpy."

        //Mangle("Omega") ➞ "Pnfhb"
        //Notes
        //If a letter is already uppercase, return it as uppercase(regardless of being a vowel).
        //"y" is not considered a vowel.
        public static string Mangle(string str)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (char c in str)
            {
                if (!char.IsLetter(c))
                {
                    stringBuilder.Append(c);
                }
                else
                {
                    char shifted = Shift(c);
                    if (isVowel(shifted))
                    {
                        stringBuilder.Append(Capitalize(shifted));
                    }
                    else
                    {
                        stringBuilder.Append(shifted);
                    }
                }
            }
            return stringBuilder.ToString();
            //helper functions
            bool isVowel(char c)
            {
                return (c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u' || c == 'A' || c == 'E' || c == 'I' || c == 'O' || c == 'U');
            }
            char Shift(char c)
            {
                if ((int)c == 122)
                {
                    return 'a';
                }
                else if ((int)c == 90)
                {
                    return 'A';
                }
                else
                {
                    return (char)((int)c + 1);
                }
            }
            //
            char Capitalize(char c)
            {
                if (char.IsUpper(c))
                {
                    return c;
                }
                else
                {
                    return char.ToUpper(c);
                }
            }
            //Create a function that takes two strings and determines if an anagram of the first string is in the second string.Anagrams of "bag" are "bag", "bga", "abg", "agb", "gab", "gba".Since none of those anagrams are in "grab", the answer is false.A "g", "a", and "b" are in the string "grab", but they're split up by the "r".

            //Examples
            //AnagramStrStr("car", "race") ➞ true

            //AnagramStrStr("nod", "done") ➞ true

            //AnagramStrStr("bag", "grab") ➞ false
            //Notes
            //Inputs will be valid strings in all lowercase letters.
            //There exists a linear time algorithm for this.
        }
        public bool AnagramStrStr(string needle, string haystack)
        {

            var currentNeedle = needle.ToList<char>();
            foreach (char c in haystack)
            {
                if (currentNeedle.Contains(c))
                {
                    currentNeedle.Remove(c);
                    if (currentNeedle.Count == 0)
                    {
                        return true;
                    }
                }
                else
                {
                    currentNeedle = needle.ToList<char>();
                }
            }
            return false;
        }
        //Create a function that transforms sentences ending with multiple question marks? or exclamation marks ! into a sentence only ending with one without changing punctuation in the middle of the sentences.

        //Examples
        //NoYelling("What went wrong?????????") ➞ "What went wrong?"

        //NoYelling("Oh my goodness!!!") ➞ "Oh my goodness!"

        //NoYelling("I just!!! can!!! not!!! believe!!! it!!!") ➞ "I just!!! can!!! not!!! believe!!! it!"
        //// Only change repeating punctuation at the end of the sentence.

        //NoYelling("Oh my goodness!") ➞ "Oh my goodness!"
        //// Do not change sentences where there exists only one or zero exclamation marks/question marks.

        //NoYelling("I just cannot believe it.") ➞ "I just cannot believe it."
        //Notes
        //Only change ending punctuation - keep the exclamation marks or question marks in the middle of the sentence the same(see third example).
        //Don't worry about mixed punctuation (no cases that end in something like ?!??!).
        //Keep sentences that do not have question/exclamation marks the same.
        public static string NoYelling(string phrase)
        {
            Regex regexExclamation = new Regex("[!]+");
            Regex regexQuestion = new Regex("[?]+");
            StringBuilder ending = new StringBuilder();
            for (int i = phrase.Length - 1; i >= 0; i--)
            {
                if (char.IsLetter(phrase[i]))
                {
                    break;
                }
                else
                {
                    ending.Append(phrase[i]);
                }
            }
            if (ending.Length > 1 && regexExclamation.IsMatch(ending.ToString()))
            {
                return phrase.Trim('!') + '!';
            }
            else if (ending.Length > 1 && regexQuestion.IsMatch(ending.ToString()))
            {
                return phrase.Trim('?') + '?';
            }
            else
            {
                return phrase;
            }
        }
        //Write a function that accepts a string and an n and returns a cipher by rolling each character forward(n > 0) or backward(n< 0) n times.

        //Note: Think of the letters as a connected loop, so rolling a backwards once will yield z, and rolling z forward once will yield a. If you roll 26 times in either direction, you should end up back where you started.


        //Examples
        //RollingCipher("abcd", 1) ➞ "bcde"

        //RollingCipher("abcd", -1) ➞ "zabc"

        //RollingCipher("abcd", 3) ➞ "defg"

        //RollingCipher("abcd", 26) ➞ "abcd"
        //Notes
        //All letters are lower cased.
        //No spacing.
        //Each character is rotated the same number of times.
        public static string RollingCipher(string str, int n)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (char c in str)
            {
                stringBuilder.Append(Roll(c, n));
            }
            return stringBuilder.ToString();
            char Roll(char toRoll, int rollNumber)
            {
                char rolledChar = (char)((int)toRoll + rollNumber);
                //rolls below 'a'?
                if ((int)toRoll + rollNumber < (int)'a')
                {
                    //return char that has the same distance from 'z' as the new char has from 'a'
                    return (char)(('z' + 1) - ('a' - rolledChar));
                }
                //rolls above 'z'?
                else if ((int)toRoll + rollNumber > (int)'z')
                {
                    //return char that has same distance from 'a' as the new char has from 'z'
                    return (char)(('a' - 1) + (rolledChar - (int)'z'));
                }
                else
                {
                    return rolledChar;
                }
            }
        }
        //Create a function that returns true if two strings share the same letter pattern, and false otherwise.

        //Examples
        //SameLetterPattern("ABAB", "CDCD") ➞ true

        //SameLetterPattern("ABCBA", "BCDCB") ➞ true

        //SameLetterPattern("FFGG", "CDCD") ➞ false

        //SameLetterPattern("FFFF", "ABCD") ➞ false
        public static bool SameLetterPattern(string str1, string str2)
        {
            if (Enumerable.SequenceEqual(GetPattern(str1), GetPattern(str2)))
            {
                return true;
            }
            else
            {
                return false;
            }
            int[] GetPattern(string str)
            {
                int[] toReturn = new int[str.Length];
                int mappingNumber = 0;
                Dictionary<char, int> charToInt = new Dictionary<char, int>();

                if (str.Length > 0)
                {
                    for (int i = 0; i < str.Length; i++)
                    {
                        if (charToInt.ContainsKey(str[i]))
                        {
                            toReturn[i] = charToInt[str[i]];
                        }
                        else
                        {
                            charToInt.Add(str[i], mappingNumber);
                            toReturn[i] = mappingNumber;
                            mappingNumber++;
                        }
                    }
                    return toReturn;
                }
                else
                {
                    return null;
                }

            }
        }
        public static double MyPi(int n)
        {
            var toReturn = Math.Round(Math.PI, n);
            return toReturn;
        }

    }

}
