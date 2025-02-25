# Write your Aspire AppHost in F#!

This project provides the necessary tooling to write an [Aspire](https://learn.microsoft.com/en-us/dotnet/aspire/get-started/aspire-overview) application host in F#.

## Getting started

* Install the project template:

    ```sh
    dotnet new install FSharp.Aspire.ProjectTemplates
    ```

* Create your AppHost project:

    ```sh
    dotnet new fsharp-aspire-apphost -o MyProject.AppHost
    ```

* Add your applications as references in the AppHost project.

* Declare the applications in `Program.fs`. For example:

    ```fsharp
    open Aspire.Hosting

    let builder = DistributedApplication.CreateBuilder(System.Environment.GetCommandLineArgs())

    let service = builder.AddProject<Projects.MyProjectWebService>("service")

    let webapp =
        builder.AddProject<Projects.MyProjectWebApp>("web-app")
            .WithReference(service)
            .WaitFor(service)

    builder.Build().Run()
    ```

* Run your AppHost!

[See the Aspire documentation](https://learn.microsoft.com/en-us/dotnet/aspire/get-started/aspire-overview) to learn more!

## Integrations

A number of Aspire integrations require additional code to be usable from an F# AppHost.
[See below](#why-f-integrations) for a technical explanation of why that is the case.

The table below lists the Aspire integrations that have been checked to work with an F# AppHost, and the NuGet package required to use them.
Some of them need an <img src="docs/FSharp.png" width="16"> F#-specific package, but most simply need the same <img src="docs/Aspire.png" width="16"> official or <img src="docs/CommunityToolkit.png" width="16"> community package as C# AppHosts.

| Integration              | Package                                                                                                                                                                      |
|:-------------------------|:-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| ActiveMQ                 | <img src="docs/CommunityToolkit.png" width="16"> CommunityToolkit.Aspire.Hosting.ActiveMQ                                                                                    |
| AWS                      | <img src="docs/FSharp.png" width="16"> FSharp.Aspire.Hosting.Aws                                                                                                             |
| Azure AppConfiguration   | <img src="docs/Aspire.png" width="16"> Aspire.Hosting.Azure.AppConfiguration                                                                                                 |
| Azure AppInsights        | <img src="docs/Aspire.png" width="16"> Aspire.Hosting.Azure.ApplicationInsights                                                                                              |
| Azure Bicep              | <img src="docs/FSharp.png" width="16"> FSharp.Aspire.Hosting.Azure                                                                                                           |
| Azure Cognitive Services | <img src="docs/Aspire.png" width="16"> Aspire.Hosting.Azure.CognitiveServices                                                                                                |
| Azure CosmosDB           | <img src="docs/Aspire.png" width="16"> Aspire.Hosting.Azure.CosmosDB                                                                                                         |
| Azure Data API Builder   | <img src="docs/CommunityToolkit.png" width="16"> CommunityToolkit.Aspire.Hosting.Azure.DataApiBuilder                                                                        |
| Azure EventHubs          | <img src="docs/Aspire.png" width="16"> Aspire.Hosting.Azure.EventHubs                                                                                                        |
| Azure KeyVault           | <img src="docs/Aspire.png" width="16"> Aspire.Hosting.Azure.KeyVault                                                                                                         |
| Azure PostgreSQL         | <img src="docs/Aspire.png" width="16"> Aspire.Hosting.Azure.PostgreSQL                                                                                                       |
| Azure Redis              | <img src="docs/Aspire.png" width="16"> Aspire.Hosting.Azure.Redis                                                                                                            |
| Azure Search             | <img src="docs/Aspire.png" width="16"> Aspire.Hosting.Azure.Search                                                                                                           |
| Azure ServiceBus         | <img src="docs/Aspire.png" width="16"> Aspire.Hosting.Azure.ServiceBus                                                                                                       |
| Azure SignalR            | <img src="docs/Aspire.png" width="16"> Aspire.Hosting.Azure.SignalR                                                                                                          |
| Azure SQL                | <img src="docs/Aspire.png" width="16"> Aspire.Hosting.Azure.Sql                                                                                                              |
| Azure Static Web Apps    | <img src="docs/FSharp.png" width="16"> FSharp.CommunityToolkit.Aspire.Hosting.Azure.StaticWebApps                                                                            |
| Azure Storage            | <img src="docs/Aspire.png" width="16"> Aspire.Hosting.Azure.Storage                                                                                                          |
| Azure Web PubSub         | <img src="docs/Aspire.png" width="16"> Aspire.Hosting.Azure.WebPubSub                                                                                                        |
| Bun                      | <img src="docs/CommunityToolkit.png" width="16"> CommunityToolkit.Aspire.Hosting.Bun                                                                                         |
| Dapr                     | <img src="docs/Aspire.png" width="16"> Aspire.Hosting.Dapr <br> <img src="docs/CommunityToolkit.png" width="16"> CommunityToolkit.Aspire.Hosting.Dapr                        |
| Deno                     | <img src="docs/CommunityToolkit.png" width="16"> CommunityToolkit.Aspire.Hosting.Deno                                                                                        |
| ElasticSearch            | <img src="docs/Aspire.png" width="16"> Aspire.Hosting.ElasticSearch                                                                                                          |
| EventStore               | <img src="docs/CommunityToolkit.png" width="16"> CommunityToolkit.Aspire.Hosting.EventStore                                                                                  |
| Garnet                   | <img src="docs/Aspire.png" width="16"> Aspire.Hosting.Garnet                                                                                                                 |
| Golang                   | <img src="docs/CommunityToolkit.png" width="16"> CommunityToolkit.Aspire.Hosting.Golang                                                                                      |
| Go Feature Flag          | <img src="docs/CommunityToolkit.png" width="16"> CommunityToolkit.Aspire.Hosting.GoFeatureFlag                                                                               |
| Java                     | <img src="docs/CommunityToolkit.png" width="16"> CommunityToolkit.Aspire.Hosting.Java                                                                                        |
| Kafka                    | <img src="docs/Aspire.png" width="16"> Aspire.Hosting.Kafka                                                                                                                  |
| Keycloak                 | <img src="docs/Aspire.png" width="16"> Aspire.Hosting.Keycloak                                                                                                               |
| Meilisearch              | <img src="docs/Aspire.png" width="16"> Aspire.Hosting.Meilisearch                                                                                                            |
| Memgraph                 | <img src="docs/CommunityToolkit.png" width="16"> Robbss.Aspire.Hosting.Memgraph                                                                                              |
| Milvus                   | <img src="docs/Aspire.png" width="16"> Aspire.Hosting.Milvus                                                                                                                 |
| MinIO                    | <img src="docs/CommunityToolkit.png" width="16"> BCat.Hosting.MinIO                                                                                                          |
| MongoDB                  | <img src="docs/Aspire.png" width="16"> Aspire.Hosting.MongoDB                                                                                                                |
| MySQL                    | <img src="docs/Aspire.png" width="16"> Aspire.Hosting.MySQL                                                                                                                  |
| NATS                     | <img src="docs/Aspire.png" width="16"> Aspire.Hosting.NATS                                                                                                                   |
| Ngrok                    | <img src="docs/CommunityToolkit.png" width="16"> CommunityToolkit.Aspire.Hosting.Ngrok                                                                                       |
| NodeJs                   | <img src="docs/Aspire.png" width="16"> Aspire.Hosting.NodeJs <br> <img src="docs/CommunityToolkit.png" width="16"> CommunityToolkit.Aspire.Hosting.NodeJs.Extensions         |
| Ollama                   | <img src="docs/CommunityToolkit.png" width="16"> CommunityToolkit.Aspire.Hosting.Ollama                                                                                      |
| Oracle                   | <img src="docs/Aspire.png" width="16"> Aspire.Hosting.Oracle                                                                                                                 |
| Orleans                  | <img src="docs/FSharp.png" width="16"> FSharp.Aspire.Hosting.Orleans                                                                                                         |
| Papercut SMTP            | <img src="docs/CommunityToolkit.png" width="16"> CommunityToolkit.Aspire.Hosting.PapercutSmtp                                                                                |
| PostgreSQL               | <img src="docs/Aspire.png" width="16"> Aspire.Hosting.PostgreSQL <br> <img src="docs/CommunityToolkit.png" width="16"> CommunityToolkit.Aspire.Hosting.PostgreSQL.Extensions |
| Python                   | <img src="docs/Aspire.png" width="16"> Aspire.Hosting.Python <br> <img src="docs/CommunityToolkit.png" width="16"> CommunityToolkit.Aspire.Hosting.Python.Extensions         |
| Qdrant                   | <img src="docs/Aspire.png" width="16"> Aspire.Hosting.Qdrant                                                                                                                 |
| RabbitMQ                 | <img src="docs/Aspire.png" width="16"> Aspire.Hosting.RabbitMQ                                                                                                               |
| RavenDB                  | <img src="docs/CommunityToolkit.png" width="16"> CommunityToolkit.Aspire.Hosting.RavenDB                                                                                     |
| Redis                    | <img src="docs/Aspire.png" width="16"> Aspire.Hosting.Redis                                                                                                                  |
| Rust                     | <img src="docs/CommunityToolkit.png" width="16"> CommunityToolkit.Aspire.Hosting.Rust                                                                                        |
| Seq                      | <img src="docs/Aspire.png" width="16"> Aspire.Hosting.Seq                                                                                                                    |
| Sqlite                   | <img src="docs/CommunityToolkit.png" width="16"> CommunityToolkit.Aspire.Hosting.Sqlite                                                                                      |
| SqlServer                | <img src="docs/Aspire.png" width="16"> Aspire.Hosting.SqlServer                                                                                                              |
| Valkey                   | <img src="docs/Aspire.png" width="16"> Aspire.Hosting.Valkey                                                                                                                 |

If you need an integration that is not listed above:

* Try to add the standard package for this integration and to use it in the same way as documented for C#.

* If it works, great! We will welcome a pull request to add it to the list.

* If it fails, then you can submit an issue [on this project's repository](https://github.com/Tarmil/FSharp.Aspire.Hosting/issues).

    The most likely issue you might encounter is a compilation error "No overload match for method" on a method provided by the integration.

### Why F# integrations?

This section explains the technical reason why some integrations require additional F#-specific code.

In Aspire, resources are represented by values of type `IResourceBuilder<T>`, where `T` is a concrete type that represents this kind of resource.
For example, a project resource is represented by a value of type `IResourceBuilder<ProjectResource>`.

The concrete type implements a number of interfaces that represent the capabilities of this kind of resource.
For example, `ProjectResource` implements:
* `IResourceWithEnvironment` allows referencing other resources from this project;
* `IResourceWithArgs` allows passing arguments to this project;
* `IResourceWithServiceDiscovery` allows referencing this project's endpoints from other resources;
* `IResourceWithWaitSupport` allows waiting for this project to start from other resources.

These supports are implemented using methods such as `WithReference()` that take an `IResourceBuilder<IResourceWithServiceDiscovery>` as argument.
This works fine in C#. However, F# doesn't support type parameter covariance, which means that you can't pass an `IResourceBuilder<ProjectResource>` to a method that expects an `IResourceBuilder<IResourceWithServiceDiscovery>`.
If you try, you will get an error:

```fsharp
let service = builder.AddProject<Projects.MyWebService>("service")

let webapp =
    builder.AddProject<Projects.MyWebApp>("web-app")
        .WithReference(service)
//      ^^^^^^^^^^^^^^^^^^^^^^^
// No overload match for method 'WithReference'.
//
// Known type of argument: IResourceBuilder<ProjectResource>
//
// [snip: list of available overloads]
```

The solution is to provide an overload that, instead of taking an `IResourceBuilder<IResourceWithServiceDiscovery>` as argument, is generic and takes an `IResourceBuilder<'T> when 'T :> IResourceWithServiceDiscovery`.

The NuGet package `FSharp.Aspire.Hosting.AppHost`, which is referenced out-of-the-box by the project template, provides all the relevant overloads for the standard Aspire interfaces.

Additionally, since some integrations (such as `Aws`) use their own interfaces, an additional NuGet package (such as `FSharp.Aspire.Hosting.Aws`) provides the necessary overloads for these interfaces.

## Acknowledgements

Thanks to @baronfel for his help on ironing out the MSBuild script for project code generation.
