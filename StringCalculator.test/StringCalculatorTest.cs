using System;
using Xunit;

namespace StringCalculator
{
    public class StringCalculatorTest
    {
        StringCalculatorKata calculator;
		public StringCalculatorTest()
        {
			calculator = new StringCalculatorKata();
        }

			[Fact]
			public void empty_string_return_zero()
			{
				int sum = calculator.Add("");
				Assert.Equal(0, sum);
			}

			[Fact]
			public void null_string_return_zero()
			{
				int sum = calculator.Add(null);
				Assert.Equal(0, sum);
			}

			[Fact]
			public void single_number_return_the_number()
			{
				int sum = calculator.Add("1");
				Assert.Equal(1, sum);
			}

			[Fact]
			public void SumOfTwoNumbers()
			{
				int sum = calculator.Add("1, 2");
				Assert.Equal(3, sum);
			}

			[Fact]
			public void SumOfThreeNumbers()
			{
				int sum = calculator.Add("1, 2, 3");
				Assert.Equal(6, sum);
			}
		[Fact]
		public void ignoreBigNumber()
		{
			int sum = calculator.Add("1000, 2");
			Assert.Equal(2, sum);
		}

		[Fact]
			public void TwoNumbers_SperatedBy_NewLine()
			{
				int sum = calculator.Add("1\n2");
				Assert.Equal(3, sum);
			}
		[Fact]
		public void OneNumbers_SperatedBy_NewLine()
		{
			int sum = calculator.Add("1,\n");
			Assert.Equal(1, sum);
		}

		[Fact]
			public void support_different_delimiters()
			{
				int sum = calculator.Add("//;\n1;2");
				Assert.Equal(3, sum);
			}

			[Theory]
			[InlineData("-1")]
		    [InlineData("1,4,-1")]
		public void ThrowExceptionForNegativeNumber(string number)
			{
				Assert.Throws<Exception>(() => calculator.Add("-1"));
			}
			
		}
	}

