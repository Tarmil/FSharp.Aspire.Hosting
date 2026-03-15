namespace Aspire.Hosting

open System.Runtime.CompilerServices
open System.Runtime.InteropServices
open Aspire.Hosting.ApplicationModel

// Note: We can't put all these methods in the same class,
// because the two WithReference methods differ only by their constraints,
// and therefore can't be overloads of one another.

type ResourceBuilderExtensions =

    [<Extension>]
    static member WithParentRelationship<'Child, 'Parent
            when 'Child :> IResource
            and 'Parent :> IResource>
        (
            builder: IResourceBuilder<'Child>,
            parent: IResourceBuilder<'Parent>
        ) : IResourceBuilder<'Child> =
        builder.WithParentRelationship(parent :?> IResourceBuilder<IResource>)

type ResourceBuilderWithServiceDiscoveryExtensions =

    [<Extension>]
    static member WithReference<'Destination, 'Source
            when 'Destination :> IResourceWithEnvironment
            and 'Source :> IResourceWithServiceDiscovery>
        (
            builder: IResourceBuilder<'Destination>,
            source: IResourceBuilder<'Source>
        ) : IResourceBuilder<'Destination> =
        builder.WithReference(source :?> IResourceBuilder<IResourceWithServiceDiscovery>)

type ResourceBuilderWithConnectionStringExtensions =

    [<Extension>]
    static member WithReference<'Destination, 'Source
            when 'Destination :> IResourceWithEnvironment
            and 'Source :> IResourceWithConnectionString>
        (
            builder: IResourceBuilder<'Destination>,
            source: IResourceBuilder<'Source>
        ) : IResourceBuilder<'Destination> =
        builder.WithReference(source :?> IResourceBuilder<IResourceWithConnectionString>)

type ResourceBuilderWithWaitSupportExtensions =

    [<Extension>]
    static member WaitFor<'Destination, 'Source
            when 'Destination :> IResourceWithWaitSupport
            and 'Source :> IResource>
        (
            builder: IResourceBuilder<'Destination>,
            source: IResourceBuilder<'Source>
        ) : IResourceBuilder<'Destination> =
        builder.WaitFor(source :?> IResourceBuilder<IResource>)

    [<Extension>]
    static member WaitForCompletion<'Destination, 'Source
            when 'Destination :> IResourceWithWaitSupport
            and 'Source :> IResource>
        (
            builder: IResourceBuilder<'Destination>,
            source: IResourceBuilder<'Source>,
            [<Optional; DefaultParameterValue 0>] exitCode: int
        ) : IResourceBuilder<'Destination> =
        builder.WaitForCompletion(source :?> IResourceBuilder<IResource>, exitCode)
