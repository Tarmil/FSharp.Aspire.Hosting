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

    let builder = DistributedApplication.CreateBuilder()

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

The table below lists the Aspire integrations that have been tested with an F# AppHost, and the NuGet package required to use them.
Some of them need an F#-specific package (which in turns references the standard package), and others simply need the same standard package as C# AppHosts.

| Integration | Package                       |
|:------------|:------------------------------|
| AWS         | **FSharp**.Aspire.Hosting.Aws |
| NodeJs      | Aspire.Hosting.NodeJs         |

### Why F# integrations?

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
