using BenchmarkDotNet.Attributes;

namespace MemorySavingBoolArray.Benchmarks
{
    [MemoryDiagnoser]
    public class ArrayBenchmark
    {
        [Params(100, 100_000)]
        public int Size { get; set; }

        [Benchmark]
        public void Set_MemorySavingBoolArray()
        {
            var array = new MemorySavingBoolArray(this.Size);
            for (int i = 0; i < this.Size; i++)
            {
                array[i] = true;
            }
        }

        [Benchmark]
        public void Set_NormalBoolArray()
        {
            var array = new bool[this.Size];
            for (int i = 0; i < this.Size; i++)
            {
                array[i] = true;
            }
        }

        [Benchmark]
        public void Get_MemorySavingBoolArray()
        {
            var array = new MemorySavingBoolArray(this.Size);
            for (int i = 0; i < this.Size; i++)
            {
                _ = array[i];
            }
        }

        [Benchmark]
        public void Get_NormalBoolArray()
        {
            var array = new bool[this.Size];
            for (int i = 0; i < this.Size; i++)
            {
                _ = array[i];
            }
        }
    }
}
