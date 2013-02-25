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

		private int ParseBinary(string binary)
		{
			return 0;
		}
	}
}
