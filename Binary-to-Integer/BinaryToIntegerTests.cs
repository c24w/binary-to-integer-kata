using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using NUnit.Framework;

namespace Binary_to_Integer
{
	[TestFixture]
	public class BinaryToIntegerTests
	{
		private BinaryParser _systemUnderTest;

		[SetUp]
		public void CreateSystemUnderTest()
		{
			_systemUnderTest = new BinaryParser();
		}

		[TestCase("0", 0)]
		[TestCase("1", 1)]
		[TestCase("10", 2)]
		[TestCase("101", 5)]
		[TestCase("1001001", 73)]
		public void should_convert_binary_string_into_integer_value(string binary, int expected)
		{
			var result = _systemUnderTest.Parse(binary);
			Assert.That(result, Is.EqualTo(expected));
		}

		[TestCase("-1", -1)]
		[TestCase("-11", -3)]
		[TestCase("-10", -2)]
		[TestCase("-101", -5)]
		public void should_handle_negative_binary_data(string binary, int expected)
		{
			var result = _systemUnderTest.Parse(binary);
			Assert.That(result, Is.EqualTo(expected));
		}

		[TestCase("1-")]
		[TestCase("gaju67rdhf")]
		[TestCase("-")]
		[TestCase("--")]
		[TestCase("-1-")]
		public void should_not_process_invalid_binary_data(string binary)
		{
			Assert.Throws<ArgumentException>(() => _systemUnderTest.Parse(binary));
		}
	}

	public class BinaryParser
	{
		public int Parse(string binaryData)
		{
			ValidateBinaryData(binaryData);

			var bits = binaryData.Reverse().ToList();
			var isNegative = bits.Remove('-');

			var binaryDataIntegerValue = BitsToInt(bits);

			return isNegative ? (0 - binaryDataIntegerValue) : binaryDataIntegerValue;
		}

		private static void ValidateBinaryData(string binaryData)
		{
			if (TheBinaryDataIsNotInTheCorrectFormat(binaryData))
			{
				throw new ArgumentException();
			}
		}

		private static bool TheBinaryDataIsNotInTheCorrectFormat(string binaryData)
		{
			var validPattern = new Regex("^-?[01]+$");
			return !validPattern.IsMatch(binaryData);
		}

		private static int BitsToInt(List<char> bits)
		{
			var result = 0;

			for (var bitPosition = 0; bitPosition < bits.Count(); bitPosition++)
			{
				var bit = bits[bitPosition];

				var bitValue = CharToInt(bit);
				result += BitToInt(bitValue, bitPosition);
			}
			return result;
		}

		private static int CharToInt(char character)
		{
			return int.Parse(character.ToString(CultureInfo.InvariantCulture));
		}

		private static int BitToInt(int bitValue, int bitPosition)
		{
			return (int)Math.Pow(2, bitPosition) * bitValue;
		}
	}
}
