using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MemorySavingBoolArray
{
    /// <summary>
    /// This is not faster than the fastest equivalent implementation using a byte array internally.
    /// </summary>
    public class IntegerMemorySavingBoolArray : IMemorySavingBoolArray
    {
        private readonly int[] array;

        private const int BITWISE_AND_MODULO = 32 - 1;

        public int Length { get; }

        public IntegerMemorySavingBoolArray(int size)
        {
            this.Length = size;
            var realSize = (size >> 5) + 1; // Bit shift by 5 to the right corresponds to integer division by 32
            this.array = new int[realSize];
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void EnsureIndexBounds(int index)
        {
            if (index > this.Length) throw new IndexOutOfRangeException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void SetValue(int index, bool value)
        {
            this.EnsureIndexBounds(index);

            var (internalIndex, remainder) = this.GetInternalIndex(index);
            var bit = value ? 1 : 0;
            this.array[internalIndex] = (this.array[internalIndex] ^ bit << remainder);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private (int, int) GetInternalIndex(int index)
        {
            return (index >> 5, index & BITWISE_AND_MODULO);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private bool GetValue(int index)
        {
            this.EnsureIndexBounds(index);

            var (internalIndex, remainder) = GetInternalIndex(index);

            var workingByte = this.array[internalIndex];
            return (workingByte >> remainder & 1) == 1;
        }

        public bool this[int index]
        {
            get => GetValue(index);
            set => SetValue(index, value);
        }
    }
}
