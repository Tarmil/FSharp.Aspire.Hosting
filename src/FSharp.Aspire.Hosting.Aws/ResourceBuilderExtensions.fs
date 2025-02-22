namespace Aspire.Hosting

open System.Runtime.CompilerServices
open System.Runtime.InteropServices
open Aspire.Hosting.AWS.CloudFormation
open Aspire.Hosting.ApplicationModel

type AwsResourceBuilderExtensions =
    
    [<Extension>]
    static member WithReference<'Destination, 'Source
            when 'Destination :> IResourceWithEnvironment
            and 'Destination :> IResourceWithWaitSupport
            and 'Source :> ICloudFormationResource>
        (
            builder: IResourceBuilder<'Destination>,
            source: IResourceBuilder<'Source>,
            [<Optional; DefaultParameterValue "AWS:Resources">] configSection: string
        ) =
        builder.WithReference(source :?> IResourceBuilder<ICloudFormationResource>, configSection)