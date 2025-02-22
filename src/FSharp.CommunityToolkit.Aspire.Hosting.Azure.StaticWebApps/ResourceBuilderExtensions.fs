namespace Aspire.Hosting

open System.Runtime.CompilerServices
open Aspire.Hosting.ApplicationModel

type AzureStaticWebAppsExtensions =

    [<Extension>]
    static member WithAppResource<'Source
            when 'Source :> IResourceWithEndpoints>
        (
            builder: IResourceBuilder<SwaResource>,
            source: IResourceBuilder<'Source>
        ) : IResourceBuilder<SwaResource> =
        builder.WithAppResource(source :?> IResourceBuilder<IResourceWithEndpoints>)

    [<Extension>]
    static member WithApiResource<'Source
            when 'Source :> IResourceWithEndpoints>
        (
            builder: IResourceBuilder<SwaResource>,
            source: IResourceBuilder<'Source>
        ) : IResourceBuilder<SwaResource> =
        builder.WithApiResource(source :?> IResourceBuilder<IResourceWithEndpoints>)
