using System;
using System.Linq;
using System.Text;

namespace TestingGround
{
	public class Reverser
	{
		/*Write a function that takes an integer i and returns a string with the integer backwards followed by the original integer.*/
		/// <summary>
		/// Reverses given string.
		/// </summary>
		/// <param name="s">String to reverse.</param>
		/// <returns>The reversed string.</returns>
		public string Reverse(string s)
		{
			if (s == null)
            {
				return null;
			}
			StringBuilder toReturn = new StringBuilder();
			for (int i = s.Length - 1; i > -1; i--)
			{
				toReturn.Append(s[i]);
			}
			return toReturn.ToString();
		}
		/// <summary>
		/// Reverses an int and concats the original to it.
		/// </summary>
		/// <param name="i">Int to reverse.</param>
		/// <returns>String with reversed int followed by the original int.</returns>
		public string ReverseAndNot(int i)
		{
			if(i == null)
            {
				return null;
            }
			return Reverse(i.ToString()) + i.ToString();
		}
	}
}