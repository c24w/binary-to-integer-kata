using System;
using System.Globalization;
using System.Linq;
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
		[TestCase("1001001", 73)]
		public void should_convert_binary_string_into_integer_value(string binary, int expected)
		{
			var result = ParseBinary(binary);
			Assert.That(result, Is.EqualTo(expected));
		}

		[Test]
		public void should_handle_negative_binary_data()
		{
			var result = ParseBinary("-1");
			Assert.That(result, Is.EqualTo(-1));
		}

		private static int ParseBinary(string binaryData)
		{
			var bits = binaryData.Reverse().ToList();

			var binaryDataIntegerValue = 0;

			for (var bitPosition = 0; bitPosition < bits.Count(); bitPosition++)
			{
				var bit = bits[bitPosition];

				if (bit == '-')
				{
					binaryDataIntegerValue = 0 - binaryDataIntegerValue;
				}
				else
				{
					var bitValue = CharToInt(bit);
					binaryDataIntegerValue += ConvertBitToInteger(bitValue, bitPosition);
				}
			}

			return binaryDataIntegerValue;
		}

		private static int CharToInt(char character)
		{
			return int.Parse(character.ToString(CultureInfo.InvariantCulture));
		}

		private static int ConvertBitToInteger(int bitValue, int bitPosition)
		{
			return (int)Math.Pow(2, bitPosition) * bitValue;
		}
	}
}
