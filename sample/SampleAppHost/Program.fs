open Aspire.Hosting

let builder = DistributedApplication.CreateBuilder()

let awsConfig =
    builder.AddAWSSDKConfig()

let awsStack =
    builder.AddAWSCloudFormationStack("aws-stack")
        .WithReference(awsConfig)

let sqlServer =
    builder.AddSqlServer("sql-server")

let azureStack =
    builder.AddBicepTemplateString("azure-stack", "stack.bicep")
        .WithParameter("sqlServer", sqlServer)

let service =
    builder.AddProject<Projects.SampleWebService>("service")
        .WithReference(awsConfig)
        .WithReference(awsStack)
        .WaitFor(azureStack)
        .WithEnvironment("AZURE_SERVICE_URL", azureStack.GetOutput("azureServiceUrl"))

let webapp =
    builder.AddProject<Projects.SampleWebApp>("web-app")
        .WithReference(service)
        .WaitFor(service)

builder.Build().Run()
