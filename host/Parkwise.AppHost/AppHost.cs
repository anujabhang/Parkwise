using Microsoft.Extensions.Configuration;

var builder = DistributedApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("Configuration");

IResourceBuilder<IResourceWithConnectionString> config;

// Check if connection string is provided
if (!string.IsNullOrEmpty(connectionString))
{
    // Use the existing connection
    config = builder.AddConnectionString("Configuration");
}
else
{
    // Use the emulator if no connection string is provided
    config = builder.AddAzureAppConfiguration("Configuration")
                    .RunAsEmulator(static emulator => emulator.WithLifetime(ContainerLifetime.Persistent)
                    .WithDataVolume());
}

builder.AddProject<Projects.Parkwise_WebApp>("parkwise-webapp")
       .WithReference(config)
       .WaitFor(config);

await builder.Build().RunAsync();
