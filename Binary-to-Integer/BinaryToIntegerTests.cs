using NUnit.Framework;

namespace Binary_to_Integer
{
	[TestFixture]
    public class BinaryToIntegerTests
	{
		[TestCase("0", 0)]
		[TestCase("1", 1)]
		public void Zero_string_should_return_zero(string binary, int expected)
		{
			var result = ParseBinary(binary);
			Assert.That(result, Is.EqualTo(expected));
		}

		private static int ParseBinary(string binary)
		{
			if (binary == "1")
			{
				return 1;
			}

			return 0;
		}
	}
}
