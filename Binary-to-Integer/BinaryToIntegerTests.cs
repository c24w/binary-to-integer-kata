using System;
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

		private static int ParseBinary(string binary)
		{
			var total = 0;
			for (var index = 0; index < binary.Length; index++)
			{
				var n = binary[binary.Length - index - 1];
				if (n == '1')
				{
					total += (int)Math.Pow(2, index);
				}
			}

			return total;
		}
	}
}
