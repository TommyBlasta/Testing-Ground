using System;

namespace TestingGround
{
	public class Repeater
	{
		/*Create a function that repeats each character in a string n times.*/
		public string Repeat(string str, int num)
		{
			if (num > 1000)
				throw new ArgumentOutOfRangeException(paramName: "num");
			if (str.Length > 1000)
				throw new ArgumentOutOfRangeException(paramName: "str");
			string toReturn = "";
			foreach (char c in str)
			{
				for (int i = 1; i <= num; i++)
					toReturn += c;
			}
			return toReturn;
		}
	}
}