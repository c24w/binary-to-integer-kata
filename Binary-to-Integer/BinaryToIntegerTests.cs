using NUnit.Framework;

namespace Binary_to_Integer
{
	[TestFixture]
    public class BinaryToIntegerTests
	{
		[Test]
		public void Zero_string_should_return_zero()
		{
			var result = ParseBinary("0");
			Assert.That(result, Is.EqualTo(0));
		}

		[Test]
		public void One_string_should_return_one()
		{
			var result = ParseBinary("1");
			Assert.That(result, Is.EqualTo(1));
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
