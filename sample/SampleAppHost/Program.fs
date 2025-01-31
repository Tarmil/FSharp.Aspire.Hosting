open Aspire.Hosting

let builder = DistributedApplication.CreateBuilder()

let service = builder.AddProject<Projects.SampleWebService>("service")

let webapp =
    builder.AddProject<Projects.SampleWebApp>("web-app")
        .WithReference(service)
        .WaitFor(service)

builder.Build().Run()
