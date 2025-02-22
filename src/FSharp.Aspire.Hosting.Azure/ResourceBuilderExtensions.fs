namespace Aspire.Hosting

open System.Runtime.CompilerServices
open Aspire.Hosting.ApplicationModel
open Aspire.Hosting.Azure

type AzureBicepResourceExtensions =

    [<Extension>]
    static member WithParameter<'Destination, 'Source
            when 'Destination :> AzureBicepResource
            and 'Source :> IResourceWithConnectionString>
        (
            builder: IResourceBuilder<'Destination>,
            name: string,
            source: IResourceBuilder<'Source>
        ) : IResourceBuilder<'Destination> =
        builder.WithParameter(name, source :?> IResourceBuilder<IResourceWithConnectionString>)
