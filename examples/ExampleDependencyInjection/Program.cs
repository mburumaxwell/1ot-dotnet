using Microsoft.Extensions.DependencyInjection;
using Mobi1ot;
using System;
using System.Threading.Tasks;

namespace ExampleDependencyInjection
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var username = "your-username-here";
            var password = "your-password-here";

            var services = new ServiceCollection();
            services.AddMobi1ot(username: username, password: password);

            var provider = services.BuildServiceProvider();

            var client = provider.GetRequiredService<Mobi1otClient>();

            var response = await client.GetAccountSimsAsync();
            var resource = response.Resource;
            Console.WriteLine($"Found {resource.Found} of {resource.Total} from {resource.Offset} offset");
            var simcards = resource.Sims;
            foreach (var sim in simcards)
            {
                Console.WriteLine($"MSISDN: {sim.MSISDN}, Name: {sim.Name}, IMEI: {sim.IMEI}, IMSI: {sim.IMSI}, Status: {sim.Status.GetDescription()}");
            }
        }
    }
}
