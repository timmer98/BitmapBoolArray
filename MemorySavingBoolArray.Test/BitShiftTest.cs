using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MemorySavingBoolArray.Test
{
    [TestClass]
    public class BitShiftTest
    {
        [TestMethod]
        public void TestBitShiftWithDividableValue()
        {
            // Arrange
            var num = 8;

            // Act
            var divided = num >> 3;

            // Assert
            divided.Should().Be(1);
        }

        [TestMethod]
        public void TestBitShiftWithUnevenValue()
        {
            // Arrange
            var num = 9;

            // Act
            var divided = num >> 3;

            // Assert
            divided.Should().Be(1);
        }
    }
}
