using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MemorySavingBoolArray.Test
{
    [TestClass]
    public class ModuloTest
    {
        [TestMethod]
        public void TestModulo()
        {
            // Arrange
            // Act/Assert
            // If the denominator is a power of 2 the modulus can be calculated by subtracting 1 and bitwise and.
            for (int index = 0; index < 50; index++)
            {
                (index & (8 - 1)).Should().Be(index % 8); 
            }
        }
    }
}
