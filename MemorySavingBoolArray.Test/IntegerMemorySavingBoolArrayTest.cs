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
    public class IntegerMemorySavingBoolArrayTest
    {
        [TestMethod]
        public void GetSet_RandomIndex_ShouldHoldCorrectValues()
        {
            // Arrange
            var array = new IntegerMemorySavingBoolArray(10);
            var randomIndex = 9;

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
