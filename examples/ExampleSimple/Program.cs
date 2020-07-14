using Mobi1ot;
using System;
using System.Threading.Tasks;

namespace ExampleSimple
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var options = new Mobi1otClientOptions
            {
                Username = "your-username-here",
                Password = "your-password-here"
            };
            var client = new Mobi1otClient(options);

            var response = await client.GetAccountSimsAsync();
            var resource = response.Resource;
            Console.WriteLine($"Found {resource.Found} of {resource.Total} from {resource.Offset} offset");
            Console.WriteLine("=====================");
            var simcards = resource.Sims;
            foreach (var sim in simcards)
            {
                Console.WriteLine($"MSISDN: {sim.MSISDN}");
                Console.WriteLine($"Name: {sim.Name}");
                Console.WriteLine($"IMEI: {sim.IMEI}");
                Console.WriteLine($"IMSI: {sim.IMSI}");
                Console.WriteLine($"Status: {sim.Status.GetDescription()}");
                Console.WriteLine("=====================");
            }
        }
    }
}
