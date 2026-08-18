var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Parkwise_WebApp>("parkwise-webapp");

await builder.Build().RunAsync();
