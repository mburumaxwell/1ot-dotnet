using Microsoft.Extensions.DependencyInjection;
using Mobi1ot;
using System;

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
