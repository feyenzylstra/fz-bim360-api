using System;
using System.Threading.Tasks;
using FeyenZylstra.Bim360;
using FeyenZylstra.Bim360.Field;

namespace FeyenZylstra.Bim360.Test
{
    class Program
    {
        static async Task RunAsync()
        {
            using (var client = new FieldApiClient())
            {
                await client.LoginAsync("cshutchinson@fzcorp.com", "FZCcsh123");
                await client.LogoutAsync();
            }
        }

        static void Main(string[] args)
        {
            RunAsync().Wait();

            Console.WriteLine("Done");
            Console.ReadLine();
        }
    }
}