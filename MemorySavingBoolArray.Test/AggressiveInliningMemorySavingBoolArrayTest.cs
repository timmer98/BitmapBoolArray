using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MemorySavingBoolArray.Test
{
    [TestClass]
    public class AggressiveInliningMemorySavingBoolArrayTest
    {
        [TestMethod]
        public void GetSet_RandomIndex_ShouldHoldCorrectValues()
        {
            // Arrange
            var array = new AggressiveInlinedMemorySavingBoolArray(10);
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
