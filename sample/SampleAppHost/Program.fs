open Aspire.Hosting

let builder = DistributedApplication.CreateBuilder()

let awsConfig =
    builder.AddAWSSDKConfig()

let awsStack =
    builder.AddAWSCloudFormationStack("aws-stack")
        .WithReference(awsConfig)

let service =
    builder.AddProject<Projects.SampleWebService>("service")
        .WithReference(awsConfig)
        .WithReference(awsStack)

let webapp =
    builder.AddProject<Projects.SampleWebApp>("web-app")
        .WithReference(service)
        .WaitFor(service)

builder.Build().Run()
