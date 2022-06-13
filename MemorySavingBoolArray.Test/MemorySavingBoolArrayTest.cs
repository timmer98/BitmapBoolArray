using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MemorySavingBoolArray.Test
{
    [TestClass]
    public class MemorySavingBoolArrayTest
    {
        [TestMethod]
        public void SetTrue_ShouldSetAllTrue()
        {
            // Arrange
            var array = new MemorySavingBoolArray(10);

            // Act
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = true;
            }

            // Assert
            for (int i = 0; i < array.Length; i++)
            {
                array[i].Should().BeTrue();
            }

        }
    }
}
