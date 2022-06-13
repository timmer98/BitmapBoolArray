using System;
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

        [TestMethod]
        public void GetSet_OutOfBoundsOfActualArray_ShouldThrow()
        {
            // Arrange
            var array = new MemorySavingBoolArray(10);

            // Act / Assert
            Assert.ThrowsException<IndexOutOfRangeException>(() => array[19]);
            Assert.ThrowsException<IndexOutOfRangeException>(() => array[19] = true);
        }

        [TestMethod]
        public void GetSet_OutOfBoundsForSizeButCouldGetValueBecauseRemainingBits_ShouldThrow()
        {
            // Arrange
            var array = new MemorySavingBoolArray(10);

            // Act / Assert
            Assert.ThrowsException<IndexOutOfRangeException>(() => array[11]);
            Assert.ThrowsException<IndexOutOfRangeException>(() => array[11] = true);
        }

        [TestMethod]
        public void GetSet_RandomIndex_ShouldHoldCorrectValues()
        {
            // Arrange
            var array = new MemorySavingBoolArray(10);
            var randomIndex = new Random().Next(0, 10);

            // Act
            array[randomIndex] = true;

            // Assert
            for (int i = 0; i < array.Length; i++)
            {
                if (i == randomIndex)
                {
                    array[i].Should().BeTrue();
                }
                else
                {
                    array[i].Should().BeFalse();
                }
            }
        }
    }
}
