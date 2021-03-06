using System.Runtime.CompilerServices;

namespace MemorySavingBoolArray
{
    public class MemorySavingBoolArray : IMemorySavingBoolArray
    {
        private readonly byte[] array;

        public int Length { get; }

        public MemorySavingBoolArray(int size)
        {
            this.Length = size;
            var realSize = (size >> 3) + 1; // Bit shift by 3 to the right corresponds to integer division by 8
            this.array = new byte[realSize];
        }

        private void EnsureIndexBounds(int index)
        {
            if (index > this.Length) throw new IndexOutOfRangeException();
        }

        private void SetValue(int index, bool value)
        {
            this.EnsureIndexBounds(index);

            var (internalIndex, remainder) = this.GetInternalIndex(index);
            var bit = value ? 1 : 0;
            this.array[internalIndex] = (byte)(this.array[internalIndex] ^ bit << remainder);
        }

        private (int, int) GetInternalIndex(int index)
        {
            return (index >> 3, index % 8);
        }

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