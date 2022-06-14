using BenchmarkDotNet.Attributes;

namespace MemorySavingBoolArray.Benchmarks
{
    /// <summary>
    /// It seems like in this case the compiler does such good optimizations, that the fast
    /// modulus is less than 1% faster. However the implementation of the MemorySavingBoolArray
    /// with fast modulo is around 15 - 25 % faster than with standard modulo
    /// (<see cref="FastModuloMemorySavingBoolArray"/> and belonging benchmark).
    ///
    /// Because of that this benchmark seems to have a flaw or does not represent the same
    /// situation as in the implementation classes.
    /// </summary>
    public class FastModulusBenchmark
    {
        private const int DENOMINATOR = 8;

        private const int BITWISE_AND_PARTNER = DENOMINATOR - 1;

        [Params(100_000, 1_000_000)] 
        public int Runs { get; set; }

        [Benchmark]
        public void StandardModulus()
        {
            for (int i = 0; i < Runs; i++)
            {
                _ = Runs % DENOMINATOR; 
            }
        }

        [Benchmark]
        public void FastModulus()
        {
            for (int i = 0; i < Runs; i++)
            {
                _ = Runs & BITWISE_AND_PARTNER; 
            }
        }
    }
}
