using System;
using System.Linq;
using System.Threading.Tasks;
using Interfaces;
using Orleans;
using Orleans.Configuration;

namespace Client
{
    class Program
    {
        static async Task Main()
        {
            var client = new ClientBuilder()
                .UseLocalhostClustering()
                .Configure<ClusterOptions>(options => options.ClusterId = options.ServiceId = ClusterConstants.ServiceId)
                .Build();

            var stop = false;
            Console.CancelKeyPress += (sender, args) => stop = true;

            using (client)
            {
                await client.Connect();

                var grain = client.GetGrain<ISampleGrain>(0);

                var list = Enumerable.Range(0, 1 << 16)
                    .Select(x => (byte)x)
                    .ToList();

                while (!stop)
                    await grain.GetSum(list);

                await client.Close();
            }
        }
    }
}
