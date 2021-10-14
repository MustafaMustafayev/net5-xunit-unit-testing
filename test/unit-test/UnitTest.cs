using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace unit_test
{
    public class UnitTest
    {
        [Fact]
        public void Equal()
        {
            Assert.Equal(4, 4);
        }

        [Theory]
        [InlineData(2,2,0)]
        [InlineData(5,3,2)]
        [InlineData(6,2,4)]
        public void Sum(int excepted, int num1, int num2)
        {
            Assert.Equal(excepted, num1+num2);
        }


        [Theory]
        [MemberData(nameof(TestData))]
        public void SumOfArr(int expected, int[] values)
        {
            int sum = 0;
            foreach(int val in values)
            {
                sum += val;
            }
            Assert.Equal(expected, sum);
        }

        public static IEnumerable<object[]> TestData()
        {
            yield return new object[] { 15, new int[] { 5, 10 } };
            yield return new object[] { 25, new int[] { 5, 10, 10 } };
        }

        [Theory]
        [ClassData(typeof(DivisonTestData))]
        public void SumOfArrByClassData(int expected, int[] values)
        {
            int sum = 0;
            foreach (int val in values)
            {
                sum += val;
            }
            Assert.Equal(expected, sum);
        }

    }

    class DivisonTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 15, new int[] { 5, 10 } };
            yield return new object[] { 25, new int[] { 5, 10, 10 } };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
