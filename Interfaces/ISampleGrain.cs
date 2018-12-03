using System.Collections.Generic;
using System.Threading.Tasks;
using Orleans;

namespace Interfaces
{
    public interface ISampleGrain : IGrainWithIntegerKey
    {
        Task<long> GetSum(IReadOnlyList<byte> bytes);
    }
}
