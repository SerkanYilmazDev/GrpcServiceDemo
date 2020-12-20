using Grpc.Core;
using Grpc.Net.Client;
using GrpcService;
using System;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new Greeter.GreeterClient(channel);

            //Unary Call
            //var response = await client.SayHelloAsync(new HelloRequest
            //{
            //    Name = "gRPC Demo"
            //});

            //Console.WriteLine("From Server: " + response.Message);

            //Stream call
            var call = client.SayHelloStream(new HelloRequest
            {
                Name = "gRPC Demo Streaming"
            });

            await foreach (var item in call.ResponseStream.ReadAllAsync())
            {
                Console.WriteLine("From server: " + item.Message);
            }
        }
    }
}
