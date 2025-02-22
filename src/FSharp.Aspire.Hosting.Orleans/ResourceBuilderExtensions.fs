namespace Aspire.Hosting

open System.Runtime.CompilerServices
open Aspire.Hosting.ApplicationModel
open Aspire.Hosting.Orleans

type OrleansServiceExtensions =

    [<Extension>]
    static member WithClustering<'Source
            when 'Source :> IResourceWithConnectionString>
        (
            builder: OrleansService,
            source: IResourceBuilder<'Source>
        ) : OrleansService =
        builder.WithClustering(source :?> IResourceBuilder<IResourceWithConnectionString>)

    [<Extension>]
    static member WithGrainDirectory<'Source
            when 'Source :> IResourceWithConnectionString>
        (
            builder: OrleansService,
            source: IResourceBuilder<'Source>
        ) : OrleansService =
        builder.WithGrainDirectory(source :?> IResourceBuilder<IResourceWithConnectionString>)

    [<Extension>]
    static member WithGrainDirectory<'Source
            when 'Source :> IResourceWithConnectionString>
        (
            builder: OrleansService,
            name: string,
            source: IResourceBuilder<'Source>
        ) : OrleansService =
        builder.WithGrainDirectory(name, source :?> IResourceBuilder<IResourceWithConnectionString>)

    [<Extension>]
    static member WithGrainStorage<'Source
            when 'Source :> IResourceWithConnectionString>
        (
            builder: OrleansService,
            source: IResourceBuilder<'Source>
        ) : OrleansService =
        builder.WithGrainStorage(source :?> IResourceBuilder<IResourceWithConnectionString>)

    [<Extension>]
    static member WithGrainStorage<'Source
            when 'Source :> IResourceWithConnectionString>
        (
            builder: OrleansService,
            name: string,
            source: IResourceBuilder<'Source>
        ) : OrleansService =
        builder.WithGrainStorage(name, source :?> IResourceBuilder<IResourceWithConnectionString>)

    [<Extension>]
    static member WithStreaming<'Source
            when 'Source :> IResourceWithConnectionString>
        (
            builder: OrleansService,
            source: IResourceBuilder<'Source>
        ) : OrleansService =
        builder.WithStreaming(source :?> IResourceBuilder<IResourceWithConnectionString>)

    [<Extension>]
    static member WithStreaming<'Source
            when 'Source :> IResourceWithConnectionString>
        (
            builder: OrleansService,
            name: string,
            source: IResourceBuilder<'Source>
        ) : OrleansService =
        builder.WithStreaming(name, source :?> IResourceBuilder<IResourceWithConnectionString>)

    [<Extension>]
    static member WithReminders<'Source
            when 'Source :> IResourceWithConnectionString>
        (
            builder: OrleansService,
            source: IResourceBuilder<'Source>
        ) : OrleansService =
        builder.WithReminders(source :?> IResourceBuilder<IResourceWithConnectionString>)
