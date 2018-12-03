using System.Collections.Generic;
using System.Threading.Tasks;
using Interfaces;
using Orleans;

namespace Grains
{
    public class SampleGrain : Grain, ISampleGrain
    {
        public Task<long> GetSum(IReadOnlyList<byte> bytes)
        {
            long sum = 0;
            foreach (var x in bytes)
                sum += x;

            return Task.FromResult(sum);
        }
    }
}
