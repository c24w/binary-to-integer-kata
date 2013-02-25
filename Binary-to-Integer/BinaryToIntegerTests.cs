using System;
using System.Globalization;
using NUnit.Framework;

namespace Binary_to_Integer
{
	[TestFixture]
	public class BinaryToIntegerTests
	{
		[TestCase("0", 0)]
		[TestCase("1", 1)]
		[TestCase("10", 2)]
		[TestCase("101", 5)]
		public void Zero_string_should_return_zero(string binary, int expected)
		{
			var result = ParseBinary(binary);
			Assert.That(result, Is.EqualTo(expected));
		}

		private static int ParseBinary(string binaryData)
		{
			var total = 0;
			for (var bitPosition = 0; bitPosition < binaryData.Length; bitPosition++)
			{
				var currentBitIndex = binaryData.Length - bitPosition - 1;
				var bit = binaryData[currentBitIndex];

				var bitValue =  int.Parse(bit.ToString(CultureInfo.InvariantCulture));

				total += ConvertBitToInteger(bitValue, bitPosition);
			}

			return total;
		}

		private static bool BitIsSet(char bit)
		{
			return bit == '1';
		}

		private static int ConvertBitToInteger(int bitValue, int bitPosition)
		{
			return (int)Math.Pow(2, bitPosition) * bitValue;
		}
	}
}
